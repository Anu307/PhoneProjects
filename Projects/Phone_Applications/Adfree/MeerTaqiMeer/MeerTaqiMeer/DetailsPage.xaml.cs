using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MeerTaqiMeer.Resources;
using System.Windows.Threading;
using Microsoft.Phone.Tasks;
using System.Windows.Resources;
using System.IO;
namespace MeerTaqiMeer
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

        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex);
            if (selectedIndex == "About")
            {
                MyBrowser.Navigate(new Uri("files\\aboutMeerTaqiMeer.htm", UriKind.RelativeOrAbsolute));
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
            storyname = "files\\MeerTaqiMeer" + lastpage + ".htm";
            MyBrowser.Navigate(new Uri(storyname, UriKind.RelativeOrAbsolute));
            storyname = storyname.Replace(".htm", ".txt");

            StreamResourceInfo resource = Application.GetResourceStream(new Uri(storyname, UriKind.Relative));
            StreamReader reader = new StreamReader(resource.Stream);
            strTalkingText = reader.ReadToEnd();
            storyname = storyname.Replace(".txt", "");

        }
        private void Email_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = "MeerTaqiMeer Shayari from Wp App " ;
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
      

       private void MoveNext()
       {
         
           recentpage = Convert.ToInt32(lastpage);
           recentpage = recentpage % 45;
           recentpage++;
           App.lastghazal = lastpage = recentpage.ToString();
           MyNavigate();
       }
       private void MoveBack()
       {
           recentpage = Convert.ToInt32(lastpage);
           if (recentpage == 1)
               recentpage = 45;
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