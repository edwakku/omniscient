﻿#pragma checksum "..\..\About.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D9213E2A8093C826799393944E6BC69E4ED0904AE10E19B6E31F2A0EB6C953D3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using omniscient;


namespace omniscient {
    
    
    /// <summary>
    /// About
    /// </summary>
    public partial class About : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\About.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\About.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DiscordBtn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\About.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TwitterBtn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\About.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button YouTubeBtn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\About.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WWWbtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Omniscient;component/about.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\About.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\About.xaml"
            ((omniscient.About)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\About.xaml"
            this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DiscordBtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\About.xaml"
            this.DiscordBtn.Click += new System.Windows.RoutedEventHandler(this.DiscordBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TwitterBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\About.xaml"
            this.TwitterBtn.Click += new System.Windows.RoutedEventHandler(this.TwitterBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.YouTubeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\About.xaml"
            this.YouTubeBtn.Click += new System.Windows.RoutedEventHandler(this.YouTubeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.WWWbtn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\About.xaml"
            this.WWWbtn.Click += new System.Windows.RoutedEventHandler(this.WWWbtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

