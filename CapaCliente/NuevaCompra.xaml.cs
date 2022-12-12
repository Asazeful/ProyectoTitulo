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
    /// Lógica de interacción para NuevaCompra.xaml
    /// </summary>
    public partial class NuevaCompra : Window
    {
        ProductoBLL pbll = new ProductoBLL();
        DetalleCompraBLL dbll = new DetalleCompraBLL();
        CompraBLL cbll = new CompraBLL();
        ProveedorBLL prBLL = new ProveedorBLL();
        public NuevaCompra()
        {
            InitializeComponent();
            LstProducto.ItemsSource = pbll.GetProductos();
            CmbProveedores.ItemsSource = prBLL.GetProveedores();
            
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Compras ventanaActual = new Compras();
            this.Close();
            ventanaActual.Show();
            if (LstCompraActual.Items != null)
            {
                int cod_venta = cbll.GetUltima();
                dbll.DeleteUno(cod_venta);
                cbll.Remove(cod_venta);
            }
        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (LstProducto.SelectedItem == null)
            {
                MessageBox.Show("Tiene que seleccionar un producto");
            }
            else if (!int.TryParse(TxtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("El numero indicado no es valido");
            }
            else if (LstCompraActual.Items != null)
            {
                DateTime fechaHoy = DatFechaHoy.DisplayDate;
                int total = 0;
                if (CmbProveedores.SelectedItem != null)
                {
                    CapaDatos.Proveedor proveedor = (CapaDatos.Proveedor)CmbProveedores.SelectedItem;
                    cbll.Add(fechaHoy,total,proveedor.cod_proveedor);
                }
                else { cbll.Add(fechaHoy, total); }

                int cod_compra = cbll.GetUltima();
                Producto producto = (Producto)LstProducto.SelectedItem;
                dbll.Add(cod_compra,cantidad,producto.cod_producto,Convert.ToInt32(producto.precio_compra));

                LstCompraActual.ItemsSource = null;
                LstCompraActual.ItemsSource = dbll.GetDetalles(cod_compra);
                TxtCantidad.Text = null;
                
            }
            else
            {
                int cod_compra = cbll.GetUltima();
                Producto producto = (Producto)LstProducto.SelectedItem;
                dbll.Add(cod_compra, cantidad, producto.cod_producto, Convert.ToInt32(producto.precio_compra));

                LstCompraActual.ItemsSource = null;
                LstCompraActual.ItemsSource = dbll.GetDetalles(cod_compra);
                TxtCantidad.Text = null;
                
            }
        }

        private void BtnFinalizarCompra_Click(object sender, RoutedEventArgs e)
        {
            int cod_compra = cbll.GetUltima();
            int total = dbll.GetTotal(cod_compra);
            MessageBoxResult result = MessageBox.Show($"El total de la venta es: {total}", "¿Está bien?", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                CapaDatos.Compras compra = cbll.Get(cod_compra);
                cbll.ActualizarTotal(compra.cod_compra, total);
                for (int i=0; i<LstCompraActual.Items.Count;)
                {
                    LstCompraActual.SelectedIndex = i;
                    CapaDatos.Detalle_compra detalle = (CapaDatos.Detalle_compra)LstCompraActual.SelectedItem;
                    pbll.SumarStock(detalle.cod_producto, detalle.cantidad);

                    i++;
                }
                LstCompraActual.ItemsSource = null;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (LstCompraActual.SelectedItem == null)
            {
                MessageBox.Show("Tiene que primero seleccionar un producto");
            }
            else
            {
                CapaDatos.Detalle_compra detalle = (CapaDatos.Detalle_compra)LstCompraActual.SelectedItem;
                dbll.DeleteUno(detalle.cod_detalle);
                if (LstCompraActual.Items.Count <1)
                {
                    int cod_compra = cbll.GetUltima();
                    LstCompraActual.ItemsSource = null;
                    cbll.Remove(cod_compra);
                }
                else
                {
                    int cod_compra = cbll.GetUltima();
                    Producto producto = (Producto)LstCompraActual.SelectedItem;

                    LstCompraActual.ItemsSource = null;
                    LstCompraActual.ItemsSource = dbll.GetDetalles(cod_compra);
                }
            }
        }
    }
}
