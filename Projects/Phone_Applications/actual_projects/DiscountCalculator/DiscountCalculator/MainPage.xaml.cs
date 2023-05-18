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
using Microsoft.Phone.Shell;
namespace DiscountCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        string strMessage ;
        private void Calculate(object sender, KeyEventArgs e)
        {   
        

    


        }
        private void Email_Click (object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Discount details";
            emailcomposetask.Body = strMessage;
            emailcomposetask.Show();
        }
        private void SMS_Click(object sender, EventArgs e)
        {
            SmsComposeTask smscomposetask = new SmsComposeTask();
           // emailcomposetask.Subject = " Feedback for Discount Calculator v1.00";
            smscomposetask.Body = strMessage;
            smscomposetask.Show();
        }
        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for Discount Calculator v1.001";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Price.Text = "";
            Discount.Text = "";
            SDiscount.Text = "";
            FinalPrice.Text = "";
            Savings.Text = "";
               
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            strMessage = "Savings worth ";
            double price, discount, secondarydisc, finalprice;
            if (Price.Text == "")
            {
                MessageBox.Show("Please enter the tag price");
                return;
            }
            price = Convert.ToDouble(Price.Text);

            if (price == 0.0)
            {
                MessageBox.Show("Zero tag price means it is free");
                return;
            }

            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            ApplicationBarIconButton btn1 = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
            btn.IsEnabled = true;
            btn1.IsEnabled = true;

            if (FinalPrice.Text != "")
            {
                finalprice = Convert.ToDouble(FinalPrice.Text);
                if (finalprice > price)
                {
                    MessageBox.Show("You have paid more and not discount");
                    return;
                }
                discount = (finalprice / price) *100.0;
                discount = 100.0- discount;
                Discount.Text = Convert.ToString(discount);
                SDiscount.Text = "0";
                Savings.Text = Convert.ToString(price - finalprice);

                strMessage = strMessage + Savings.Text + ".Tag price is " + price + " with a discount of " + discount + "% and final price equals " + finalprice;
                
                return;
            }
            if (Discount.Text == "")
            {
                MessageBox.Show("Please enter some discount percentage");
                return;
            }
            discount = Convert.ToDouble(Discount.Text);
            if (SDiscount.Text != "")
            {
                secondarydisc = Convert.ToDouble(SDiscount.Text);
            }
            else
                secondarydisc = 0.0;


            if ((discount > 100) || (secondarydisc > 100))
            {
                MessageBox.Show(" No one can offer more than 100% discount");
            }

            finalprice = price / 100.0;
            finalprice = finalprice * (100.0 - discount);

            finalprice = finalprice / 100.0;
            finalprice = finalprice * (100.0 - secondarydisc);

            FinalPrice.Text = Convert.ToString(finalprice);
            Savings.Text = Convert.ToString(price - finalprice);

            strMessage  = strMessage + Savings.Text +".Tag price of " + price +" comes at  final price of " + finalprice +". Discount of "  + discount +" %";

            if (secondarydisc != 0.0)
            {
                strMessage = strMessage + " and an additional discount of " + secondarydisc + " %";
            }
                 
                

        }
    }
}