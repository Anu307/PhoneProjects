using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace QuickDialer
{
    public partial class Detail_Page : PhoneApplicationPage
    {
        PhoneNumberChooserTask phoneNumberChooserTask;
        String strButtonClicked;
        //AppSettings settings = new AppSettings();
       
        public Detail_Page()
        {
            InitializeComponent();
            UpdateFields();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Save_Click(object sender, EventArgs e)
        {

                  
           /* App.settings.AddOrUpdateValue("Nickname1Setting", NickName1.Text);
            App.settings.AddOrUpdateValue("Nickname2Setting", NickName2.Text);
            App.settings.AddOrUpdateValue("Nickname3Setting", NickName3.Text);
            App.settings.AddOrUpdateValue("Nickname4Setting", NickName4.Text);
            App.settings.AddOrUpdateValue("Nickname5Setting", NickName5.Text);
            App.settings.AddOrUpdateValue("Nickname6Setting", NickName6.Text);
            App.settings.AddOrUpdateValue("Nickname7Setting", NickName7.Text);
            App.settings.AddOrUpdateValue("Nickname8Setting", NickName8.Text);
            App.settings.AddOrUpdateValue("Nickname9Setting", NickName9.Text);

            App.settings.AddOrUpdateValue("Number0Setting", Number0.Text);
            App.settings.AddOrUpdateValue("Number1Setting", Number1.Text);
            App.settings.AddOrUpdateValue("Number2Setting", Number2.Text);
            App.settings.AddOrUpdateValue("Number3Setting", Number3.Text);
            App.settings.AddOrUpdateValue("Number4Setting", Number4.Text);
            App.settings.AddOrUpdateValue("Number5Setting", Number5.Text);
            App.settings.AddOrUpdateValue("Number6Setting", Number6.Text);
            App.settings.AddOrUpdateValue("Number7Setting", Number7.Text);
            App.settings.AddOrUpdateValue("Number8Setting", Number8.Text);*/
           


             App.Nicknamesarray[0] = NickName0.Text ; 
             App.Nicknamesarray[1] = NickName1.Text ; 
             App.Nicknamesarray[2] = NickName2.Text ; 
             App.Nicknamesarray[3] = NickName3.Text ; 
             App.Nicknamesarray[4] = NickName4.Text ; 
             App.Nicknamesarray[5] = NickName5.Text ; 
             App.Nicknamesarray[6] = NickName6.Text ; 
             App.Nicknamesarray[7] = NickName7.Text ; 
             App.Nicknamesarray[8] = NickName8.Text ; 
             App.Nicknamesarray[9] = NickName9.Text ; 


             App.NumbersArray[0] =  Number0.Text ; 
             App.NumbersArray[1] =  Number1.Text ; 
             App.NumbersArray[2] =  Number2.Text ; 
             App.NumbersArray[3] =  Number3.Text ; 
             App.NumbersArray[4] =  Number4.Text ; 
             App.NumbersArray[5] =  Number5.Text ; 
             App.NumbersArray[6] =  Number6.Text ; 
             App.NumbersArray[7] =  Number7.Text ; 
             App.NumbersArray[8] =  Number8.Text ; 
             App.NumbersArray[9] =  Number9.Text ;

             for (int i = 0; i < 10; i++)
             {
                 App.settings.AddOrUpdateValue("Nickname" +i+ "Setting", App.Nicknamesarray[i]);
                 App.settings.AddOrUpdateValue("Number" +i+"Setting", App.NumbersArray[i]);
             }
             NavigationService.GoBack();
        }
        private void UpdateFields()
        {
            NickName0.Text = App.Nicknamesarray[0];
            NickName1.Text = App.Nicknamesarray[1];
            NickName2.Text = App.Nicknamesarray[2];
            NickName3.Text = App.Nicknamesarray[3];
            NickName4.Text = App.Nicknamesarray[4];
            NickName5.Text = App.Nicknamesarray[5];
            NickName6.Text = App.Nicknamesarray[6];
            NickName7.Text = App.Nicknamesarray[7];
            NickName8.Text = App.Nicknamesarray[8];
            NickName9.Text = App.Nicknamesarray[9];


            Number0.Text = App.NumbersArray[0];
            Number1.Text = App.NumbersArray[1];
            Number2.Text = App.NumbersArray[2];
            Number3.Text = App.NumbersArray[3];
            Number4.Text = App.NumbersArray[4];
            Number5.Text = App.NumbersArray[5];
            Number6.Text = App.NumbersArray[6];
            Number7.Text = App.NumbersArray[7];
            Number8.Text = App.NumbersArray[8];
            Number9.Text = App.NumbersArray[9];


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Select Contact Button
            
            Button but = (Button)sender;
            strButtonClicked= but.Content.ToString();
           // iButtonClicked = str;
            phoneNumberChooserTask = new PhoneNumberChooserTask();

            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
            phoneNumberChooserTask.Show();

        }
        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {

               // MessageBox.Show("The phone number for " + e.DisplayName + " is " + e.PhoneNumber+ "and button id is" + strButtonClicked);
                if (strButtonClicked == "0")
                {
                   Number0.Text = e.PhoneNumber;
                   NickName0.Text = e.DisplayName;
                }
                else if (strButtonClicked == "1")
                {
                    Number1.Text = e.PhoneNumber;
                    NickName1.Text = e.DisplayName;
                }
                else if (strButtonClicked == "2")
                {
                    Number2.Text = e.PhoneNumber;
                    NickName2.Text = e.DisplayName;
                }
                else if (strButtonClicked == "3")
                {
                    Number3.Text = e.PhoneNumber;
                    NickName3.Text = e.DisplayName;
                }
                else if (strButtonClicked == "4")
                {
                    Number4.Text = e.PhoneNumber;
                    NickName4.Text = e.DisplayName;
                }
                else if (strButtonClicked == "5")
                {
                    Number5.Text = e.PhoneNumber;
                    NickName5.Text = e.DisplayName;
                }
                else if (strButtonClicked == "6")
                {
                    Number6.Text = e.PhoneNumber;
                    NickName6.Text = e.DisplayName;
                }
                else if (strButtonClicked == "7")
                {
                    Number7.Text = e.PhoneNumber;
                    NickName7.Text = e.DisplayName;
                }
                else if (strButtonClicked == "8")
                {
                    Number8.Text = e.PhoneNumber;
                    NickName8.Text = e.DisplayName;
                }
                else if (strButtonClicked == "9")
                {
                    Number9.Text = e.PhoneNumber;
                    NickName9.Text = e.DisplayName;
                }

            }
            // SmsComposeTask smstask;

        }
    }
}