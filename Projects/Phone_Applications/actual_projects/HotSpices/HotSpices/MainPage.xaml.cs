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
using Microsoft.Phone.BackgroundAudio;

namespace HotSpices
{
    public partial class MainPage : PhoneApplicationPage
    {
       // static int pivotpagenumber;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
          //  pivotpagenumber = 0;
            //BackgroundAudioPlayer.Instance.Pause();
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void Pivotselectionchanged(object sender, RoutedEventArgs e)
        {
            if ((PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState || PlayState.Paused == BackgroundAudioPlayer.Instance.PlayerState) && 
                ( BackgroundAudioPlayer.Instance.CanPause))
                BackgroundAudioPlayer.Instance.Stop();
            /*int selectedindex = MyPivot.SelectedIndex;

            // if (selectedindex > 10)
              //  selectedindex -= 11;
            if (pivotpagenumber != selectedindex)
            {
                if (pivotpagenumber == 0 && selectedindex == 21)
                {
                    BackgroundAudioPlayer.Instance.SkipPrevious();
                }
                else if (pivotpagenumber == 21 && selectedindex == 0)
                {
                    BackgroundAudioPlayer.Instance.SkipNext();
                }

                else if (pivotpagenumber < selectedindex)
                {
                    BackgroundAudioPlayer.Instance.SkipNext();
                }
                else if(selectedindex <pivotpagenumber)
                {
                    BackgroundAudioPlayer.Instance.SkipPrevious();
                }
                pivotpagenumber = selectedindex;
            }

          //  BackgroundAudioPlayer.Instance.Stop();*/
           


        }
        private void PivotItemLoaded(object sender, EventArgs e)
        {
            //pivotpagenumber = MyPivot.SelectedIndex;



        }
       /* private void PlaySound(object sender, RoutedEventArgs e)
        {
           PivotItem pi = (PivotItem)MyPivot.SelectedItem;

           Image image = (Image)sender;
          





            string str = pi.Header.ToString() +".wma";
          // string str2=""; 
            str = str.ToLower();

            AudioTrack track = new AudioTrack(new Uri(str, UriKind.Relative),
                                    "Bird_Sounds",
                                    "PhoneApp",
                                    str,
                                    null);
            BackgroundAudioPlayer.Instance.Track = track;
            BackgroundAudioPlayer.Instance.Play();

           /* BackgroundAudioPlayer player = BackgroundAudioPlayer.Instance;
            if (player.Track != null)
                str2 = player.Track.Album;

            while((player.Track!=null)&& (str!= str2))
            {
                for (int i = 0; i < 10000; i++)
                {
                    str.ToLower();
                }
                str2 = player.Track.Album;

                player.SkipPrevious();
            }*/
   

             //   BackgroundAudioPlayer.Instance.Play();
        

       // }

        private void PlaySound(object sender, GestureEventArgs e)
        {
            PivotItem pi = (PivotItem)MyPivot.SelectedItem;
           
            Point mousePoint = e.GetPosition(null);
            string str = pi.Header.ToString() + ".wav";
            // string str2=""; 
            str = str.ToLower();

          

            AudioTrack track = new AudioTrack(new Uri(str, UriKind.Relative),
                                    "Spice_Sounds",
                                    "PhoneApp",
                                    str,
                                    null);
            BackgroundAudioPlayer.Instance.Track = track;
            BackgroundAudioPlayer.Instance.Play();


        }
    }
}