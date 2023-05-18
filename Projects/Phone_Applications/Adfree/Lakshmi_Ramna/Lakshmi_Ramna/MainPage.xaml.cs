using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Tasks;
using System.Windows.Threading;

namespace Lakshmi_Ramna
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (btn.Text == "Play")
            {

                if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                {
                    btn.Text = "Pause";
                    btn.IconUri = new Uri("transport.pause.png", UriKind.Relative);
                }
            }
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 45000); // 60 Seconds  
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();

            MSAdControlAd1.AdRefreshed += MSAdControl_NewAd;

            MSAdControlAd1.ErrorOccurred += MSAdControl1_AdControlError;

            MSAdControlAd2.AdRefreshed += MSAdControl_NewAd;
            MSAdControlAd2.ErrorOccurred += MSAdControl2_AdControlError;
        }

        private void Toggle_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton mi = (ApplicationBarIconButton)ApplicationBar.Buttons[2];

            if (mi.Text == "Text")
            {
                mi.Text = "Picture";
                Image.Source = new BitmapImage(new Uri("Lakshmi_Ramna.png", UriKind.RelativeOrAbsolute));
            }
            else if (mi.Text == "Picture")
            {
                mi.Text = "Text";
                Image.Source = new BitmapImage(new Uri("Background.png", UriKind.RelativeOrAbsolute));

            }


        }
        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for Lakshmi Ramna v2.00";
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
        private void Play_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (btn.Text == "Play")
            {
                btn.Text = "Pause";
                btn.IconUri = new Uri("transport.pause.png", UriKind.Relative);
                //if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                // {
                BackgroundAudioPlayer.Instance.Play();
                //}
            }
            else if (btn.Text == "Pause")
            {
                btn.Text = "Play";
                btn.IconUri = new Uri("transport.play.png", UriKind.Relative);
                if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                {
                    BackgroundAudioPlayer.Instance.Pause();
                }
            }

            //Do work for your application here.
        }
        private void Pause_Click(object sender, EventArgs e)
        {




            //Do work for your application here.
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
            {
                BackgroundAudioPlayer.Instance.Stop();
            }
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (btn.Text == "Pause")
            {
                btn.Text = "Play";
                btn.IconUri = new Uri("transport.play.png", UriKind.Relative);
                if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                {
                    BackgroundAudioPlayer.Instance.Pause();
                }
            }

        }
        void MSAdControl_NewAd(object sender, System.EventArgs e)
        {

            // use try/catch to minimize any possibility of Ad Control crashes
            MSAdControlAd1.Visibility = Visibility.Visible;
            MSAdControlAd2.Visibility = Visibility.Visible;
            AdDuplexAdControl.Visibility = Visibility.Collapsed;
            InneractiveXamlAd.Visibility = Visibility.Collapsed;

        }



        void MSAdControl1_AdControlError(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {

            MSAdControlAd1.Visibility = Visibility.Collapsed;

            AdDuplexAdControl.Visibility = Visibility.Visible;

        }
        void MSAdControl2_AdControlError(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {

            MSAdControlAd2.Visibility = Visibility.Collapsed;

            InneractiveXamlAd.Visibility = Visibility.Visible;

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
            catch { ;}

        }  

    }


}
