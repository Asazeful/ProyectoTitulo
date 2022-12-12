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
    /// Lógica de interacción para Inventario.xaml
    /// </summary>
    public partial class Inventario : Window
    {
        ProductoBLL pbll = new ProductoBLL();
        public Inventario()
        {
            InitializeComponent();
            LstProductos.ItemsSource = pbll.GetProductos();
            CmbCategoria.ItemsSource = Enum.GetValues(typeof(CategoriasEnum));
            CmbCategoria.SelectedIndex = 0;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaActual = new MainWindow();
            this.Close();
            ventanaActual.Show();
        }

        private void BtnAñadirProducto_Click(object sender, RoutedEventArgs e)
        {
            TxtPrecioProducto.Visibility = Visibility.Visible;
            LblPrecioCompra.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnAñadirProducto.Visibility = Visibility.Hidden;
            BtnAñadir.Visibility = Visibility.Visible;
            TxtPrecioVenta.Visibility = Visibility.Visible;
            LblPrecioVenta.Visibility = Visibility.Visible;
            BtnFiltrarCategoria.Visibility = Visibility.Hidden;
            BtnFiltrarNombre.Visibility = Visibility.Hidden;
            BtnFiltrarStock.Visibility = Visibility.Hidden;
            BtnActualizarProducto.Visibility = Visibility.Hidden;


        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            string nombre = TxtNombreProducto.Text;
            string categoria = CmbCategoria.SelectedItem.ToString();

            if (!int.TryParse(TxtCantidadProducto.Text, out int cantidad))
            {
                MessageBox.Show("La cantidad indicada no es valida");
            }
            else if (!int.TryParse(TxtPrecioProducto.Text, out int precio_compra))
            {
                MessageBox.Show("El precio de compra no es valido");
            }
            else if (!int.TryParse(TxtPrecioVenta.Text, out int precio_venta))
            {
                MessageBox.Show("El precio de venta no es valido");
            }
            else
            {
                pbll.Add(nombre, categoria, precio_compra, precio_venta, cantidad);
                LstProductos.ItemsSource = null;
                LstProductos.ItemsSource = pbll.GetProductos();
                //////////////////////
                TxtPrecioProducto.Visibility = Visibility.Hidden;
                LblPrecioCompra.Visibility = Visibility.Hidden;
                BtnCancelar.Visibility = Visibility.Hidden;
                BtnAñadirProducto.Visibility = Visibility.Visible;
                BtnAñadir.Visibility = Visibility.Hidden;
                TxtPrecioVenta.Visibility = Visibility.Hidden;
                LblPrecioVenta.Visibility = Visibility.Hidden;
                TxtPrecioProducto.Text = null;
                TxtPrecioVenta.Text = null;
                TxtNombreProducto.Text = null;
                TxtCantidadProducto.Text = null;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            TxtPrecioProducto.Visibility = Visibility.Hidden;
            LblPrecioCompra.Visibility = Visibility.Hidden;
            BtnCancelar.Visibility = Visibility.Hidden;
            BtnAñadirProducto.Visibility = Visibility.Visible;
            BtnAñadir.Visibility = Visibility.Hidden;
            TxtPrecioVenta.Visibility = Visibility.Hidden;
            LblPrecioVenta.Visibility = Visibility.Hidden;
            BtnFiltrar.Visibility = Visibility.Hidden;
            BtnFiltrarCategoria.Visibility = Visibility.Visible;
            BtnFiltrarNombre.Visibility = Visibility.Visible;
            BtnFiltrarStock.Visibility = Visibility.Visible;
            BtnActualizarProducto.Visibility = Visibility.Visible;

            ///////
            TxtPrecioProducto.Text = null;
            TxtPrecioVenta.Text = null;
            TxtNombreProducto.Text = null;
            TxtCantidadProducto.Text = null;
            //////
            TxtNombreProducto.IsEnabled = true;
            TxtCantidadProducto.IsEnabled = true;
            CmbCategoria.IsEnabled = true;
            //////////
            LstProductos.ItemsSource = null;
            LstProductos.ItemsSource = pbll.GetProductos();
        }

        private void BtnFiltrarNombre_Click(object sender, RoutedEventArgs e)
        {
            TxtCantidadProducto.IsEnabled = false;
            CmbCategoria.IsEnabled = false;
            //
            BtnFiltrar.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnAñadirProducto.Visibility = Visibility.Hidden;
            BtnFiltrarCategoria.Visibility = Visibility.Hidden;
            BtnFiltrarNombre.Visibility = Visibility.Hidden;
            BtnFiltrarStock.Visibility = Visibility.Hidden;
            BtnActualizarProducto.Visibility = Visibility.Hidden;
        }

        private void BtnFiltrarStock_Click(object sender, RoutedEventArgs e)
        {
            TxtNombreProducto.IsEnabled = false;
            CmbCategoria.IsEnabled = false;
            //
            BtnFiltrar.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnAñadirProducto.Visibility = Visibility.Hidden;
            BtnFiltrarCategoria.Visibility = Visibility.Hidden;
            BtnFiltrarNombre.Visibility = Visibility.Hidden;
            BtnFiltrarStock.Visibility = Visibility.Hidden;
            BtnActualizarProducto.Visibility = Visibility.Hidden;
        }

        private void BtnFiltrarCategoria_Click(object sender, RoutedEventArgs e)
        {
            TxtNombreProducto.IsEnabled = false;
            TxtCantidadProducto.IsEnabled = false;
            //
            BtnFiltrar.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnAñadirProducto.Visibility = Visibility.Hidden;
            BtnFiltrarCategoria.Visibility = Visibility.Hidden;
            BtnFiltrarNombre.Visibility = Visibility.Hidden;
            BtnFiltrarStock.Visibility = Visibility.Hidden;
            BtnActualizarProducto.Visibility = Visibility.Hidden;

        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNombreProducto.IsEnabled)
            {
                LstProductos.ItemsSource = pbll.GetProductoPorNombre(TxtNombreProducto.Text);
            }else if (CmbCategoria.IsEnabled)
            {
                LstProductos.ItemsSource = pbll.GetProductoPorCategoria(CmbCategoria.Text);
            }else if (TxtCantidadProducto.IsEnabled & int.TryParse(TxtCantidadProducto.Text,out int cantidad))
            {
                LstProductos.ItemsSource = pbll.GetProductoPorStock(cantidad);
            }
            else { MessageBox.Show("No se han encontrado producto, revise que esté todo en orden"); }
        }

        private void BtnActualizarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (LstProductos.SelectedItem != null)
            {
                Producto producto = (Producto)LstProductos.SelectedItem;
                TxtNombreProducto.Text = producto.nom_producto;
                TxtPrecioProducto.Text = producto.precio_compra.ToString();
                TxtPrecioVenta.Text = producto.precio_venta.ToString();
                TxtCantidadProducto.Text = producto.stock.ToString();
                ////////////
                TxtNombreProducto.IsEnabled = false;
                TxtCantidadProducto.IsEnabled = false;
                LstProductos.IsEnabled = false;
                ///////////
                TxtPrecioProducto.Visibility = Visibility.Visible;
                LblPrecioCompra.Visibility = Visibility.Visible;
                BtnCancelar.Visibility = Visibility.Visible;
                BtnAñadirProducto.Visibility = Visibility.Hidden;
                BtnConfirmarActualizacion.Visibility = Visibility.Visible;
                TxtPrecioVenta.Visibility = Visibility.Visible;
                LblPrecioVenta.Visibility = Visibility.Visible;
                BtnFiltrarCategoria.Visibility = Visibility.Hidden;
                BtnFiltrarNombre.Visibility = Visibility.Hidden;
                BtnFiltrarStock.Visibility = Visibility.Hidden;
                BtnActualizarProducto.Visibility = Visibility.Hidden;
            }
            else { MessageBox.Show("Tiene que indicar que producto actualizar"); }
        }

        private void BtnConfirmarActualizacion_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(TxtPrecioProducto.Text, out int precio_compra))
            {
                MessageBox.Show("El precio de compra no es valido");
            }
            else if (!int.TryParse(TxtPrecioVenta.Text, out int precio_venta))
            {
                MessageBox.Show("El precio de venta no es valido");
            }
            else
            {
                Producto producto = (Producto)LstProductos.SelectedItem;
                pbll.ActualizarPCompra(producto, precio_compra);
                pbll.ActualizarPCompra(producto, precio_venta);
                pbll.ActualizarCategoria(producto, CmbCategoria.Text);
                LstProductos.ItemsSource = null;
                LstProductos.ItemsSource = pbll.GetProductos();

                ///////////
                TxtPrecioProducto.Visibility = Visibility.Hidden;
                LblPrecioCompra.Visibility = Visibility.Hidden;
                BtnCancelar.Visibility = Visibility.Hidden;
                BtnAñadirProducto.Visibility = Visibility.Visible;
                BtnConfirmarActualizacion.Visibility = Visibility.Hidden;
                TxtPrecioVenta.Visibility = Visibility.Hidden;
                LblPrecioVenta.Visibility = Visibility.Hidden;
                TxtNombreProducto.IsEnabled = true;
                TxtCantidadProducto.IsEnabled = true;
                LstProductos.IsEnabled = true;
                TxtPrecioProducto.Text = null;
                TxtPrecioVenta.Text = null;
                TxtNombreProducto.Text = null;
                TxtCantidadProducto.Text = null;
            }
        }
    }
    }

