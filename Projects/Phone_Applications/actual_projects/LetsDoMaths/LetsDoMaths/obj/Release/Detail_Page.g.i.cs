﻿#pragma checksum "I:\Phone_Applications\Developing\LetsDoMaths\LetsDoMaths\Detail_Page.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8B6FBB02BB0973B9E3DD6401E0516A01"
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


namespace LetsDoMaths {
    
    
    public partial class Detail_Page : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.ScrollViewer LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Image OperationImage;
        
        internal System.Windows.Controls.Image Equalsign;
        
        internal System.Windows.Controls.Button Result3;
        
        internal System.Windows.Controls.Button Result2;
        
        internal System.Windows.Controls.Button Result1;
        
        internal System.Windows.Controls.Button Skip;
        
        internal System.Windows.Controls.Image CorrectorWrong;
        
        internal System.Windows.Controls.TextBlock Score;
        
        internal System.Windows.Controls.TextBlock FirstNumber;
        
        internal System.Windows.Controls.TextBlock SecondNumber;
        
        internal System.Windows.Controls.TextBlock Result;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl MSAdControlAd1;
        
        internal AdDuplex.AdControl AdDuplexAdControl1;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl MSAdControlAd2;
        
        internal AdDuplex.AdControl AdDuplexAdControl2;
        
        internal System.Windows.Controls.TextBlock Caption;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LetsDoMaths;component/Detail_Page.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.ScrollViewer)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.OperationImage = ((System.Windows.Controls.Image)(this.FindName("OperationImage")));
            this.Equalsign = ((System.Windows.Controls.Image)(this.FindName("Equalsign")));
            this.Result3 = ((System.Windows.Controls.Button)(this.FindName("Result3")));
            this.Result2 = ((System.Windows.Controls.Button)(this.FindName("Result2")));
            this.Result1 = ((System.Windows.Controls.Button)(this.FindName("Result1")));
            this.Skip = ((System.Windows.Controls.Button)(this.FindName("Skip")));
            this.CorrectorWrong = ((System.Windows.Controls.Image)(this.FindName("CorrectorWrong")));
            this.Score = ((System.Windows.Controls.TextBlock)(this.FindName("Score")));
            this.FirstNumber = ((System.Windows.Controls.TextBlock)(this.FindName("FirstNumber")));
            this.SecondNumber = ((System.Windows.Controls.TextBlock)(this.FindName("SecondNumber")));
            this.Result = ((System.Windows.Controls.TextBlock)(this.FindName("Result")));
            this.MSAdControlAd1 = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("MSAdControlAd1")));
            this.AdDuplexAdControl1 = ((AdDuplex.AdControl)(this.FindName("AdDuplexAdControl1")));
            this.MSAdControlAd2 = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("MSAdControlAd2")));
            this.AdDuplexAdControl2 = ((AdDuplex.AdControl)(this.FindName("AdDuplexAdControl2")));
            this.Caption = ((System.Windows.Controls.TextBlock)(this.FindName("Caption")));
        }
    }
}
