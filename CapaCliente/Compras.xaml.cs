using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CapaDatos;
using CapaNegocio;

namespace CapaCliente
{
    /// <summary>
    /// Lógica de interacción para Compras.xaml
    /// </summary>
    public partial class Compras : Window
    {
        CompraBLL cbll = new CompraBLL();
        DetalleCompraBLL dbll = new DetalleCompraBLL();
        ProveedorBLL pbll = new ProveedorBLL();


        public Compras()
        {
            InitializeComponent();
            LstCompras.ItemsSource = cbll.GetCompras();
            DatFechaCompra.DisplayDateEnd = DatFechaCompra.DisplayDate;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaActual = new MainWindow();
            this.Close();
            ventanaActual.Show();
        }

        private void BtnNuevaCompra_Click(object sender, RoutedEventArgs e)
        {
            NuevaCompra ventanaActual = new NuevaCompra();
            this.Close();
            ventanaActual.Show();
        }

        private void TxtImporte_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstCompras.ItemsSource = null;
            if (!string.IsNullOrEmpty(TxtImporte.Text) & int.TryParse(TxtImporte.Text, out int total))
            {

                LstCompras.ItemsSource = cbll.GetPorTotal(total);

                LblProveedor.Visibility = Visibility.Hidden;
                LblFechaCompra.Visibility = Visibility.Hidden;
                DatFechaCompra.Visibility = Visibility.Hidden;
                CmbVendedor.Visibility = Visibility.Hidden;
                BtnFiltrarFecha.Visibility = Visibility.Hidden;
                BtnFiltrarProveedor.Visibility = Visibility.Hidden;
                BtnNuevaCompra.Visibility = Visibility.Hidden;

            }
            else
            {
                LstCompras.ItemsSource = cbll.GetCompras();

                LblProveedor.Visibility = Visibility.Visible;
                LblFechaCompra.Visibility = Visibility.Visible;
                DatFechaCompra.Visibility = Visibility.Visible;
                CmbVendedor.Visibility = Visibility.Visible;
                BtnFiltrarFecha.Visibility = Visibility.Visible;
                BtnFiltrarProveedor.Visibility = Visibility.Visible;
                BtnNuevaCompra.Visibility = Visibility.Visible;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LblProveedor.Visibility = Visibility.Visible;
            TxtImporte.Visibility = Visibility.Visible;
            LblImporte.Visibility = Visibility.Visible;
            CmbVendedor.Visibility = Visibility.Visible;
            BtnFiltrarFecha.Visibility = Visibility.Visible;
            BtnFiltrarProveedor.Visibility = Visibility.Visible;
            BtnNuevaCompra.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Hidden;
        }

        private void BtnFiltrarFecha_Click(object sender, RoutedEventArgs e)
        {
            if (DatFechaCompra.SelectedDate != null)
            {
                LstCompras.ItemsSource = cbll.GetPorFecha((DateTime)DatFechaCompra.SelectedDate);
                BtnCancelar.Visibility = Visibility.Visible;
                LblProveedor.Visibility = Visibility.Hidden;
                TxtImporte.Visibility = Visibility.Hidden;
                LblImporte.Visibility = Visibility.Hidden;
                CmbVendedor.Visibility = Visibility.Hidden;
                BtnFiltrarFecha.Visibility = Visibility.Hidden;
                BtnFiltrarProveedor.Visibility = Visibility.Hidden;
                BtnNuevaCompra.Visibility = Visibility.Hidden;
            }
            else { MessageBox.Show("Tiene que seleccionar una fecha"); }
        }

        private void BtnFiltrarProveedor_Click(object sender, RoutedEventArgs e)
        {
            if (CmbVendedor.SelectedItem != null)
            {
                Proveedor proveedor = (Proveedor)CmbVendedor.SelectedItem;
                LstCompras.ItemsSource = cbll.GetPorProveedor(proveedor.cod_proveedor);
                LstCompras.ItemsSource = cbll.GetPorFecha((DateTime)DatFechaCompra.SelectedDate);
                BtnCancelar.Visibility = Visibility.Visible;
                DatFechaCompra.Visibility = Visibility.Hidden;
                TxtImporte.Visibility = Visibility.Hidden;
                LblImporte.Visibility = Visibility.Hidden;
                LblFechaCompra.Visibility = Visibility.Hidden;
                BtnFiltrarFecha.Visibility = Visibility.Hidden;
                BtnFiltrarProveedor.Visibility = Visibility.Hidden;
                BtnNuevaCompra.Visibility = Visibility.Hidden;
            }
            else { MessageBox.Show("Tiene que seleccionar un proveedor"); }
        }

        private void BtnMostrarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (LstCompras.SelectedItem != null)
            {
                CapaDatos.Compras compra = (CapaDatos.Compras)LstCompras.SelectedItem;
                LstDetalleCompra.ItemsSource = null;
                LstDetalleCompra.ItemsSource = dbll.GetDetalles(compra.cod_compra);
            } else { MessageBox.Show("Debe seleccionar una compra primero"); }
            
        }
    }
}
