﻿#pragma checksum "..\..\..\..\Pages\DisplayLyricsEditor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3482EFF5765B7056C43162A88F9D3D4CED5154A5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SuntoTexteditorExtensionWPF.Pages;
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


namespace SuntoTexteditorExtensionWPF.Pages {
    
    
    /// <summary>
    /// DisplayLyricsEditor
    /// </summary>
    public partial class DisplayLyricsEditor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DisplayLyricsTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RemoveTagsCheckBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RemoveBracketsCheckBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RemovePunctuationCheckBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox LowerCaseCheckBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox FirstLetterCheckBox;
        
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
            System.Uri resourceLocater = new System.Uri("/SuntoTexteditorExtensionWPF;component/pages/displaylyricseditor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
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
            
            #line 9 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
            ((SuntoTexteditorExtensionWPF.Pages.DisplayLyricsEditor)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 25 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReloadLyricsButtonClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DisplayLyricsTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.RemoveTagsCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.RemoveBracketsCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.RemovePunctuationCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.LowerCaseCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.FirstLetterCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            
            #line 34 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ApplyButtonClicked);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 36 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveButtonClicked);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 37 "..\..\..\..\Pages\DisplayLyricsEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButtonClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

