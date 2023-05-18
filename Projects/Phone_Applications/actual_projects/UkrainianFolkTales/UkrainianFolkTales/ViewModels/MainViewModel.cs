﻿using System;
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


namespace UkrainianFolkTales
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


            string[] filelist = new string[] { "Ivan the Fool and St Peter", "Oh The Tsar of the Forest", "The Golden Slipper", "The Iron Wolf",
                "The Magic Egg", "The Old Dog", "The Origin of the Mole", "The Serpent Wife", "The Serpent-Tsarevich and His Two Wives", 
                "The Sparrow and the Bush", "The Story of Ivan and the Daughter of the Sun", "The Story of Little Tsar Novishny", 
                "The Story of the Forty First Brother", "The Story of the Unlucky Days", "The Story of the Wind", "The Story of Tremsin",
                "The Story of Unlucky Daniel", "The Straw Ox", "The Three Brothers", "The Tsar and the Angel", "The Two Princes", 
                "The Ungrateful Children and the Old Father", "The Vampire and St Michael", "The Voices at the Window",   "Ivan Golik and the Serpents", "" };
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