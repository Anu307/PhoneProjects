using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace QuickDialer
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Phone_Text.Focus();
        }
        private void Dial_Click(object sender, EventArgs e)
        {
            Phone_Text.Focus();
        }
        private void Phone_textKeyDown(object sender, KeyEventArgs e)
        {
            
            PhoneCallTask phTask = new PhoneCallTask();
            string str = e.Key.ToString();
            str =str.ToLower().Replace("numpad","");
            int i = str[0] -'0';
            if (i >=0 &&i<=9 &&( App.NumbersArray[i]!="Number"))
            {            
                phTask.DisplayName = App.Nicknamesarray[i];
                phTask.PhoneNumber = App.NumbersArray[i];
                phTask.Show();
            }
            else if(i >=0 &&i<=9 )
            {
                MessageBox.Show("Add some number to the shortcut for quickly dialing it");
                NavigationService.Navigate(new Uri("/detail_Page.xaml", UriKind.RelativeOrAbsolute));

            }
            //Phone_Text.KeyDown();
        }

        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for QuickDialer v1.00";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
        }
        private void Shortcut_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/detail_Page.xaml", UriKind.RelativeOrAbsolute));
        }
          
    }

}