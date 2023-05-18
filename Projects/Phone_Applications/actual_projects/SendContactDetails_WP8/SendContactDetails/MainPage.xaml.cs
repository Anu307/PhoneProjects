using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.UserData;
using Microsoft.Phone.Tasks;
namespace SendContactDetails
{
    
    public partial class MainPage : PhoneApplicationPage
    {
        FilterKind contactFilterKind = FilterKind.None;
        PhoneNumberChooserTask phoneNumberChooserTask;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            name.IsChecked = true;
            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;


            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }
        private void FilterChange(object sender, RoutedEventArgs e)
        {
            String option = ((RadioButton)sender).Name;

            InputScope scope = new InputScope();
            InputScopeName scopeName = new InputScopeName();

            switch (option)
            {
                case "name":
                    contactFilterKind = FilterKind.DisplayName;
                    scopeName.NameValue = InputScopeNameValue.Text;
                    break;

                case "phone":
                    contactFilterKind = FilterKind.PhoneNumber;
                    scopeName.NameValue = InputScopeNameValue.TelephoneNumber;
                    break;

                case "email":
                    contactFilterKind = FilterKind.EmailAddress;
                    scopeName.NameValue = InputScopeNameValue.EmailSmtpAddress;
                    break;

                default:
                    contactFilterKind = FilterKind.None;
                    break;
            }

            scope.Names.Add(scopeName);
            contactFilterString.InputScope = scope;
            contactFilterString.Focus();
        }

        private void SearchContacts_Click(object sender, RoutedEventArgs e)
        {
            if ((contactFilterKind == FilterKind.EmailAddress) && contactFilterString.Text == "")
            {
                MessageBox.Show("Please enter emailid to search for");
                return;
            }

            if ((contactFilterKind == FilterKind.PhoneNumber) && contactFilterString.Text == "")
            {
                MessageBox.Show("Please enter phone number to search for");
                return;

            }

            ContactResultsLabel.Text = "results are loading...";
            ContactResultsData.DataContext = null;

            Contacts cons = new Contacts();

            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);

            cons.SearchAsync(contactFilterString.Text, contactFilterKind, "Contacts Test #1");
        }
        void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            //MessageBox.Show(e.State.ToString());

            try
            {
                //Bind the results to the list box that displays them in the UI
                ContactResultsData.DataContext = e.Results;
            }
            catch (System.Exception)
            {
                //That's okay, no results
            }

            if (ContactResultsData.Items.Count > 0)
            {
                ContactResultsLabel.Text = "results (tap name for details...)";
            }
            else
            {
                ContactResultsLabel.Text = "no results";
            }
        }
        private void ContactResultsData_Tap(object sender, GestureEventArgs e)
        {
            App.con = ((sender as ListBox).SelectedValue as Contact);

            if ((null == App.con) || (null == App.con.DisplayName))
                return;

           // NavigationService.Navigate(new Uri("/Details", UriKind.Relative));
            MyPivot.SelectedIndex = 1;
            this.DataContext = App.con;

            try
            {
                //Try to get a picture of the contact
                BitmapImage img = new BitmapImage();
                img.SetSource(App.con.GetPicture());
                Picture.Source = img;
            }
            catch (Exception)
            {
                //can't get a picture of the contact
            }
            try
            {
                String str = "Name:" + App.con.DisplayName;

                if (App.con.PhoneNumbers.Count() != 0)
                {
                    str = str + " Phones:" + App.con.PhoneNumbers.FirstOrDefault().PhoneNumber;
                }
                //   
                if (App.con.PhoneNumbers.Count() > 1)
                {
                    int i = 1;
                    while (App.con.PhoneNumbers.Count() > i)
                    {
                        str = str + ", ";
                        str = str + App.con.PhoneNumbers.ElementAt(i).PhoneNumber;
                        i++;
                    }
                }
                if (App.con.EmailAddresses.Count() != 0)
                {
                    str = str + " Email Address: " + App.con.EmailAddresses.FirstOrDefault().EmailAddress;
                    if (App.con.EmailAddresses.Count() > 1)
                    {
                        int i = 1;
                        while (App.con.EmailAddresses.Count() > i)
                        {
                            str = str + ", ";
                            str = str + App.con.EmailAddresses.ElementAt(i).EmailAddress;
                            i++;
                        }
                    }
                }
                if (App.con.Companies.Count() != 0)
                {
                    str = str + " Company: " + App.con.Companies.FirstOrDefault().CompanyName;

                }
                if (App.con.Websites.Count() != 0)
                {
                    str = str + " Websites" + App.con.Websites.FirstOrDefault();
                    if (App.con.Websites.Count() > 1)
                    {
                        int i = 1;
                        while (App.con.Websites.Count() > i)
                        {
                            str = str + ", ";
                            str = str + App.con.Websites.ElementAt(i);
                            i++;
                        }
                    }
                }
                if (App.con.Addresses.Count() != 0)
                {
                    str = str + " Address" + App.con.Addresses.FirstOrDefault().PhysicalAddress.AddressLine1 +
                        App.con.Addresses.FirstOrDefault().PhysicalAddress.AddressLine2 +
                        App.con.Addresses.FirstOrDefault().PhysicalAddress.City +
                        App.con.Addresses.FirstOrDefault().PhysicalAddress.CountryRegion;
                    if (App.con.Addresses.Count() > 1)
                    {
                        int i = 1;
                        while (App.con.Addresses.Count() > i)
                        {
                            str = str + ", ";
                            str = str + App.con.Addresses.ElementAt(i).PhysicalAddress.AddressLine1
                                + App.con.Addresses.ElementAt(i).PhysicalAddress.AddressLine2
                                + App.con.Addresses.ElementAt(i).PhysicalAddress.City +
                                App.con.Addresses.ElementAt(i).PhysicalAddress.CountryRegion;
                            i++;
                        }
                    }
                }

                DetailsText.Text = str;
            }
            catch (Exception)
            {
                //can't get a picture of the contact
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Select Contact Button
            phoneNumberChooserTask = new PhoneNumberChooserTask();

            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
            phoneNumberChooserTask.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Email Button
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = "Contact Details for " + App.con.DisplayName;
            emailcomposetask.To = Emailid_text.Text;
            emailcomposetask.Body = DetailsText.Text;
            emailcomposetask.Show();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SmsComposeTask smscomposetask = new SmsComposeTask();
            smscomposetask.To = Phone_text.Text;
            smscomposetask.Body = DetailsText.Text;
            smscomposetask.Show();

        }
        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                //MessageBox.Show("The phone number for " + e.DisplayName + " is " + e.PhoneNumber);
                Phone_text.Text = e.PhoneNumber;
              
            }
            // SmsComposeTask smstask;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for Send Contact Details v1.00";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();


        }

 


    }
}