﻿#pragma checksum "L:\Phone_Applications\actual_projects\Ek_Omkar\Ek_Omkar\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6C6FCAA05746C5D02D024AD14538B442"
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


namespace Ek_Omkar {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Image Image;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Ek_Omkar;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.Image = ((System.Windows.Controls.Image)(this.FindName("Image")));
            this.AdDuplexAdControl = ((AdDuplex.AdControl)(this.FindName("AdDuplexAdControl")));
            this.MSAdControlAd1 = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("MSAdControlAd1")));
            this.MSAdControlAd2 = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("MSAdControlAd2")));
            this.InneractiveXamlAd = ((Inneractive.Ad.InneractiveAd)(this.FindName("InneractiveXamlAd")));
        }
    }
}

