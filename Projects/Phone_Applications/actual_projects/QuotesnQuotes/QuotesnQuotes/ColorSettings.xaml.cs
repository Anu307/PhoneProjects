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
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Coding4Fun.Toolkit.Controls;
namespace QuotesnQuotes
{
    public partial class ColorSettings : PhoneApplicationPage
    {
        String strcolorname;
        public ColorSettings()
        {
            InitializeComponent();
        }
        private void picker_ColorChanged(object sender, Color color)
        {
            this.ColorRect.Fill = new SolidColorBrush(color);
            strcolorname = color.ToString();
        }

        private void Save_CLick(object sender, EventArgs e)
        {
            App.colorstring = strcolorname;
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}