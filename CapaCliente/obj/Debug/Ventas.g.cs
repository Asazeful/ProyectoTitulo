#pragma checksum "..\..\Ventas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0DE6959F83998852FCCFC36CE06D51A0A1FAF04F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using CapaCliente;
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


namespace CapaCliente {
    
    
    /// <summary>
    /// Ventas
    /// </summary>
    public partial class Ventas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtCliente;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblNombreCliente;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LstVentas;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatFechaVenta;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnVolver;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblFechaVenta;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtImporte;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblImporteVenta;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LstDetalleVenta;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNuevaVenta;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnFiltrarPorFecha;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Ventas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/CapaCliente;component/ventas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Ventas.xaml"
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
            this.TxtCliente = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\Ventas.xaml"
            this.TxtCliente.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtCliente_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LblNombreCliente = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.LstVentas = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.DatFechaVenta = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.BtnVolver = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Ventas.xaml"
            this.BtnVolver.Click += new System.Windows.RoutedEventHandler(this.BtnVolver_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LblFechaVenta = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.TxtImporte = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.LblImporteVenta = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.LstDetalleVenta = ((System.Windows.Controls.ListBox)(target));
            return;
            case 10:
            this.BtnNuevaVenta = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\Ventas.xaml"
            this.BtnNuevaVenta.Click += new System.Windows.RoutedEventHandler(this.BtnNuevaVenta_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BtnFiltrarPorFecha = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Ventas.xaml"
            this.BtnFiltrarPorFecha.Click += new System.Windows.RoutedEventHandler(this.BtnFiltrarPorFecha_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.BtnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Ventas.xaml"
            this.BtnCancelar.Click += new System.Windows.RoutedEventHandler(this.BtnCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 29 "..\..\Ventas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

