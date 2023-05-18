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

namespace Soundcheck
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private  void Button_Click(object sender, RoutedEventArgs e)
        {
           // SoundEffect soundEffect;

           // MediaElement snd = new MediaElement();
            
            bleep.Source = new Uri("camel.wma", UriKind.Relative);
           // snd.AutoPlay = false;
           // snd.Play();
            //snd.Stop();
           // double d = snd.Volume;
           // StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync("Sounds");
            //torageFile file = await folder.GetFileAsync("beep.wav");
            //var stream = await file.OpenAsync(FileAccessMode.Read);
            //snd.SetSource(stream, file.ContentType);
            bleep.Play();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int i = await SetFile();
            bleep.Play();
        }
        private async int SetFile()
        {
            bleep.Source =  new Uri("camel.wma", UriKind.Relative);
            return 1;

        }
    }
}