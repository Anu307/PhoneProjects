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


namespace SpeakingFairyTales
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


            string[] filelist = new string[] {  "The Bronze Ring","Prince Hyacinth and the Dear Little Princess","East of the Sun and West of the Moon", 
                "The Yellow Dwarf","Little Red Riding Hood","The Sleeping Beauty in the Wood","Cinderella, or the Little Glass Slipper","Aladdin and the Wonderful Lamp",
                "The Tale of a Youth Who Set Out to Learn what Fear Was","Rumpelstiltzkin","Beauty and the Beast","The Master-Maid","Why the Sea is Salt",
                "The Master Cat; or, Puss in Boots","The White Cat","The Water-Lily The Gold-Spinners","The Terrible Head",
                "The Story of Pretty Goldilocks","The History of Whittington","The Wonderful Sheep","Little Thumb","The Forty Thieves","Hansel and Grettel","Snow-White and Rose-Red",
                "The Goose-Girl","Toads and Diamonds","Prince Darling","Blue Beard","Trusty John","The Brave Little Tailor","A Voyage to Lilliput - CHAPTER I",
                "A Voyage to Lilliput - CHAPTER II","A Voyage to Lilliput - CHAPTER III","A Voyage to Lilliput - CHAPTER IV","A Voyage to Lilliput - CHAPTER V",
                "The Princess on the Glass Hill","The Story of Prince Ahmed and the Fairy Paribanou","The History of Jack the Giant-Killer","The Black Bull of Norroway",
                "The Red Etin", ""};
         int i = 0;
         while (filelist[i] != "")
         {

             this.Items.Add(new ItemViewModel() { LineOne = filelist[i++] });

         }
       /* this.Items.Add(new ItemViewModel() {LineOne="beetle"});
        this.Items.Add(new ItemViewModel() {LineOne="Calendar"});
        this.Items.Add(new ItemViewModel() {LineOne="The Legend"});
        this.Items.Add(new ItemViewModel() {LineOne="Tradition"});
        this.Items.Add(new ItemViewModel() {LineOne="Origin"});
        this.Items.Add(new ItemViewModel() {LineOne="Social Significance"});
        this.Items.Add(new ItemViewModel() {LineOne="Regional Significance"});
        this.Items.Add(new ItemViewModel() {LineOne="Fast Tradition"});
        this.Items.Add(new ItemViewModel() {LineOne="Gifting Tradition"});
        this.Items.Add(new ItemViewModel() {LineOne="Rituals"});
        this.Items.Add(new ItemViewModel() {LineOne="Celebrations"});
        this.Items.Add(new ItemViewModel() {LineOne="Puja Process"});
        this.Items.Add(new ItemViewModel() {LineOne="Vrat Vidhi"});
        this.Items.Add(new ItemViewModel() {LineOne="Vrat Katha"});
        this.Items.Add(new ItemViewModel() {LineOne="Vrat Story"});
        this.Items.Add(new ItemViewModel() {LineOne="Vrat Items"});
        this.Items.Add(new ItemViewModel() {LineOne="Thali Decoration"});
        this.Items.Add(new ItemViewModel() {LineOne="Henna Tradition"});
        this.Items.Add(new ItemViewModel() {LineOne="How to apply Henna"});
        this.Items.Add(new ItemViewModel() {LineOne="Henna Designs"});
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