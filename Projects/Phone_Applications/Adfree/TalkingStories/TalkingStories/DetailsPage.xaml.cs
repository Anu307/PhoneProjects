using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using Windows.Phone.Speech.Synthesis;
using System.Windows.Resources;
using System.IO;


namespace TalkingStories
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        SpeechSynthesizer _synthesizer = null ;
        string strTalkingText;
        string storyname;
       
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            if (_synthesizer == null)
            {
                _synthesizer = new SpeechSynthesizer();
            }
            else
            {
                _synthesizer.CancelAll();
            }
          
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            strTalkingText = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                DataContext = App.ViewModel.Items[index];
                storyname ="files\\";
                storyname =storyname + App.ViewModel.Items[index].LineOne + ".htm";
                MyBrowser.Navigate(new Uri(storyname, UriKind.RelativeOrAbsolute));
                storyname = storyname.Replace(".htm", ".txt");

                StreamResourceInfo resource = Application.GetResourceStream(new Uri(storyname, UriKind.Relative));
                StreamReader reader = new StreamReader( resource.Stream );
                strTalkingText = reader.ReadToEnd();
                storyname = storyname.Replace(".txt","");
              }
       
        }
       
        private async void Play_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];

            if (btn.Text == "Read")
            {
                btn.Text = "Stop";
                btn.IconUri = new Uri("cancel.png", UriKind.Relative);
                try
                {
                    await _synthesizer.SpeakTextAsync(strTalkingText);
                }
                catch(Exception)
                {
                    btn.Text = "Read";
                    btn.IconUri = new Uri("transport.play.png", UriKind.Relative);
                    _synthesizer.CancelAll();
                }
            }
            else if (btn.Text == "Stop")
            {
                btn.Text = "Read";
                btn.IconUri = new Uri("transport.play.png", UriKind.Relative);
                _synthesizer.CancelAll();
            }
        }
        private void Email_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = "TalkingStories story " + storyname.Replace("files\\", "");
            emailcomposetask.Body = strTalkingText;

            emailcomposetask.Show();

        }
        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            //  emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Subject = " Feedback for TalkingStories -Adfree v1.000";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            _synthesizer.CancelAll();

            // Note that we don't set e.Cancel=true, to enable back press to implement page Goback.          

            base.OnBackKeyPress(e);  // Call base

        }


    }
}