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
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        VentasBLL vbll = new VentasBLL();
        ClienteBLL cbll = new ClienteBLL();
        DetalleVentaBLL dbll = new DetalleVentaBLL();
        public Ventas()
        {
            InitializeComponent();
            LstVentas.ItemsSource = vbll.GetPorImporte();
            DatFechaVenta.DisplayDateEnd = DatFechaVenta.DisplayDate;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaActual = new MainWindow();
            this.Close();
            ventanaActual.Show();
        }

        private void BtnNuevaVenta_Click(object sender, RoutedEventArgs e)
        {
            NuevaVenta ventanaActual = new NuevaVenta();
            this.Close();
            ventanaActual.Show();
        }

        private void TxtCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstVentas.ItemsSource = null;
            if (!string.IsNullOrEmpty(TxtCliente.Text))
            {
                int codigo = cbll.CodigoPorNombre(TxtCliente.Text);
                LstVentas.ItemsSource = vbll.GetPorCliente(codigo);
                TxtImporte.Visibility = Visibility.Hidden;
                LblImporteVenta.Visibility = Visibility.Hidden;
                DatFechaVenta.Visibility = Visibility.Hidden;
                LblFechaVenta.Visibility = Visibility.Hidden;
            }
            else
            {
                LstVentas.ItemsSource = vbll.GetPorImporte();
                TxtImporte.Visibility = Visibility.Visible;
                LblImporteVenta.Visibility = Visibility.Visible;
                DatFechaVenta.Visibility = Visibility.Visible;
                LblFechaVenta.Visibility = Visibility.Visible;
            }
        }

        private void BtnFiltrarPorFecha_Click(object sender, RoutedEventArgs e)
        {
            if (DatFechaVenta.DisplayDate == null)
            {
                MessageBox.Show("Tiene que ingresar una fecha");
            }
            else
            {
                LstVentas.ItemsSource = vbll.GetPorFecha((DateTime)DatFechaVenta.DisplayDate);
                TxtImporte.Visibility = Visibility.Hidden;
                LblImporteVenta.Visibility = Visibility.Hidden;
                TxtCliente.Visibility = Visibility.Hidden;
                LblNombreCliente.Visibility = Visibility.Hidden;
                BtnCancelar.Visibility = Visibility.Visible;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            TxtImporte.Visibility = Visibility.Visible;
            LblImporteVenta.Visibility = Visibility.Visible;
            TxtCliente.Visibility = Visibility.Visible;
            LblNombreCliente.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LstVentas.SelectedItem==null)
            {
                MessageBox.Show("No hay ninguna venta seleccionada");
            }
            else
            {
                CapaDatos.Ventas venta = (CapaDatos.Ventas)LstVentas.SelectedItem;
                LstDetalleVenta.ItemsSource = null;
                LstDetalleVenta.ItemsSource = dbll.GetDetalle_Ventas(venta.cod_venta);
            }
        }
    }
}
