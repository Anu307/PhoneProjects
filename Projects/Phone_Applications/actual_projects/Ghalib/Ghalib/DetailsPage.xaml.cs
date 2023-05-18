﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Ghalib.Resources;
using System.Windows.Threading;
using Microsoft.Phone.Tasks;
using System.Windows.Resources;
using System.IO;
namespace Ghalib
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        string lastpage = "1";
        int recentpage;
        string strTalkingText;
        string storyname;
        bool AbtMirza = false;
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 45000); // 60 Seconds  
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MSAdControlAd1.AdRefreshed += MSAdControl_NewAd;

            MSAdControlAd1.ErrorOccurred += MSAdControl1_AdControlError;

            MSAdControlAd2.AdRefreshed += MSAdControl_NewAd;
            MSAdControlAd2.ErrorOccurred += MSAdControl2_AdControlError;
            string selectedIndex = "";
            NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex);
            if (selectedIndex == "About")
            {
                MyBrowser.Navigate(new Uri("files\\aboutghalib.htm", UriKind.RelativeOrAbsolute));
                EnableButtons(false);
            }
            else
            {
                App.lastghazal = lastpage = selectedIndex;
                recentpage = Convert.ToInt32(selectedIndex);
                MyNavigate();
                               
            }

      
        }
        private void EnableButtons(bool enable)
        {
            AbtMirza = !enable;
            ApplicationBarIconButton mi0 = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            mi0.IsEnabled = enable;
            ApplicationBarIconButton mi1 = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
            mi1.IsEnabled = enable;
            ApplicationBarIconButton mi2 = (ApplicationBarIconButton)ApplicationBar.Buttons[2];
            mi2.IsEnabled = enable;

        }
        private void MyNavigate()
        {
            if (AbtMirza)
                return;
            storyname = "files\\ghalib" + lastpage + ".html";
            MyBrowser.Navigate(new Uri(storyname, UriKind.RelativeOrAbsolute));
            storyname = storyname.Replace(".html", ".txt");

            StreamResourceInfo resource = Application.GetResourceStream(new Uri(storyname, UriKind.Relative));
            StreamReader reader = new StreamReader(resource.Stream);
            strTalkingText = reader.ReadToEnd();
            storyname = storyname.Replace(".txt", "");

        }
        private void Email_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = "Ghalib Shayari from Wp8 App " ;
            emailcomposetask.Body = strTalkingText;
            

            emailcomposetask.Show();

        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if(!AbtMirza)
                App.lastghazal = lastpage;
            // Note that we don't set e.Cancel=true, to enable back press to implement page Goback.          
            base.OnBackKeyPress(e);  // Call base
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
           catch {;}
       }

       private void MoveNext()
       {
         
           recentpage = Convert.ToInt32(lastpage);
           recentpage = recentpage % 75;
           recentpage++;
           App.lastghazal = lastpage = recentpage.ToString();
           MyNavigate();
       }
       private void MoveBack()
       {
           recentpage = Convert.ToInt32(lastpage);
           if (recentpage == 1)
               recentpage = 75;
           else
               recentpage--;
           App.lastghazal = lastpage = recentpage.ToString();
           MyNavigate();
       }

       private void OnFlick(object sender, FlickGestureEventArgs e)
       {
           string str = string.Format("{0} Flick: Angle {1} Velocity {2},{3}",
               e.Direction, Math.Round(e.Angle), e.HorizontalVelocity, e.VerticalVelocity);
           if (e.HorizontalVelocity < -200)
           {
               MoveNext();
           }
           else if (e.HorizontalVelocity > 200)
           {
               MoveBack();
           }
       }

       private void Back_Click(object sender, EventArgs e)
       {
           MoveBack();
       }
       private void Next_Click(object sender, EventArgs e)
       {
           MoveNext();

       }
    }
}