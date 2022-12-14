#pragma checksum "..\..\..\AdminWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BF8927868513B62DD325FF02BCD9CF2716EFDFA0"
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
using WpfApp1;
using WpfApp1.ViewModels;
using WpfApp1.Views;


namespace WpfApp1 {
    
    
    /// <summary>
    /// AdminWindow
    /// </summary>
    public partial class AdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button visitsButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addUserButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button listUsersButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchUsersButton;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button archiveButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addEmployeeButton;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button listEmployeesButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updatePricesButton;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button businessDataButton;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logoutButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminWindow.xaml"
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
            this.visitsButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\AdminWindow.xaml"
            this.visitsButton.Click += new System.Windows.RoutedEventHandler(this.visitsButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.addUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\AdminWindow.xaml"
            this.addUserButton.Click += new System.Windows.RoutedEventHandler(this.addUserButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.listUsersButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\AdminWindow.xaml"
            this.listUsersButton.Click += new System.Windows.RoutedEventHandler(this.listUsersButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.searchUsersButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\AdminWindow.xaml"
            this.searchUsersButton.Click += new System.Windows.RoutedEventHandler(this.searchUsersButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.archiveButton = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\AdminWindow.xaml"
            this.archiveButton.Click += new System.Windows.RoutedEventHandler(this.archiveButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.addEmployeeButton = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\AdminWindow.xaml"
            this.addEmployeeButton.Click += new System.Windows.RoutedEventHandler(this.addEmployeeButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.listEmployeesButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\AdminWindow.xaml"
            this.listEmployeesButton.Click += new System.Windows.RoutedEventHandler(this.listEmployeesButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.updatePricesButton = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\AdminWindow.xaml"
            this.updatePricesButton.Click += new System.Windows.RoutedEventHandler(this.updatePricesButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.businessDataButton = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\AdminWindow.xaml"
            this.businessDataButton.Click += new System.Windows.RoutedEventHandler(this.businessDataButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.logoutButton = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\AdminWindow.xaml"
            this.logoutButton.Click += new System.Windows.RoutedEventHandler(this.logoutButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

