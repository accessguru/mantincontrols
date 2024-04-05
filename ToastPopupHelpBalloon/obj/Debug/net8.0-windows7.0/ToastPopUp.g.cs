﻿#pragma checksum "..\..\..\ToastPopUp.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6907CDF46CB2861CE022065D77DA00563C40FD6C"
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
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Mantin.Controls.Wpf.Notification {
    
    
    /// <summary>
    /// ToastPopUp
    /// </summary>
    public partial class ToastPopUp : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderBackground;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageLeft;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBoxTitle;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBoxShortDescription;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonView;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard StoryboardLoad;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard StoryboardFade;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Mantin.Controls.Wpf.Notification;component/toastpopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ToastPopUp.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.borderBackground = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.imageLeft = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            
            #line 84 "..\..\..\ToastPopUp.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ImageMouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBoxTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TextBoxShortDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.buttonView = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\ToastPopUp.xaml"
            this.buttonView.Click += new System.Windows.RoutedEventHandler(this.ButtonViewClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StoryboardLoad = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 8:
            
            #line 125 "..\..\..\ToastPopUp.xaml"
            ((System.Windows.Media.Animation.DoubleAnimation)(target)).Completed += new System.EventHandler(this.DoubleAnimationCompleted);
            
            #line default
            #line hidden
            return;
            case 9:
            this.StoryboardFade = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 10:
            
            #line 140 "..\..\..\ToastPopUp.xaml"
            ((System.Windows.Media.Animation.DoubleAnimation)(target)).Completed += new System.EventHandler(this.DoubleAnimationCompleted);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

