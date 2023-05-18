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


namespace QuotesnQuotes
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


           /* string[] filelist = new string[] { "Androcles", "Avaricious and Envious", "Belling the Cat", "Hercules and the Waggoneer", "The Ant and the Grasshopper", "The Ass and the Lapdog",
                "The Ass in the Lion's Skin", "The Ass's Brains", "The Bald Man and the Fly", "The Bat, the Birds, and the Beasts", "The Belly and the Members", "The Buffoon and the Countryman",
                "The Bundle of Sticks", "The Cat-Maiden", "The Cock and the Pearl", "The Crow and the Pitcher", "The Dog and the Shadow", "The Dog and the Wolf", "The Dog in the Manger",
                "The Eagle and the Arrow", "The Fisher and the Little Fish", "The Fisher", "The Four Oxen and the Lion", "The Fox and the Cat", "The Fox and the Crow", "The Fox and the Goat", 
                "The Fox and the Grapes", "The Fox and the Mask", "The Fox and the Mosquitoes", "The Fox and the Stork", "The Fox Without a Tail", "The Fox, the Cock, and the Dog",
                "The Frog and the Ox", "The Frogs Desiring a King", "The Goose With the Golden Eggs", "The Hare and the Tortoise", "The Hare With Many Friends", "The Hares and the Frogs",
                "The Hart and the Hunter", "The Hart in the Ox-Stall", "The Horse and the Ass", "The Horse, Hunter, and Stag", "The Jay and the Peacock", "The Labourer and the Nightingale",
                "The Lion and the Mouse", "The Lion and the Statue", "The Lion in Love", "The Lion's Share", "The Lion, the Fox, and the Beasts", "The Man and His Two Wives", 
                "The Man and the Satyr", "The Man and the Serpent", "The Man and the Wood", "The Man and the Wooden God", "The Man, the Boy, and the Donkey", "The Milkmaid and Her Pail",
                "The Miser and His Gold", "The Mountains in Labour", "The Nurse and the Wolf", "The Old Man and Death", "The Old Woman and the Wine-Jar", "The One-Eyed Doe",
                "The Peacock and Juno", "The Serpent and the File", "The Shepherd's Boy", "The Sick Lion", "The Swallow and the Other Birds", "The Tortoise and the Birds",
                "The Town Mouse and the Country Mouse", "The Tree and the Reed", "The Trumpeter Taken Prisoner", "The Two Crabs", "The Two Fellows and the Bear", "The Two Pots",
                "The Wind and the Sun", "The Wolf and the Crane", "The Wolf and the Kid", "The Wolf and the Lamb", "The Wolf in Sheep's Clothing", "The Woodsman and the Serpent",
                "The Young Thief and His Mother", "" };
         int i = 0;
         while (filelist[i] != "")
         {

             this.Items.Add(new ItemViewModel() { LineOne = filelist[i++] });

         }*/
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