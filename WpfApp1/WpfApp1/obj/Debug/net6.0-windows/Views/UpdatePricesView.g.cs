#pragma checksum "..\..\..\..\Views\UpdatePricesView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59F85ACF3D7685BFDE1FDAC00F3C5DB60F80B073"
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
using WpfApp1.Views;


namespace WpfApp1.Views {
    
    
    /// <summary>
    /// UpdatePricesView
    /// </summary>
    public partial class UpdatePricesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updatePrButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAddTitle;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blckTip;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blckDuration;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blckPrice;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrice;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboType;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboDuration;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button getPriceButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blckNewPrice;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\UpdatePricesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNewPrice;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/views/updatepricesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\UpdatePricesView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.updatePrButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\Views\UpdatePricesView.xaml"
            this.updatePrButton.Click += new System.Windows.RoutedEventHandler(this.updatePrButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtAddTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.blckTip = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.blckDuration = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.blckPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.comboType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.comboDuration = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.getPriceButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Views\UpdatePricesView.xaml"
            this.getPriceButton.Click += new System.Windows.RoutedEventHandler(this.getPriceButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.blckNewPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.txtNewPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

