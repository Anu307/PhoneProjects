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


namespace SriSathyaSaiBaba
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
            this.Items.Add(new ItemViewModel() { LineOne = "Asathoma" });
            this.Items.Add(new ItemViewModel() { LineOne = "AshtotharaSathaNama" });
            this.Items.Add(new ItemViewModel() { LineOne = "AumTatSat" });
            this.Items.Add(new ItemViewModel() { LineOne = "Bhajanbinasukha" });
            this.Items.Add(new ItemViewModel() { LineOne = "Brahmapanam" });
            this.Items.Add(new ItemViewModel() { LineOne = "ChandaKiran" });
            this.Items.Add(new ItemViewModel() { LineOne = "Madhavamurahara" });
            this.Items.Add(new ItemViewModel() { LineOne = "Manasebhajare" });
            this.Items.Add(new ItemViewModel() { LineOne = "Mangalaarthi" });
            this.Items.Add(new ItemViewModel() { LineOne = "Suprabatham" });
                   
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