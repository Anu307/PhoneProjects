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
namespace QuickDialPro
{
    public partial class Detail_Page : PhoneApplicationPage
    {
        PhoneNumberChooserTask phoneNumberChooserTask;
        PhotoChooserTask photoChooserTask;
        String strButtonClicked;
        String strImageClicked;
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
             App.Nicknamesarray[10] = NickName10.Text;
            App.Nicknamesarray[11] = NickName11.Text; 

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
             App.NumbersArray[10] = Number10.Text;
             App.NumbersArray[11] = Number11.Text;

             for (int i = 0; i < 12; i++)
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
            NickName10.Text = App.Nicknamesarray[10];
            NickName11.Text = App.Nicknamesarray[11];

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
            Number10.Text = App.NumbersArray[10];
            Number11.Text = App.NumbersArray[11];

            Button[] ButtonArray = { ButtonImage0, ButtonImage1, ButtonImage2, ButtonImage3, ButtonImage4, ButtonImage5, ButtonImage6, ButtonImage7, ButtonImage8, ButtonImage9, ButtonImage10, ButtonImage11 };
            string[] strFilePath = { "image0.jpg", "image1.jpg", "image2.jpg", "image3.jpg", "image4.jpg", "image5.jpg", "image6.jpg", "image7.jpg", "image8.jpg", "image9.jpg", "image10.jpg", "image11.jpg" };

            for (int i = 0; i < 12; i++)
            {
                try
                {                  
                  using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                  {
                      lock (storage)
                      {
                          if (storage.FileExists(strFilePath[i]))
                          {
                              using (IsolatedStorageFileStream file = storage.OpenFile(strFilePath[i], System.IO.FileMode.Open))
                              {
                                ImageBrush background = new ImageBrush();
                                BitmapImage img = new BitmapImage();
                                img.UriSource = new Uri(file.Name);
                                background.ImageSource = img;
                                ButtonArray[i].Background = background;
                                }
                           }
                         }
                        }
                    }
                catch (Exception)
                {
                    //can't get a picture of the contact
                }


             }

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
                if (strButtonClicked == "1")
                {
                   Number0.Text = e.PhoneNumber;
                   NickName0.Text = e.DisplayName;
                }
                else if (strButtonClicked == "2")
                {
                    Number1.Text = e.PhoneNumber;
                    NickName1.Text = e.DisplayName;
                }
                else if (strButtonClicked == "3")
                {
                    Number2.Text = e.PhoneNumber;
                    NickName2.Text = e.DisplayName;
                }
                else if (strButtonClicked == "4")
                {
                    Number3.Text = e.PhoneNumber;
                    NickName3.Text = e.DisplayName;
                }
                else if (strButtonClicked == "5")
                {
                    Number4.Text = e.PhoneNumber;
                    NickName4.Text = e.DisplayName;
                }
                else if (strButtonClicked == "6")
                {
                    Number5.Text = e.PhoneNumber;
                    NickName5.Text = e.DisplayName;
                }
                else if (strButtonClicked == "7")
                {
                    Number6.Text = e.PhoneNumber;
                    NickName6.Text = e.DisplayName;
                }
                else if (strButtonClicked == "8")
                {
                    Number7.Text = e.PhoneNumber;
                    NickName7.Text = e.DisplayName;
                }
                else if (strButtonClicked == "9")
                {
                    Number8.Text = e.PhoneNumber;
                    NickName8.Text = e.DisplayName;
                }
                else if (strButtonClicked == "10")
                {
                    Number9.Text = e.PhoneNumber;
                    NickName9.Text = e.DisplayName;
                }
                else if (strButtonClicked == "11")
                {
                    Number10.Text = e.PhoneNumber;
                    NickName10.Text = e.DisplayName;
                }
                else if (strButtonClicked == "12")
                {
                    Number11.Text = e.PhoneNumber;
                    NickName11.Text = e.DisplayName;
                }

            }
            // SmsComposeTask smstask;

        }

        private void ButtonImage_Click(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;
            strImageClicked = but.Content.ToString();

            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
            photoChooserTask.Show();
        }
        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                int buttonid = Convert.ToInt32(strImageClicked) - 1;
                string[] strFilePath = { "image0.jpg", "image1.jpg", "image2.jpg", "image3.jpg", "image4.jpg", "image5.jpg", "image6.jpg", "image7.jpg", "image8.jpg", "image9.jpg", "image10.jpg", "image11.jpg" };
                Button[] ButtonArray = {ButtonImage0, ButtonImage1,ButtonImage2,ButtonImage3,ButtonImage4,ButtonImage5,ButtonImage6,ButtonImage7,ButtonImage8,ButtonImage9,ButtonImage10,ButtonImage11};

                
                System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                        
                ImageBrush background = new ImageBrush();
                background.ImageSource = bmp;
                ButtonArray[buttonid].Background = background;
                using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    lock (storage)
                    {
                        if (storage.FileExists(strFilePath[buttonid]))
                        {
                            storage.DeleteFile(strFilePath[buttonid]);
                        }
                        IsolatedStorageFileStream fileStream = storage.CreateFile(strFilePath[buttonid]);
                        Image image = new Image();
                        image.Source = bmp;
                        image.Width = 156;
                        image.Height = 156;
                        WriteableBitmap wb1 = new WriteableBitmap(image, null);
                        Extensions.SaveJpeg(wb1, fileStream, 156, 156, 0, 100);
                        fileStream.Close();
                    }

                }
                              
            }
        }

    }
}