﻿#pragma checksum "L:\Phone_Applications\actual_projects\PasteNumberCall_WP7\PasteNumberCall\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E7BE56CAC99661E9D4D978CD5314192A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace PasteNumberCall {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button BUTTON_SMS;
        
        internal System.Windows.Controls.Button BUTTON_CALL;
        
        internal System.Windows.Controls.TextBox Number;
        
        internal System.Windows.Controls.Button Feedback;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PasteNumberCall;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.BUTTON_SMS = ((System.Windows.Controls.Button)(this.FindName("BUTTON_SMS")));
            this.BUTTON_CALL = ((System.Windows.Controls.Button)(this.FindName("BUTTON_CALL")));
            this.Number = ((System.Windows.Controls.TextBox)(this.FindName("Number")));
            this.Feedback = ((System.Windows.Controls.Button)(this.FindName("Feedback")));
        }
    }
}

