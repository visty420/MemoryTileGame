﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "56263A386A68820523A792BBC59B9C081933916D8F0FF15459AB82B4E66D776D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MemoryTilesGame;
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


namespace MemoryTilesGame {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PlayerListView;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image userProfilePicture;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newUserButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteUserButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button playButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button previousUserButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextUserButton;
        
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
            System.Uri resourceLocater = new System.Uri("/MemoryTilesGame;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.PlayerListView = ((System.Windows.Controls.ListView)(target));
            
            #line 11 "..\..\MainWindow.xaml"
            this.PlayerListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PlayerListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.userProfilePicture = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.newUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.newUserButton.Click += new System.Windows.RoutedEventHandler(this.newUserButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deleteUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.deleteUserButton.Click += new System.Windows.RoutedEventHandler(this.deleteUserButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.playButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.playButton.Click += new System.Windows.RoutedEventHandler(this.playButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\MainWindow.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.previousUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.previousUserButton.Click += new System.Windows.RoutedEventHandler(this.previousUserButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.nextUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MainWindow.xaml"
            this.nextUserButton.Click += new System.Windows.RoutedEventHandler(this.nextUserButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

