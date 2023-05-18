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


namespace RussianFolkTales
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


            string[] filelist = new string[] {"BabaYaga", "Crimson Flower", "Daughter and Stepdaughter", 
                                                "Emelya and the Pike", "Father Frost", "Fenist the Bright Falcon",
                                                "Flying Ship","Fox, Hare and Cock", "Golden Fish", "Golden Mountain",
                                                "Ivan Tsarevitch and the Grey Wolf", "Ivanushka the Simpleton",  
                                                 "Little Snow Girl", "Little Straw Bull", "Magic Ring","Magic Wild Geese",
                                                  "Maria Morevna", "Morozko", "Pea-Roll", "Sadko", "Silver Hoof",
                                                "Sirko", "Sister Alyonushka and Brother Ivanushka", "Sister Fox and Brother Wolf", 
                                                "Sivka Burka", "SnowMaiden", "Stone Flower", "Teremok (Little Hut)", "Teryosha",
                                                "The Apples of Youth and the Living", "The Cat and the Rooster",
                                                "The death of Koshchei the Deathless", "The Fire-Bird and Princess Vassilissa",
                                                "The Fly's Castle", "The Golden Hair", "The Princess Frog", "Twelve Months", ""};
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