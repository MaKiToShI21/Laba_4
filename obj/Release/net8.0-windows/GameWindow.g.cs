﻿#pragma checksum "..\..\..\GameWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E99C6DC0D198A56A56533912B6F980F19EE0355D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Laba4;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Laba4 {
    
    
    /// <summary>
    /// GameWindow
    /// </summary>
    public partial class GameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas GameCanvas;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ScoreTextBlock;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image playerImage;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PlayerHPTextBlock;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image enemyImage;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EnemyHPTextBlock;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GameOverCanvas;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Laba4;component/gamewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GameWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GameCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.ScoreTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.playerImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.PlayerHPTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.enemyImage = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.EnemyHPTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 58 "..\..\..\GameWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenMainWindowClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 68 "..\..\..\GameWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveGameClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.GameOverCanvas = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            
            #line 100 "..\..\..\GameWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RestartClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 107 "..\..\..\GameWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenMainWindowClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

