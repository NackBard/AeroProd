﻿#pragma checksum "..\..\LaboratoryList.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9CCFD5057F35CC471B8FEF721376189E4533506A1F59AB0EC5B331D1594262D8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AeroProd;
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


namespace AeroProd {
    
    
    /// <summary>
    /// LaboratoryList
    /// </summary>
    public partial class LaboratoryList : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\LaboratoryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LabName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\LaboratoryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TargetBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\LaboratoryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateLabButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\LaboratoryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid LabGrid;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\LaboratoryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTargetBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\LaboratoryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateTargetButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\LaboratoryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TargetGrid;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\LaboratoryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
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
            System.Uri resourceLocater = new System.Uri("/AeroProd;component/laboratorylist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LaboratoryList.xaml"
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
            this.LabName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TargetBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.UpdateLabButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\LaboratoryList.xaml"
            this.UpdateLabButton.Click += new System.Windows.RoutedEventHandler(this.UpdateLabButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LabGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\LaboratoryList.xaml"
            this.LabGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LabGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NameTargetBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.UpdateTargetButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\LaboratoryList.xaml"
            this.UpdateTargetButton.Click += new System.Windows.RoutedEventHandler(this.UpdateTargetButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TargetGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 53 "..\..\LaboratoryList.xaml"
            this.TargetGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TargetGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\LaboratoryList.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

