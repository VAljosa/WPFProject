﻿#pragma checksum "..\..\..\..\ViewControl\DijaloziZaUnos\KorisnickiNalog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1BB60BDD6C57A3582291D5AF6E4C72EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DemoDiplomski.Utility;
using DemoDiplomski.ViewControl.DijaloziZaUnos;
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


namespace DemoDiplomski.ViewControl.DijaloziZaUnos {
    
    
    /// <summary>
    /// KorisnickiNalog
    /// </summary>
    public partial class KorisnickiNalog : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 72 "..\..\..\..\ViewControl\DijaloziZaUnos\KorisnickiNalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNazivUstanove;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\ViewControl\DijaloziZaUnos\KorisnickiNalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLaboratorija;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\ViewControl\DijaloziZaUnos\KorisnickiNalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPib;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\ViewControl\DijaloziZaUnos\KorisnickiNalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbGrad;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\ViewControl\DijaloziZaUnos\KorisnickiNalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbAdresa;
        
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
            System.Uri resourceLocater = new System.Uri("/DemoDiplomski;component/viewcontrol/dijalozizaunos/korisnickinalog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ViewControl\DijaloziZaUnos\KorisnickiNalog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.tbNazivUstanove = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbLaboratorija = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbPib = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbGrad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbAdresa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 113 "..\..\..\..\ViewControl\DijaloziZaUnos\KorisnickiNalog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SacuvajIIzadji_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 118 "..\..\..\..\ViewControl\DijaloziZaUnos\KorisnickiNalog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

