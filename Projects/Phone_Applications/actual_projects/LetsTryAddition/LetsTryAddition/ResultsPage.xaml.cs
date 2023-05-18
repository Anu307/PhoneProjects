using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LetsTryAddition
{
    public partial class ResultsPage : PhoneApplicationPage
    {
        public ResultsPage()
        {
            InitializeComponent();
            Results.Text = App.resultstring;
            Score.Text = App.score.ToString() + " out of " + App.iterations.ToString();
        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {


            NavigationService.RemoveBackEntry();

        }

    }
}