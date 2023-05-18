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
namespace SriSathyaSaiVani
{
    public partial class MainPage : PhoneApplicationPage
    {
        static int ipicnumber;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ipicnumber = 9;
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (btn.Text == "Play")
            {

                if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                {
                    btn.Text = "Pause";
                    btn.IconUri = new Uri("transport.pause.png", UriKind.Relative);
                }
            }

        }

        private void Toggle_Click(object sender, EventArgs e)
        {
            ChangePic();
        }
        void ChangePic()
        {
            ipicnumber++;
            if (ipicnumber == 11) ipicnumber = 1;
            Image.Source = new BitmapImage(new Uri("pics\\Sathyasai_" + ipicnumber + ".jpg", UriKind.RelativeOrAbsolute));

        }
        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for SriSathyaSaiVani v1.00";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
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

        private void Next_Click(object sender, EventArgs e)
        {
            BackgroundAudioPlayer.Instance.SkipNext();
            ChangePic();
        }
        private void Previous_Click(object sender, EventArgs e)
        {
            BackgroundAudioPlayer.Instance.SkipPrevious();
            ChangePic();
        }

    }


}
