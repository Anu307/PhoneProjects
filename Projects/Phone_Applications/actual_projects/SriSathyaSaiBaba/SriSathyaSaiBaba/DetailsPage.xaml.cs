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
using Microsoft.Phone.BackgroundAudio;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
namespace SriSathyaSaiBaba
{
    public partial class DetailsPage : PhoneApplicationPage
    {

        static int ipicnumber;
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            ipicnumber = 0;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 45000); // 60 Seconds  
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
            MSAdControlAd1.AdRefreshed += MSAdControl_NewAd;

            MSAdControlAd1.ErrorOccurred += MSAdControl1_AdControlError;

            MSAdControlAd2.AdRefreshed += MSAdControl_NewAd;
            MSAdControlAd2.ErrorOccurred += MSAdControl2_AdControlError;

            somaAdViewer.Pub = 923874810;       // Developer pub ID for testing
            somaAdViewer.Adspace = 65823238;   // Developer adSpace ID for testing
            somaAdViewer.StartAds();           
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                if ((PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState) || (PlayState.Paused == BackgroundAudioPlayer.Instance.PlayerState))
                {
                    BackgroundAudioPlayer.Instance.Stop();
                }
                BackgroundAudioPlayer.Instance.Track = null;
                WriteToStorage();
                BackgroundAudioPlayer.Instance.Play();
            }
           
        }

        private void WriteToStorage()
        {
            try
            {
                using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    string strFilePath = "playlist.txt";
                    lock (storage)
                    {
                        if (storage.FileExists(strFilePath))
                        {
                            storage.DeleteFile(strFilePath);
                        }
                    }
                    using (IsolatedStorageFileStream file = storage.CreateFile(strFilePath))
                    {
                       int byteCount =10;
                       file.Write(App.bytes, 0, byteCount);
                    }                
                }
            }
            catch (Exception)
            {

            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];

            if (btn.Text == "Play")
            {
                btn.Text = "Pause";
                btn.IconUri = new Uri("transport.pause.png", UriKind.Relative);
                BackgroundAudioPlayer.Instance.Play();

            }
            else if (btn.Text == "Pause")
            {
                btn.Text = "Play";
                btn.IconUri = new Uri("transport.play.png", UriKind.Relative);
                if ((PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState) && BackgroundAudioPlayer.Instance.CanPause)
                {
                    BackgroundAudioPlayer.Instance.Pause();
                }

            }
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            if ((PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState) && BackgroundAudioPlayer.Instance.CanPause)
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
        private void Image_Click(object sender, EventArgs e)
        {
            ipicnumber++;
            if (ipicnumber == 8) ipicnumber = 1;
            MyImage.Source = new BitmapImage(new Uri("Sathyasai_" + ipicnumber + ".jpg", UriKind.RelativeOrAbsolute));
            
        }
        void MSAdControl_NewAd(object sender, System.EventArgs e)
        {

            // use try/catch to minimize any possibility of Ad Control crashes
            MSAdControlAd1.Visibility = Visibility.Visible;
            MSAdControlAd2.Visibility = Visibility.Visible;
            somaAdViewer.Visibility = Visibility.Collapsed;
            InneractiveXamlAd.Visibility = Visibility.Collapsed;

        }



        void MSAdControl1_AdControlError(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {

            MSAdControlAd1.Visibility = Visibility.Collapsed;

            somaAdViewer.Visibility = Visibility.Visible;

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