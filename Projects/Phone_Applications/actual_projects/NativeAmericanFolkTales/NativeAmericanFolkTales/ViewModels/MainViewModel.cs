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


namespace NativeAmericanFolkTales
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


            string[] filelist = new string[] { "Dance in a buffalo skull", "Ermine and the Hunter", "Great Heart and the Three Tests", "How Glooskap Made the Birds",
                "How Rabbit Deceived Fox", "How Raven Brought Fire to the Indians", "Iktomi and the coyote", "Iktomi and the ducks", "Iktomi and the fawn", "Iktomi and the muskrat",
                "Iktomi and the turtle", "Iktomi's blanket", "Iya, the camp-eater", "Manstin, the rabbit", "Owl with the Great Head and Eyes", "Rabbit and the Grain Buyers", 
                "Rabbit and the Indian Chief", "Rabbit and the Moon", "Rainbow and the Autumn Leaves", "Saint Nicholas and the Children", "Shooting of the red eagle",
                "Sparrow's Search for the Rain", "The badger and the bear", "The Boy and the Dragon", "The Boy in the Land of Shadows", "The Boy of the Red Twilight Sky", 
                "The Boy who Overcame the Giants", "The Boy who was Called Thick-head", "The Boy who was Saved by Thoughts", "The Children with One Eye", 
                "The Cruel Stepmother", "The Fall of the Spider Man", "The Giant with the Grey Feathers", "The Girl who Always Cried", "The toad and the boy", 
                "The Tobacco Fairy from the Blue Hills", "The tree-bound", "The warlike seven", "The Youth and the Dog-Dance", "The Youth and the Dog", "" };
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