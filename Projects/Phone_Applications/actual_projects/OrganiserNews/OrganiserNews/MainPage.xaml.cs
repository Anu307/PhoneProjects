using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OrganiserNews.Resources;
using Microsoft.Phone.Tasks;
using System.Windows.Threading;
namespace OrganiserNews
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 45000); // 60 Seconds  
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();

            MSAdControlAd1.AdRefreshed += MSAdControl_NewAd;

            MSAdControlAd1.ErrorOccurred += MSAdControl1_AdControlError;
            MyBrowser.Navigate(new Uri("http:\\\\www.organiser.org", UriKind.Absolute));
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private void RefreshClick(object sender, EventArgs e)
        {
            MyBrowser.Navigate(MyBrowser.Source);
        }

        private void HomeClick(object sender, EventArgs e)
        {
            MyBrowser.Navigate(new Uri("http:\\\\www.organiser.org", UriKind.Absolute));

        }
        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for Organiser Newspaper v2.00";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
        }
        private void Review_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();

            marketplaceSearchTask.SearchTerms = "SVAM";

            marketplaceSearchTask.Show();

        }
        void MSAdControl_NewAd(object sender, System.EventArgs e)
        {

            // use try/catch to minimize any possibility of Ad Control crashes
            MSAdControlAd1.Visibility = Visibility.Visible;
            MSAdControlAd2.Visibility = Visibility.Visible;
            AdDuplexAdControl.Visibility = Visibility.Collapsed;
          
        }



        void MSAdControl1_AdControlError(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {

            MSAdControlAd1.Visibility = Visibility.Collapsed;

            AdDuplexAdControl.Visibility = Visibility.Visible;

        }
        void dt_Tick(object sender, EventArgs e)
        {
            try
            {

                if (MSAdControlAd1.Visibility != Visibility.Visible)
                    MSAdControlAd1.Visibility = Visibility.Visible;
                MSAdControlAd1.Refresh();
                if (MSAdControlAd2.Visibility != Visibility.Visible)
                    MSAdControlAd2.Visibility = Visibility.Visible;
                MSAdControlAd2.Refresh();


            }
            catch {; }

        }


    }
}