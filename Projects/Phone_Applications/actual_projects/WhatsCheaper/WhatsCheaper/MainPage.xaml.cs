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
using System.Windows.Threading;
using Microsoft.Phone.Shell;

namespace WhatsCheaper
{
    public partial class MainPage : PhoneApplicationPage
    {
        SetList[] Setlistarry = new SetList[4];


        string strMessage = "aaa";

        enum mode { weight =0, volume =1, units=2 };

        int selectedmode = (int)(mode.weight);

        // Constructor
        public MainPage()
        {

            InitializeComponent();
            ShowControls((int)(mode.weight));
            WeightRadio.IsChecked = true;
            for (int i = 0; i < 4; i++)
                Setlistarry[i] = new SetList();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 35000); // 35 Seconds  
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

            MSAdControlAd2.Visibility = Visibility.Collapsed;

            AdDuplexAdControl2.Visibility = Visibility.Visible;

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

        private void Email_Click(object sender, EventArgs e)
        {
          
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Deal details";
            emailcomposetask.Body = strMessage + "\n Sent from WhatsCheaper Windows Phone App";
            emailcomposetask.Show();
        }
        private void SMS_Click(object sender, EventArgs e)
        {
            SmsComposeTask smscomposetask = new SmsComposeTask();
            // emailcomposetask.Subject = " Feedback for Discount Calculator v1.00";
            smscomposetask.Body = strMessage ;
            smscomposetask.Show();
        }
        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for WhatsCheaper v1.000";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
        }
        private void Share_Click(object sender, EventArgs e)
        {
            ShareStatusTask sharetask = new ShareStatusTask();
            
            sharetask.Status = strMessage ;
            //sharetask.LinkUri = "";
            sharetask.Show();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DoCalculations()
        {
            for (int i = 0; i < 4; i++)
            {
                Setlistarry[i].ConvertToAbsolute();
            }
           
        }
        private void UpdateValues()
        {
            if ((Qty_1.Text != "") && (Weight_1.Text != "") && (Price_1.Text != ""))
            {
                Setlistarry[0].TextQty = Convert.ToDouble(Qty_1.Text);
                Setlistarry[0].TextWt = Convert.ToDouble(Weight_1.Text);
                Setlistarry[0].TextPrice = Convert.ToDouble(Price_1.Text);
                Setlistarry[0].IsValid = true;
                Setlistarry[0].mode = selectedmode;
                Setlistarry[0].serialnumber = 1;
            }
            else
            {
                Setlistarry[0].IsValid = false;
            }
            if ((Qty_2.Text != "") && (Weight_2.Text != "") && (Price_2.Text != ""))
            {
                Setlistarry[1].TextQty = Convert.ToDouble(Qty_2.Text);
                Setlistarry[1].TextWt = Convert.ToDouble(Weight_2.Text);
                Setlistarry[1].TextPrice = Convert.ToDouble(Price_2.Text);
                Setlistarry[1].IsValid = true;
                Setlistarry[1].mode = selectedmode;
                Setlistarry[1].serialnumber = 2;
            }
            else
            {
                Setlistarry[1].IsValid = false;
            }
            if ((Qty_3.Text != "") && (Weight_3.Text != "") && (Price_3.Text != ""))
            {
                Setlistarry[2].TextQty = Convert.ToDouble(Qty_3.Text);
                Setlistarry[2].TextWt = Convert.ToDouble(Weight_3.Text);
                Setlistarry[2].TextPrice = Convert.ToDouble(Price_3.Text);
                Setlistarry[2].IsValid = true;
                Setlistarry[2].mode = selectedmode;
                Setlistarry[2].serialnumber = 3;
            }
            else
            {
                Setlistarry[2].IsValid = false;
            }
            if ((Qty_4.Text != "") && (Weight_4.Text != "") && (Price_4.Text != ""))
            {
                Setlistarry[3].TextQty = Convert.ToDouble(Qty_4.Text);
                Setlistarry[3].TextWt = Convert.ToDouble(Weight_4.Text);
                Setlistarry[3].TextPrice = Convert.ToDouble(Price_4.Text);
                Setlistarry[3].IsValid = true;
                Setlistarry[3].mode = selectedmode;
                Setlistarry[3].serialnumber = 4;
            }
            else
            {
                Setlistarry[3].IsValid = false;
            }

            if (selectedmode == (int)mode.weight)
            {
                Setlistarry[0].listunits = ((ListPickerItem)Unit_Wt1.SelectedItem).Content.ToString();
                Setlistarry[1].listunits = ((ListPickerItem)Unit_Wt2.SelectedItem).Content.ToString();
                Setlistarry[2].listunits = ((ListPickerItem)Unit_Wt3.SelectedItem).Content.ToString();
                Setlistarry[3].listunits = ((ListPickerItem)Unit_Wt4.SelectedItem).Content.ToString();

            }
            else if (selectedmode == (int)mode.volume)
            {
                Setlistarry[0].listunits = ((ListPickerItem)Unit_V1.SelectedItem).Content.ToString();
                Setlistarry[1].listunits = ((ListPickerItem)Unit_V2.SelectedItem).Content.ToString();
                Setlistarry[2].listunits = ((ListPickerItem)Unit_V3.SelectedItem).Content.ToString();
                Setlistarry[3].listunits = ((ListPickerItem)Unit_V4.SelectedItem).Content.ToString();

            }
        }
        private void ButtonsState(bool isenabled)
        {
            ApplicationBarIconButton btn0 = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            ApplicationBarIconButton btn1 = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
            ApplicationBarIconButton btn2 = (ApplicationBarIconButton)ApplicationBar.Buttons[2];
            btn0.IsEnabled = btn1.IsEnabled = btn2.IsEnabled = isenabled;
        }
        private void FindLeast()
        {
            int j = 0;
            List<SetList> ListElements = new List<SetList>();
            for( int i = 0; i<4; i++)
            {
                if (Setlistarry[i].IsValid)
                {
                   ListElements.Add(Setlistarry[i]);
                    j++;
                }
            }
            if (j == 0)
            {
                App.resultstring = " All the values are invalid, if you are testing the intelligence of the app, it's nowhere near you";
                ButtonsState(false);
            }
                
            else if (j == 1)
            {
                App.resultstring = " Only one valid value and that is the cheapest.\n" +
                                "The cheapest item is thus:\nAt" +
                                ListElements[0].TextPrice.ToString() + "for a set of " +
                                ListElements[0].TextQty.ToString() + " each of " +
                                ListElements[0].TextWt.ToString();
                if(selectedmode!= (int)(mode.units))
                    App.resultstring = App.resultstring +  ListElements[0].listunits;
                ButtonsState(true);                

            }
            else
            {
                ButtonsState(true);
                ListElements.Sort();
                App.resultstring = " Here are the sorted results.\n\n";
                for(int k =0; k<j; k++)
                {
                    App.resultstring = App.resultstring +
                        ListElements[k].TextPrice.ToString() + " for a set of " +
                        ListElements[k].TextQty.ToString() + " each of " +
                        ListElements[k].TextWt.ToString();
                    if (selectedmode != (int)(mode.units))
                        App.resultstring = App.resultstring + ListElements[k].listunits +"\n\n";
                    else
                        App.resultstring = App.resultstring + "\n\n";
                }

            }

            strMessage = App.resultstring;
            
        }

        private void ShowControls(int showmode)
        {
            selectedmode = showmode;
            if (showmode == (int)(mode.weight))
            {
                Unit_Wt1.Visibility = Visibility.Visible;
                Unit_Wt2.Visibility = Visibility.Visible;
                Unit_Wt3.Visibility = Visibility.Visible;
                Unit_Wt4.Visibility = Visibility.Visible;
                Unit_V1.Visibility = Visibility.Collapsed;
                Unit_V2.Visibility = Visibility.Collapsed;
                Unit_V3.Visibility = Visibility.Collapsed;
                Unit_V4.Visibility = Visibility.Collapsed;

                Units.Visibility = Visibility.Visible;
                Weight.Text = "Weight";
                   
            }
            else if (showmode == (int)(mode.volume))
            {
                Unit_V1.Visibility = Visibility.Visible;
                Unit_V2.Visibility = Visibility.Visible;
                Unit_V3.Visibility = Visibility.Visible;
                Unit_V4.Visibility = Visibility.Visible;

                Unit_Wt1.Visibility = Visibility.Collapsed;
                Unit_Wt2.Visibility = Visibility.Collapsed;
                Unit_Wt3.Visibility = Visibility.Collapsed;
                Unit_Wt4.Visibility = Visibility.Collapsed;

                Units.Visibility = Visibility.Visible;
                Weight.Text = "Volume";
                
            }
            else 
            {

                Unit_V1.Visibility = Visibility.Collapsed;
                Unit_V2.Visibility = Visibility.Collapsed;
                Unit_V3.Visibility = Visibility.Collapsed;
                Unit_V4.Visibility = Visibility.Collapsed;

                Unit_Wt1.Visibility = Visibility.Collapsed;
                Unit_Wt2.Visibility = Visibility.Collapsed;
                Unit_Wt3.Visibility = Visibility.Collapsed;
                Unit_Wt4.Visibility = Visibility.Collapsed;

                Units.Visibility = Visibility.Collapsed;
                Weight.Text = "Units";
                
            }
                       

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ShowControls((int)(mode.units));
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            ShowControls((int)(mode.weight));
        
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
           ShowControls((int)(mode.volume));
        
        }

        private void Button_Click_Check(object sender, RoutedEventArgs e)
        {

            UpdateValues();
            DoCalculations();
            FindLeast();
            NavigationService.Navigate(new Uri("/ResultsPage.xaml", UriKind.Relative));  
          
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            Qty_1.Text = "";
            Qty_2.Text = "";
            Qty_3.Text = "";
            Qty_4.Text = "";

            Weight_1.Text = "";
            Weight_2.Text = "";
            Weight_3.Text = "";
            Weight_4.Text = "";

            Price_1.Text = "";
            Price_2.Text = "";
            Price_3.Text = "";
            Price_4.Text = "";
        }

    
 
    

    }
}