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
namespace PasteNumberCall
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //phoneNumberChooserTask = new PhoneNumberChooserTask();

            //phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);

        }

        private void BUTTON_CALL_Click(object sender, RoutedEventArgs e)
        {
       /*     string str = Number.Text;
            int i = 0;
            while (i < str.Length)
            {
                if (str[i] < '0' || (char)str[i] > '9')
                {
                    MessageBox.Show("Use numbers only");
                    return;
                }
                i++;
            }*/
            
            PhoneCallTask phoneCallTask = new PhoneCallTask();
           // phoneCallTask.DisplayName = 
            phoneCallTask.PhoneNumber = Number.Text;
            phoneCallTask.Show();

        }

        private void BUTTON_SMS_Click(object sender, RoutedEventArgs e)
        {
           /* string str = Number.Text;
            int i = 0;
            while (i < str.Length)
            {
                if (str[i] < '0' || (char)str[i] > '9')
                {
                    MessageBox.Show("Use numbers only");
                    return;
                }
                i++;
            }*/
            
            SmsComposeTask smscomposetask = new SmsComposeTask();
            smscomposetask.To = Number.Text;
            smscomposetask.Show();

        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for Quick Number Edit and Call v1.00";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
        }
    }
}