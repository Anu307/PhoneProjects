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
using System.Windows.Threading;
using System.IO.IsolatedStorage;

namespace XmasCarol
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        public string mediafilename = "";
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 35000); // 60 Seconds  
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();

            MSAdControlAd1.AdRefreshed += MSAdControl_NewAd;

            MSAdControlAd1.ErrorOccurred += MSAdControl1_AdControlError;

            MSAdControlAd2.AdRefreshed += MSAdControl_NewAd;
            MSAdControlAd2.ErrorOccurred += MSAdControl2_AdControlError;


        }
        void MSAdControl_NewAd(object sender, System.EventArgs e)
        {

            // use try/catch to minimize any possibility of Ad Control crashes
            MSAdControlAd1.Visibility = Visibility.Visible;
            MSAdControlAd2.Visibility = Visibility.Visible;
            // AdDuplexAdControl.Visibility = Visibility.Collapsed;
            // InneractiveXamlAd.Visibility = Visibility.Collapsed;

        }



        void MSAdControl1_AdControlError(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {

            MSAdControlAd1.Visibility = Visibility.Collapsed;

            AdDuplexAdControl1.Visibility = Visibility.Visible;

        }
        void MSAdControl2_AdControlError(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {

          //  MSAdControlAd2.Visibility = Visibility.Collapsed;

          //  AdDuplexAdControl2.Visibility = Visibility.Visible;

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

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
               DataContext = App.ViewModel.Items[index];
                string str = App.strList[index * 2 + 1] + ".html";
                mediafilename = App.strList[index * 2];
              MyBrowser.Navigate(new Uri(str, UriKind.RelativeOrAbsolute));
              MediaP.Source = new Uri("music\\" + mediafilename, UriKind.RelativeOrAbsolute);
              /*using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
              {
                  if (storage.FileExists(str))
                  {
                      str = str + "2";
                  }
                  str = "Htmls\\" + str;
                  if (storage.FileExists(str))
                    {
                        str = str + "3";
                     }
              }*/

            }
           
        }

        private void MediaP_MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaP.Play();
            MediaP.Volume = 0.8;

        }

        private void MediaP_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}