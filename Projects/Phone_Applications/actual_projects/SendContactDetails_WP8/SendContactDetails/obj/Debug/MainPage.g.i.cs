﻿#pragma checksum "L:\Phone_Applications\actual_projects\SendContactDetails_WP8\SendContactDetails\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "662D4C9AA944090CD94129D592066C04"
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


namespace SendContactDetails {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot MyPivot;
        
        internal System.Windows.Controls.TextBox contactFilterString;
        
        internal System.Windows.Controls.RadioButton name;
        
        internal System.Windows.Controls.RadioButton phone;
        
        internal System.Windows.Controls.RadioButton email;
        
        internal System.Windows.Controls.TextBlock ContactResultsLabel;
        
        internal System.Windows.Controls.ListBox ContactResultsData;
        
        internal System.Windows.Controls.StackPanel ContentPanel;
        
        internal System.Windows.Controls.Image Picture;
        
        internal System.Windows.Controls.TextBox DetailsText;
        
        internal System.Windows.Controls.TextBox Emailid_text;
        
        internal System.Windows.Controls.TextBox Phone_text;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SendContactDetails;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.MyPivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("MyPivot")));
            this.contactFilterString = ((System.Windows.Controls.TextBox)(this.FindName("contactFilterString")));
            this.name = ((System.Windows.Controls.RadioButton)(this.FindName("name")));
            this.phone = ((System.Windows.Controls.RadioButton)(this.FindName("phone")));
            this.email = ((System.Windows.Controls.RadioButton)(this.FindName("email")));
            this.ContactResultsLabel = ((System.Windows.Controls.TextBlock)(this.FindName("ContactResultsLabel")));
            this.ContactResultsData = ((System.Windows.Controls.ListBox)(this.FindName("ContactResultsData")));
            this.ContentPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ContentPanel")));
            this.Picture = ((System.Windows.Controls.Image)(this.FindName("Picture")));
            this.DetailsText = ((System.Windows.Controls.TextBox)(this.FindName("DetailsText")));
            this.Emailid_text = ((System.Windows.Controls.TextBox)(this.FindName("Emailid_text")));
            this.Phone_text = ((System.Windows.Controls.TextBox)(this.FindName("Phone_text")));
        }
    }
}

