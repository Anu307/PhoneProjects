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

namespace QuotesnQuotes
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
            (App.Current as App).rateReminder.Notify();
        }

        // Handle selection changed on ListBox
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
          //  if (MainListBox.SelectedIndex == -1)
              //  return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" , UriKind.Relative));

            // Reset selected index to -1 (no selection)
          //  MainListBox.SelectedIndex = -1;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
            for (int i = 0; i < 621; i++)
            {
                if (App.favoritesetting[i] == '1')
                {
                    Favbutton.IsEnabled = true;
                    return;
                }
            }
            Favbutton.IsEnabled = false;
        }
        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            //  emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Subject = " Feedback for Talking Stories v2.000";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
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

        private void Read_QuotesfromStart(object sender, RoutedEventArgs e)
        {
            App.lastquotepage = 0;
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedMode=Regular", UriKind.Relative));
            

        }

        private void Read_QuotesfromLasttime(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedMode=Regular" , UriKind.Relative));

        }

        private void Read_Quotesfavorite(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedMode=favorite", UriKind.Relative));

        }

        private void Read_Quotesrandom(object sender, RoutedEventArgs e)
        {
            Random rnd1 = new Random();
            int i = rnd1.Next(622);
            App.lastquotepage =i;
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedMode=regular" , UriKind.Relative));

        }

        private void ColorSetting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ColorSettings.xaml", UriKind.Relative));

        }

    }
}