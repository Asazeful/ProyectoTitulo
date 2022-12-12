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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CapaDatos;
using CapaNegocio;

namespace CapaCliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductoBLL pbll = new ProductoBLL();
        ClienteBLL cbll = new ClienteBLL();
        public MainWindow()
        {
            InitializeComponent();
            LstProductosBajos.ItemsSource = pbll.GetProductoPorStock(stock: 5);
            
        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            Inventario ventanaActual = new Inventario();
            this.Close();
            ventanaActual.Show();
        }

        private void BtnCompras_Click(object sender, RoutedEventArgs e)
        {
            Compras ventanaActual = new Compras();
            Visibility = Visibility.Hidden;
            ventanaActual.Show();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            Clientes ventanaActual = new Clientes();
            Visibility = Visibility.Hidden;
            ventanaActual.Show();
        }

        private void BtnVentas_Click(object sender, RoutedEventArgs e)
        {
            Ventas ventanaActual = new Ventas();
            Visibility = Visibility.Hidden;
            ventanaActual.Show();
        }

        private void BtnPRoveedores_Click(object sender, RoutedEventArgs e)
        {
            Proveedores ventanaActual = new Proveedores();
            Visibility = Visibility.Hidden;
            ventanaActual.Show();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
