﻿#pragma checksum "L:\Phone_Applications\actual_projects\SpeakingFairyTales\SpeakingFairyTales\DetailsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "313653C488934BF1BE6E4A86160DC7A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AdDuplex;
using Inneractive.Ad;
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


namespace SpeakingFairyTales {
    
    
    public partial class DetailsPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.WebBrowser MyBrowser;
        
        internal AdDuplex.AdControl AdDuplexAdControl;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl MSAdControlAd1;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl MSAdControlAd2;
        
        internal Inneractive.Ad.InneractiveAd InneractiveXamlAd;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SpeakingFairyTales;component/DetailsPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.MyBrowser = ((Microsoft.Phone.Controls.WebBrowser)(this.FindName("MyBrowser")));
            this.AdDuplexAdControl = ((AdDuplex.AdControl)(this.FindName("AdDuplexAdControl")));
            this.MSAdControlAd1 = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("MSAdControlAd1")));
            this.MSAdControlAd2 = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("MSAdControlAd2")));
            this.InneractiveXamlAd = ((Inneractive.Ad.InneractiveAd)(this.FindName("InneractiveXamlAd")));
        }
    }
}

