﻿#pragma checksum "I:\Phone_Applications\Developing\WhatsyourAge\Backup\WhatsyourAge\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EC39E3ADB9B6F231D184B0ED5FEC03AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AdDuplex;
using Microsoft.Advertising.Mobile.UI;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WhatsyourAge {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.Button Reset;
        
        internal System.Windows.Controls.Button Calculate;
        
        internal System.Windows.Controls.TextBlock TitleBlock;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl MSAdControlAd1;
        
        internal AdDuplex.AdControl AdDuplexAdControl1;
        
        internal Microsoft.Phone.Controls.DatePicker datePicker;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl MSAdControlAd2;
        
        internal AdDuplex.AdControl AdDuplexAdControl2;
        
        internal System.Windows.Controls.TextBlock AgeBox;
        
        internal System.Windows.Controls.TextBlock YearsTextbox;
        
        internal System.Windows.Controls.TextBlock Text_Years;
        
        internal System.Windows.Controls.TextBlock MonthsTextbox;
        
        internal System.Windows.Controls.TextBlock Text_Months;
        
        internal System.Windows.Controls.TextBlock DaysTextbox;
        
        internal System.Windows.Controls.TextBlock Text_Days;
        
        internal System.Windows.Controls.TextBlock YearsTextbox_Absolute;
        
        internal System.Windows.Controls.TextBlock HoursTextbox_Absolute;
        
        internal System.Windows.Controls.TextBlock Text_Hours_Absolute;
        
        internal System.Windows.Controls.TextBlock DaysTextbox_Absolute;
        
        internal System.Windows.Controls.TextBlock Text_Days_Absolute;
        
        internal System.Windows.Controls.TextBlock MinutesTextbox_Absolute;
        
        internal System.Windows.Controls.TextBlock Text_Minutes_Absolute;
        
        internal System.Windows.Controls.TextBlock SecondsTextbox_Absolute;
        
        internal System.Windows.Controls.TextBlock Text_Seconds_Absolute;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/WhatsyourAge;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.Reset = ((System.Windows.Controls.Button)(this.FindName("Reset")));
            this.Calculate = ((System.Windows.Controls.Button)(this.FindName("Calculate")));
            this.TitleBlock = ((System.Windows.Controls.TextBlock)(this.FindName("TitleBlock")));
            this.MSAdControlAd1 = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("MSAdControlAd1")));
            this.AdDuplexAdControl1 = ((AdDuplex.AdControl)(this.FindName("AdDuplexAdControl1")));
            this.datePicker = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("datePicker")));
            this.MSAdControlAd2 = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("MSAdControlAd2")));
            this.AdDuplexAdControl2 = ((AdDuplex.AdControl)(this.FindName("AdDuplexAdControl2")));
            this.AgeBox = ((System.Windows.Controls.TextBlock)(this.FindName("AgeBox")));
            this.YearsTextbox = ((System.Windows.Controls.TextBlock)(this.FindName("YearsTextbox")));
            this.Text_Years = ((System.Windows.Controls.TextBlock)(this.FindName("Text_Years")));
            this.MonthsTextbox = ((System.Windows.Controls.TextBlock)(this.FindName("MonthsTextbox")));
            this.Text_Months = ((System.Windows.Controls.TextBlock)(this.FindName("Text_Months")));
            this.DaysTextbox = ((System.Windows.Controls.TextBlock)(this.FindName("DaysTextbox")));
            this.Text_Days = ((System.Windows.Controls.TextBlock)(this.FindName("Text_Days")));
            this.YearsTextbox_Absolute = ((System.Windows.Controls.TextBlock)(this.FindName("YearsTextbox_Absolute")));
            this.HoursTextbox_Absolute = ((System.Windows.Controls.TextBlock)(this.FindName("HoursTextbox_Absolute")));
            this.Text_Hours_Absolute = ((System.Windows.Controls.TextBlock)(this.FindName("Text_Hours_Absolute")));
            this.DaysTextbox_Absolute = ((System.Windows.Controls.TextBlock)(this.FindName("DaysTextbox_Absolute")));
            this.Text_Days_Absolute = ((System.Windows.Controls.TextBlock)(this.FindName("Text_Days_Absolute")));
            this.MinutesTextbox_Absolute = ((System.Windows.Controls.TextBlock)(this.FindName("MinutesTextbox_Absolute")));
            this.Text_Minutes_Absolute = ((System.Windows.Controls.TextBlock)(this.FindName("Text_Minutes_Absolute")));
            this.SecondsTextbox_Absolute = ((System.Windows.Controls.TextBlock)(this.FindName("SecondsTextbox_Absolute")));
            this.Text_Seconds_Absolute = ((System.Windows.Controls.TextBlock)(this.FindName("Text_Seconds_Absolute")));
        }
    }
}

