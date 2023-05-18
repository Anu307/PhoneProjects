using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LetsDoMaths
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            TextIterations.Text = App.iterations.ToString();
            TextMaxNumber.Text = App.maxnumber.ToString();
            TextMinNumber.Text = App.leastnumber.ToString();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            int iterations = Convert.ToInt32(TextIterations.Text);
            int leastnum = Convert.ToInt32(TextMinNumber.Text);
            int maxnum = Convert.ToInt32(TextMaxNumber.Text);

            
            if (maxnum > 99)
            {
                MessageBox.Show("Max number cannot be more than 99");
                TextMaxNumber.Text = "99";
                return;
            }
            if (leastnum < 0)
            {
                MessageBox.Show("Least number cannot be less than 0");
                TextMinNumber.Text = "0";
                return;
            }
            if (iterations > 25)
            {
                MessageBox.Show("Max questions cannot be more than 25");
                TextIterations.Text = "25";
                return;
            }
             App.striterations = TextIterations.Text;
            App.strmaxnumber =TextMaxNumber.Text;
            App.strleastnumber =TextMinNumber.Text;
            App.iterations = iterations;
            App.leastnumber = leastnum;
            App.maxnumber = maxnum;
            App.settings.AddOrUpdateValue("IterationSetting", App.striterations);
            App.settings.AddOrUpdateValue("MaxValSetting", App.strmaxnumber);
            App.settings.AddOrUpdateValue("MinValSetting", App.strleastnumber);
            App.settings.Save();
            NavigationService.GoBack();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}