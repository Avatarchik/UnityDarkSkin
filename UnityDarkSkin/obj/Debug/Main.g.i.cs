﻿#pragma checksum "..\..\Main.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E2770C6DD7B481A0F251DB93B80A99056AEA2CCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
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
using UnityDarkSkin;


namespace UnityDarkSkin {
    
    
    /// <summary>
    /// Main
    /// </summary>
    public partial class Main : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid bg;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabmain;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border tabbar;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_unityLocation;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_loadUnity;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox versionSelector;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_proskinlabel;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_changeSkin;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid appmove;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid btn_close;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_close;
        
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
            System.Uri resourceLocater = new System.Uri("/UnityDarkSkin;component/main.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Main.xaml"
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
            this.bg = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.tabmain = ((System.Windows.Controls.TabItem)(target));
            return;
            case 3:
            this.tabbar = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.txt_unityLocation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btn_loadUnity = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Main.xaml"
            this.btn_loadUnity.Click += new System.Windows.RoutedEventHandler(this.Btn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.versionSelector = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.txt_proskinlabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.btn_changeSkin = ((System.Windows.Controls.Image)(target));
            
            #line 37 "..\..\Main.xaml"
            this.btn_changeSkin.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Btn_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.appmove = ((System.Windows.Controls.Grid)(target));
            
            #line 63 "..\..\Main.xaml"
            this.appmove.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Appmove_MouseDown);
            
            #line default
            #line hidden
            
            #line 63 "..\..\Main.xaml"
            this.appmove.MouseMove += new System.Windows.Input.MouseEventHandler(this.Appmove_MouseMove);
            
            #line default
            #line hidden
            
            #line 63 "..\..\Main.xaml"
            this.appmove.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Appmove_MouseUp);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_close = ((System.Windows.Controls.Grid)(target));
            
            #line 64 "..\..\Main.xaml"
            this.btn_close.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Btn_Close_MouseDown);
            
            #line default
            #line hidden
            
            #line 64 "..\..\Main.xaml"
            this.btn_close.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Btn_Close_MouseUp);
            
            #line default
            #line hidden
            return;
            case 11:
            this.txt_close = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

