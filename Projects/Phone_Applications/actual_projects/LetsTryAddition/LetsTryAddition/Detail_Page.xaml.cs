using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
namespace LetsTryAddition
{
    public partial class Detail_Page : PhoneApplicationPage
    {

        int correctAnswer;
        int serialnumber;
        Random rand1;
        bool tried;
        public Detail_Page()
        {
            App.score = 0;
            serialnumber = 0;
            tried = false;
            rand1 = new Random(App.leastnumber);

            InitializeComponent();
            App.resultstring = "Correct Answers are:\n";
            SetLayout(false);
          

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

        private void Cancel_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
        private void SetLayout(bool retry)
        {
            int num1, num2;
            
            if (!retry)
            {
                OperationImage.Source = new BitmapImage(new Uri("images/sign" + App.operation + ".png", UriKind.RelativeOrAbsolute));
                string stroperand ="";
                num1 = rand1.Next();
                if (num1 > App.maxnumber)
                    num1 %= App.maxnumber;
                num2 = rand1.Next();
                if (num2 > App.maxnumber)
                    num2 %= App.maxnumber;
                if (App.operation == "add")
                {
                    correctAnswer = num1 + num2;
                    stroperand = " + ";
                }
                else if (App.operation == "subtract")
                {
                    if (num1 < num2)
                    {
                        num1 = num1 + num2;
                        num2 = num1 - num2;
                        num1 = num1 - num2;
                    }
                    correctAnswer = num1 - num2;
                    stroperand = " - ";
                }
                else if (App.operation == "mult")
                {
                    correctAnswer = num1 * num2;
                    stroperand = " x ";
                }
                else if (App.operation == "divide")
                {
                    num2 %= 13;
                    if (num1 < num2)
                    {
                        num1 = num1 + num2;
                        num2 = num1 - num2;
                        num1 = num1 - num2;
                    }
                    if (num2 == 0)
                        num2 += 2;
                    correctAnswer = num1 / num2;
                    stroperand = " / ";
                }

                FirstNumber.Text = num1.ToString();
                //   FirstNumber.Visibility = Visibility.Visible;
                SecondNumber.Text = num2.ToString();
                //  SecondNumber.Visibility = Visibility.Visible;

                App.resultstring = App.resultstring + num1.ToString() + stroperand + num2.ToString() + " = " + correctAnswer.ToString() + "\n";

                Result.Text = "";

                int resultnum = rand1.Next() % 3;
                if (resultnum == 0)
                {

                    Result1.Content = correctAnswer.ToString();
                    Result2.Content = (correctAnswer + 3).ToString();
                    Result3.Content = (correctAnswer + 5).ToString();
                }
                else if (resultnum == 1)
                {
                    Result1.Content = (correctAnswer + 4).ToString();
                    Result2.Content = correctAnswer.ToString();
                    Result3.Content = (correctAnswer + 6).ToString();
                }
                else
                {
                    Result1.Content = (correctAnswer + 2).ToString();
                    Result2.Content = (correctAnswer + 7).ToString();
                    Result3.Content = correctAnswer.ToString();
                }
                CorrectorWrong.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                serialnumber++;

                Caption.Text = serialnumber.ToString() + " of " + App.iterations.ToString();
                tried = false;
            }

                       
           // Again.Visibility = Visibility.Collapsed;
           // Skip.Visibility = Visibility.Collapsed;

          
        }
        private void ChangeLayout(string str)
        {
            if ( str == correctAnswer.ToString())
            {
                CorrectorWrong.Source = new BitmapImage(new Uri("images/signcorrect.png", UriKind.RelativeOrAbsolute));
                Result.Text = correctAnswer.ToString();
               // Again.Visibility = Visibility.Collapsed;
                // Skip.Visibility = Visibility.Collapsed;
                if (serialnumber == App.iterations)
                {
                    Skip.Content = "Result";
                }
                else
                {
                    Skip.Content = "Next->";
                  
                }
                if (!tried)
                {
                    App.score++;
                    Score.Text = "Score:  " + App.score.ToString();
                }
                //serialnumber++;
            }
            else
            {
                CorrectorWrong.Source = new BitmapImage(new Uri("images/signwrong.png", UriKind.RelativeOrAbsolute));
                Result.Text = "";
               // Again.Visibility = Visibility.Visible;
                Skip.Visibility = Visibility.Visible;
                Skip.Content = "Skip>>";
                SetLayout(true);
                tried = true;
            }
        }

        private void Result3_Click(object sender, RoutedEventArgs e)
        {
            ChangeLayout(Result3.Content.ToString());
        }

        private void Result2_Click(object sender, RoutedEventArgs e)
        {
            ChangeLayout(Result2.Content.ToString());
        }

        private void Result1_Click(object sender, RoutedEventArgs e)
        {
            ChangeLayout(Result1.Content.ToString());
        }

        private void Skip_Click(object sender, RoutedEventArgs e)
        {

            if(Skip.Content.ToString() == "Result")
            {
                NavigationService.Navigate(new Uri("/ResultsPage.xaml", UriKind.Relative));

            }
            else 
            {
                if (serialnumber == App.iterations)
                {
                    Skip.Content = "Result";
                    return;
                }
                SetLayout(false);
                Skip.Content = "Skip>>";         
      
            }
        }

        private void Again_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}