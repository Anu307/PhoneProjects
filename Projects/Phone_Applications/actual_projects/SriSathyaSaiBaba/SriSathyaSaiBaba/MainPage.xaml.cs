using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Shell;
using Microsoft.Phone.BackgroundAudio;

namespace SriSathyaSaiBaba
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Handle selection changed on ListBox
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (MainListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page

            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
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
            emailcomposetask.Subject = " Feedback for SriSathyaSaiBaba v2.00";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
        }
        private void All_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];

            if (btn.Text == "Select All")
            {

                btn.Text = "Clear All";
                btn.IconUri = new Uri("remove.png", UriKind.Relative);
                foreach (object item in MainListBox.Items)
                {
                    ((ItemViewModel)(item)).Checked = true;
                }
            }
            else if (btn.Text == "Clear All")
            {
                btn.Text = "Select All";
                btn.IconUri = new Uri("check.png", UriKind.Relative);
                foreach (object item in MainListBox.Items)
                {
                    ((ItemViewModel)(item)).Checked = false;
                }

            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            if ((PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState) && BackgroundAudioPlayer.Instance.CanPause)
            {
                BackgroundAudioPlayer.Instance.Stop();
            }

        }
        private void Play_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;

            foreach (object item in MainListBox.Items)
            {

                if (((ItemViewModel)(item)).Checked == true)
                {
                    App.bytes[j] = 1;
                    i++;
                }
                else
                    App.bytes[j] = 0;
                j++;
            }
            if (i == 0)
            {
                MessageBox.Show("Select the bhajans you want to play");
                return;
            }

            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + "test", UriKind.Relative));
        }
    }
}