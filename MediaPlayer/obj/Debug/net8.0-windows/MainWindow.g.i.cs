﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6727E816519BBEAF118425BF818034C26B87A696"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.Sharp;
using MyMediaPlayer;
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


namespace MyMediaPlayer {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid filePlayer;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShuffle;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.Sharp.IconImage iconShuffle;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrevious;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlay;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.Sharp.IconImage iconPlayPause;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRepeat;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.Sharp.IconImage iconRepeat;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel timeControlBar;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement Preview;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMute;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderVolume;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddPlaylist;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listPlaylists;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel pnlControlBar;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMaximize;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 249 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayPlaylist;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.Sharp.IconImage iconPlay;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddFiles;
        
        #line default
        #line hidden
        
        
        #line 263 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditPlaylist;
        
        #line default
        #line hidden
        
        
        #line 289 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement Player;
        
        #line default
        #line hidden
        
        
        #line 291 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listSongs;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyMediaPlayer;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\MainWindow.xaml"
            ((MyMediaPlayer.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.filePlayer = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btnShuffle = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\MainWindow.xaml"
            this.btnShuffle.Click += new System.Windows.RoutedEventHandler(this.btnShuffle_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.iconShuffle = ((FontAwesome.Sharp.IconImage)(target));
            return;
            case 5:
            this.btnPrevious = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\MainWindow.xaml"
            this.btnPrevious.Click += new System.Windows.RoutedEventHandler(this.btnPrevious_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnPlay = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\MainWindow.xaml"
            this.btnPlay.Click += new System.Windows.RoutedEventHandler(this.btnPlay_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.iconPlayPause = ((FontAwesome.Sharp.IconImage)(target));
            return;
            case 8:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\MainWindow.xaml"
            this.btnNext.Click += new System.Windows.RoutedEventHandler(this.btnNext_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnRepeat = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\MainWindow.xaml"
            this.btnRepeat.Click += new System.Windows.RoutedEventHandler(this.btnRepeat_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.iconRepeat = ((FontAwesome.Sharp.IconImage)(target));
            return;
            case 11:
            this.timeControlBar = ((System.Windows.Controls.StackPanel)(target));
            
            #line 69 "..\..\..\MainWindow.xaml"
            this.timeControlBar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.timeControlBar_MouseDown);
            
            #line default
            #line hidden
            
            #line 69 "..\..\..\MainWindow.xaml"
            this.timeControlBar.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.timeControlBar_MouseUp);
            
            #line default
            #line hidden
            return;
            case 12:
            this.slider = ((System.Windows.Controls.Slider)(target));
            
            #line 74 "..\..\..\MainWindow.xaml"
            this.slider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.slider_ValueChanged);
            
            #line default
            #line hidden
            
            #line 74 "..\..\..\MainWindow.xaml"
            this.slider.MouseEnter += new System.Windows.Input.MouseEventHandler(this.slider_MouseEnter);
            
            #line default
            #line hidden
            
            #line 74 "..\..\..\MainWindow.xaml"
            this.slider.MouseMove += new System.Windows.Input.MouseEventHandler(this.slider_MouseMove);
            
            #line default
            #line hidden
            
            #line 74 "..\..\..\MainWindow.xaml"
            this.slider.MouseLeave += new System.Windows.Input.MouseEventHandler(this.slider_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Preview = ((System.Windows.Controls.MediaElement)(target));
            return;
            case 14:
            this.btnMute = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this.sliderVolume = ((System.Windows.Controls.Slider)(target));
            
            #line 92 "..\..\..\MainWindow.xaml"
            this.sliderVolume.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliderVolume_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 16:
            this.btnAddPlaylist = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\..\MainWindow.xaml"
            this.btnAddPlaylist.Click += new System.Windows.RoutedEventHandler(this.btnAddPlaylist_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.listPlaylists = ((System.Windows.Controls.ListView)(target));
            
            #line 133 "..\..\..\MainWindow.xaml"
            this.listPlaylists.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listPlaylists_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 18:
            this.pnlControlBar = ((System.Windows.Controls.StackPanel)(target));
            
            #line 180 "..\..\..\MainWindow.xaml"
            this.pnlControlBar.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.pnlControlBar_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 181 "..\..\..\MainWindow.xaml"
            this.pnlControlBar.MouseEnter += new System.Windows.Input.MouseEventHandler(this.pnlControlBar_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 19:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 186 "..\..\..\MainWindow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.btnMaximize = ((System.Windows.Controls.Button)(target));
            
            #line 194 "..\..\..\MainWindow.xaml"
            this.btnMaximize.Click += new System.Windows.RoutedEventHandler(this.btnMaximize_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 202 "..\..\..\MainWindow.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.btnPlayPlaylist = ((System.Windows.Controls.Button)(target));
            
            #line 249 "..\..\..\MainWindow.xaml"
            this.btnPlayPlaylist.Click += new System.Windows.RoutedEventHandler(this.btnPlayPlaylist_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            this.iconPlay = ((FontAwesome.Sharp.IconImage)(target));
            return;
            case 24:
            this.btnAddFiles = ((System.Windows.Controls.Button)(target));
            
            #line 256 "..\..\..\MainWindow.xaml"
            this.btnAddFiles.Click += new System.Windows.RoutedEventHandler(this.btnAddFiles_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            this.btnEditPlaylist = ((System.Windows.Controls.Button)(target));
            
            #line 263 "..\..\..\MainWindow.xaml"
            this.btnEditPlaylist.Click += new System.Windows.RoutedEventHandler(this.btnEditPlaylist_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 267 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 273 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 28:
            this.Player = ((System.Windows.Controls.MediaElement)(target));
            return;
            case 29:
            this.listSongs = ((System.Windows.Controls.ListView)(target));
            
            #line 292 "..\..\..\MainWindow.xaml"
            this.listSongs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listSongs_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 307 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDeleteFile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

