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

namespace WhatsyourAge
{
    public partial class MainPage : PhoneApplicationPage
    {
        DateTime dtNow;
        DateTime dtBirthday;
        DateTime dtstart;
        string strYears;
        string strMonths;
        string strDays;
        string Absolutedays;
        string AbsoluteHours;
        string AbsoluteMins;
        string Absolutesecs;
        string strMessage;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ShowControls(Visibility.Collapsed);
            this.datePicker.ValueChanged += new EventHandler<DateTimeValueChangedEventArgs>(picker_ValueChanged);
            dtNow = DateTime.Today;
            dtstart = dtBirthday = (DateTime)datePicker.Value;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 45000); // 60 Seconds  
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
            emailcomposetask.Subject = " My Age details";
            emailcomposetask.Body = strMessage + "\n Sent from WhatsYourAge Windows Phone App";
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
            emailcomposetask.Subject = " Feedback for Whats Your Age v1.000";
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

       /* private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ShowControls(Visibility.Collapsed);
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            ShowControls(Visibility.Visible);
            DoCalculations();

        }*/
        private void DoCalculations()
        {
            int daysInBaseMonth = DateTime.DaysInMonth(dtBirthday.Year, dtBirthday.Month);
            int rYears = dtNow.Year - dtBirthday.Year;
            int rMonths = dtNow.Month - dtBirthday.Month;
            if (rMonths < 0)
            {
                rMonths += 12;
                rYears -= 1;//' add 1 year to months, and remove 1 year from years.
            }

            int rDays = dtNow.Day - dtBirthday.Day;
            if (rDays < 0)
            {
                rDays += daysInBaseMonth;
                rMonths -= 1;
            }
            if (rMonths < 0)
            {
                rMonths += 12;
                rYears -= 1;//' add 1 year to months, and remove 1 year from years.
            }
            strYears = rYears.ToString();
            strMonths = rMonths.ToString();
            strDays = rDays.ToString();
            TimeSpan tm = dtNow.Subtract(dtBirthday);
            Absolutedays = tm.Days.ToString();
            AbsoluteHours = (tm.Days * 24).ToString();
            long span = tm.Days * 24 * 60;
            AbsoluteMins = span.ToString();
            span *= 60;
            Absolutesecs = span.ToString();

     /*       long spandays = tm.Days;
            Absolutedays = spandays.ToString();
            long spanhours = spandays * 24;
            AbsoluteHours = spanhours.ToString();
            AbsoluteMins = tm.Minutes.ToString();
            Absolutesecs = tm.Seconds.ToString();*/
          

            Text_Years.Text = strYears;
            Text_Months.Text = strMonths;
            Text_Days.Text = strDays;
            Text_Days_Absolute.Text = Absolutedays;
            Text_Hours_Absolute.Text = AbsoluteHours;
            Text_Minutes_Absolute.Text = AbsoluteMins;
            Text_Seconds_Absolute.Text = Absolutesecs;

            strMessage = "My age is " + strYears + " years " + strMonths + " months and " + strDays +
                                " days. In absolute terms it is " + Absolutedays + " days or "
                                + AbsoluteHours + " hours or " + AbsoluteMins + " minutes or "
                                + Absolutesecs + " secs. Wow!";
                              

        }
        private void ShowControls(Visibility value)
        {
            AgeBox.Visibility = value;
            YearsTextbox.Visibility = value;
            Text_Years.Visibility = value;
            MonthsTextbox.Visibility = value;
            Text_Months.Visibility = value;
            DaysTextbox.Visibility = value;
            Text_Days.Visibility = value;
            YearsTextbox_Absolute.Visibility = value;
            HoursTextbox_Absolute.Visibility = value;
            Text_Hours_Absolute.Visibility = value;
            DaysTextbox_Absolute.Visibility = value;
            Text_Days_Absolute.Visibility = value;
            MinutesTextbox_Absolute.Visibility = value;
            Text_Minutes_Absolute.Visibility = value;
            SecondsTextbox_Absolute.Visibility = value;
            Text_Seconds_Absolute.Visibility = value;
            ApplicationBarIconButton btn1 = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            ApplicationBarIconButton btn2 = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
            ApplicationBarIconButton btn3 = (ApplicationBarIconButton)ApplicationBar.Buttons[2];
                       
            btn1.IsEnabled = btn2.IsEnabled = btn3.IsEnabled= (value==Visibility.Visible);
            

        }

     void picker_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
    {
        ShowControls(Visibility.Collapsed);
        dtBirthday = (DateTime)e.NewDateTime;
        if (dtNow.CompareTo(dtBirthday) < 0)
        {
            MessageBox.Show("Your date of birth is in future, sorry but prediction services are not available");
            dtBirthday = dtstart;
            datePicker.Value = dtBirthday;
            return;
        }
        if (dtNow.CompareTo(dtBirthday) == 0)
        {
            MessageBox.Show("You are just born, keep enjoying!!");
            dtBirthday = dtstart;
            datePicker.Value = dtBirthday;
            return;
        }
        if (dtBirthday.Year < 1900)
        {
            MessageBox.Show("Wow you are more than a 100 years old, why worry at all");
            dtBirthday = dtstart;
            datePicker.Value = dtBirthday;
            return;
        }
        DoCalculations();
        ShowControls(Visibility.Visible);
        /*
          <Button x:Name="Reset" Content="Reset..."  Height="71" Margin="0,202,0,455" Width="158" RenderTransformOrigin="1.281,6.522" FontWeight="Bold" HorizontalAlignment="Left" Click="Reset_Click"/>
        <Button x:Name="Calculate" Content="Calc..."  Height="71" Margin="318,202,0,455" Width="158" RenderTransformOrigin="1.281,6.522" FontWeight="Bold" HorizontalAlignment="Left" Click="Calculate_Click"/>

         */
        // DateTime dtNow = DateTime.Today;
       // dtNow = DateTime.Today;
       // TimeSpan tm = dt.Subtract(dt);
       // TimeSpan tm2 = tm.Duration();
       // int  daysInBaseMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
    
       // int i = tm.Days;
        //int j = dtNow.CompareTo(dt);
        //this.textBlock.Text = date.ToString("d"); 

        


}
 
    

    }
}