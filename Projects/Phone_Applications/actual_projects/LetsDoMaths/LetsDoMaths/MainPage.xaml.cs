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
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
namespace LetsDoMaths
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
           // UpdatePageLayout();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 45000); // 60 Seconds  
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
          /*  MSAdControlAd1.AdRefreshed += MSAdControl_NewAd;

            MSAdControlAd1.ErrorOccurred += MSAdControl1_AdControlError;

            MSAdControlAd2.AdRefreshed += MSAdControl_NewAd;
            MSAdControlAd2.ErrorOccurred += MSAdControl2_AdControlError;*/

        }
       /* private  void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int i =  SetFile();
            bleep.Play();
        }
        private void Dial_Click(object sender, EventArgs e)
        {
            //Phone_Text.Focus();
        }*/
        /*   private void Phone_textKeyDown(object sender, KeyEventArgs e)
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
           }*/


      /*  private void Shortcut_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/detail_Page.xaml", UriKind.RelativeOrAbsolute));
        }*/

       /* private void But1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phTask = new PhoneCallTask();

            string str = sender.ToString();
            Button but = (Button)sender;
            str = but.Content.ToString();

            int i = 0;
            for (; i < 12; i++)
            {
                if (str.Equals(App.Nicknamesarray[i]))
                    break;
            }

            phTask.DisplayName = App.Nicknamesarray[i];
            phTask.PhoneNumber = App.NumbersArray[i];
            phTask.Show();

        }*/
       /* protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UpdatePageLayout();


        }*/
      /*  private void UpdatePageLayout()
        {
            Button[] ButtonArray = { But0, But1, But2, But3, But4, But5, But6, But7, But8, But9, But10, But11 };
            string[] strFilePath = { "image0.jpg", "image1.jpg", "image2.jpg", "image3.jpg", "image4.jpg", "image5.jpg", "image6.jpg", "image7.jpg", "image8.jpg", "image9.jpg", "image10.jpg", "image11.jpg" };

            for (int i = 0; i < 12; i++)
            {
                if (App.Nicknamesarray[i] == "Nickname")
                {
                    ButtonArray[i].Visibility = Visibility.Collapsed;
                }
                else
                {
                    ButtonArray[i].Content = App.Nicknamesarray[i];
                    ButtonArray[i].Visibility = Visibility.Visible;
                    BannerButton.Visibility = Visibility.Collapsed;
                    try
                    {

                        using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                        {
                            lock (storage)
                            {
                                if (storage.FileExists(strFilePath[i]))
                                {
                                    using (IsolatedStorageFileStream file = storage.OpenFile(strFilePath[i], System.IO.FileMode.Open))
                                    {
                                        ImageBrush background = new ImageBrush();
                                        BitmapImage img = new BitmapImage();
                                        img.UriSource = new Uri(file.Name);
                                        background.ImageSource = img;
                                        ButtonArray[i].Background = background;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //can't get a picture of the contact
                    }
                }

            }



        }

        private void BannerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/detail_Page.xaml", UriKind.RelativeOrAbsolute));

        }*/
      /*  void MSAdControl_NewAd(object sender, System.EventArgs e)
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

        }*/


        void dt_Tick(object sender, EventArgs e)
        {
            try
            {

               /* if (MSAdControlAd1.Visibility != Visibility.Visible)
                    MSAdControlAd1.Visibility = Visibility.Visible;
                MSAdControlAd1.Refresh();
                if (MSAdControlAd2.Visibility != Visibility.Visible)
                    MSAdControlAd2.Visibility = Visibility.Visible;
                MSAdControlAd2.Refresh();*/


            }
            catch { ;}

        }

        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            App.operation = "add";
            NavigationService.Navigate(new Uri("/detail_Page.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            App.operation = "subtract";
            NavigationService.Navigate(new Uri("/detail_Page.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            App.operation = "mult";
            NavigationService.Navigate(new Uri("/detail_Page.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            App.operation = "divide";
            NavigationService.Navigate(new Uri("/detail_Page.xaml", UriKind.RelativeOrAbsolute));

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
        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for LetsDoMaths v1.00";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
        }
        private void Settings_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/SettingsPage.xaml" , UriKind.Relative));

        }

    }

}