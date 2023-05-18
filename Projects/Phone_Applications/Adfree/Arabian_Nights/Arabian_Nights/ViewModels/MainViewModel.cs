using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace Arabian_Nights
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
           

         string[] filelist = new string[] {"The Arabian Nights","The Story of the Merchant and the Genius","The Story of the First Old Man and of the Hind","The Story of the Second Old Man",
             "The Story of the Fisherman","The Story of the Greek King and the Physician Douban","The Story of the Husband and the Parrot",
             "The Story of the Vizir Who Was Punished","The Story of the Young King of the Black Isles",
             "The Story of the Three Calenders, Sons of Kings, and of Five Ladies of Bagdad","The Story of the First Calender, Son of a King",
             "The Story of the Second Calender, Son of a King","The Story of the Envious Man and of Him Who Was Envied","The Story of the Third Calender, Son of a King",
             "The Seven Voyages of Sindbad the Sailor","First Voyage","Second Voyage","Third Voyage","Fourth Voyage","Fifth Voyage","Sixth Voyage","Seventh and Last Voyage",
             "The Little Hunchback","The Story of the Barber's Fifth Brother","The Story of the Barber's Sixth Brother","The Adventures of Prince Camaralzaman and the Princess Badoura",
             "Noureddin and the Fair Persian","Aladdin and the Wonderful Lamp","The Adventures of Haroun-al-Rashid","The Story of the Blind Baba- Abdalla",
             "The Story of Sidi-Nouman","The Story of Ali Colia","The Enchanted Horse","The Story of Two Sisters Who Were Jealous of Their Younger Sister", ""};
         int i = 0;
         while (filelist[i] != "")
         {

             this.Items.Add(new ItemViewModel() { LineOne = filelist[i++] });

         }
       /* this.Items.Add(new ItemViewModel() {LineOne="beetle" });
        this.Items.Add(new ItemViewModel() {LineOne="Calendar"});
        this.Items.Add(new ItemViewModel() {LineOne="The Legend"});
        this.Items.Add(new ItemViewModel() {LineOne="Tradition" });
        this.Items.Add(new ItemViewModel() {LineOne="Origin" });
        this.Items.Add(new ItemViewModel() {LineOne="Social Significance" });
        this.Items.Add(new ItemViewModel() {LineOne="Regional Significance" });
        this.Items.Add(new ItemViewModel() {LineOne="Fast Tradition" });
        this.Items.Add(new ItemViewModel() {LineOne="Gifting Tradition"});
        this.Items.Add(new ItemViewModel() {LineOne="Rituals"});
        this.Items.Add(new ItemViewModel() {LineOne="Celebrations"});
        this.Items.Add(new ItemViewModel() {LineOne="Puja Process" });
        this.Items.Add(new ItemViewModel() {LineOne="Vrat Vidhi" });
        this.Items.Add(new ItemViewModel() {LineOne="Vrat Katha" });
        this.Items.Add(new ItemViewModel() {LineOne="Vrat Story" });
        this.Items.Add(new ItemViewModel() {LineOne="Vrat Items" });
        this.Items.Add(new ItemViewModel() {LineOne="Thali Decoration" });
        this.Items.Add(new ItemViewModel() {LineOne="Henna Tradition" });
        this.Items.Add(new ItemViewModel() {LineOne="How to apply Henna" });
        this.Items.Add(new ItemViewModel() {LineOne="Henna Designs" });
        this.Items.Add(new ItemViewModel() {LineOne="Recipes"});
        this.Items.Add(new ItemViewModel() {LineOne="Songs"});*/

        
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}