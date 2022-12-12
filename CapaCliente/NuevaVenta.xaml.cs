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
    /// Lógica de interacción para NuevaVenta.xaml
    /// </summary>
    public partial class NuevaVenta : Window
    {
        ProductoBLL pbll = new ProductoBLL();
        VentasBLL vbll = new VentasBLL();
        DetalleVentaBLL dbll = new DetalleVentaBLL();
        ClienteBLL cbll = new ClienteBLL();
        public NuevaVenta()
        {
            InitializeComponent();
            LstProductos.ItemsSource = pbll.GetProductos();
            CmbClientes.ItemsSource = cbll.GetClientes();
            LstCarritoActual.ItemsSource = null;

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Ventas ventanaActual = new Ventas();
            this.Close();
            ventanaActual.Show();
            if (LstCarritoActual.ItemsSource != null)
            {
                int cod_venta = vbll.GetUltima();
                dbll.Delete(cod_venta);
                vbll.Delete(cod_venta);
            }
            
        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (LstProductos.SelectedItem == null)
            {
                MessageBox.Show("Tiene que seleccionar un producto antes de añadir");
            }else if (!int.TryParse(TxtCantidadProducto.Text,out int cantidadProducto))
            {
                MessageBox.Show("La cantidad indicada no es correcta");
            }
            else if(LstCarritoActual.ItemsSource == null)
            {
                
                DateTime fechaHoy = (DateTime)DatFechaVenta.DisplayDate;
                int total = 0;
                
                vbll.Add(fechaHoy, total);


                int cod_venta = vbll.GetUltima();
                Producto producto = (Producto)LstProductos.SelectedItem;

                dbll.Add(cod_venta,producto.cod_producto,cantidadProducto,Convert.ToInt32(producto.precio_venta));
                LstCarritoActual.ItemsSource = null;
                LstCarritoActual.ItemsSource = dbll.GetDetalle_Ventas(cod_venta);
                TxtCantidadProducto.Text = null;
                
                
            }
            else
            {
                int cod_venta = vbll.GetUltima();
                Producto producto = (Producto)LstProductos.SelectedItem;

                dbll.Add(cod_venta, producto.cod_producto, cantidadProducto, Convert.ToInt32(producto.precio_venta));
                LstCarritoActual.ItemsSource = null;
                LstCarritoActual.ItemsSource = dbll.GetDetalle_Ventas(cod_venta);
                TxtCantidadProducto.Text = null;
            }
        }

        private void BtnTerminarCompra_Click(object sender, RoutedEventArgs e)
        {
            int cod_venta = vbll.GetUltima();
            int total = dbll.GetTotal(cod_venta);
            MessageBoxResult result = MessageBox.Show($"El total de la venta es: {total}", "¿Está bien?",MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                MessageBoxResult result2 = MessageBox.Show("Desea añadirlo a la deuda del cliente?", "",MessageBoxButton .YesNo);
                if (result2 == MessageBoxResult.Yes)
                {
                    CapaDatos.Clientes cliente = (CapaDatos.Clientes)CmbClientes.SelectedItem;
                    CapaDatos.Ventas venta = vbll.Get(cod_venta);
                    vbll.ActualizarDeudor(cliente.cod_cliente,venta.cod_venta);
                    vbll.ActualizarTotal(venta, total);
                    cbll.ActualizarDeuda(cliente, total);
                    for (int i = 0; i <= LstCarritoActual.Items.Count;)
                    {
                        LstCarritoActual.SelectedIndex = i;
                        CapaDatos.Detalle_ventas producto = (CapaDatos.Detalle_ventas)LstCarritoActual.SelectedItem;
                        pbll.RestarStock(producto.cod_producto, producto.cantidad);

                        i++;
                    }

                    LstCarritoActual.ItemsSource = null;


                }
                else
                {
                    CapaDatos.Ventas venta = vbll.Get(cod_venta);
                    vbll.ActualizarTotal(venta, total);
                    for (int i = 0; i <= LstCarritoActual.Items.Count;)
                    {
                        LstCarritoActual.SelectedIndex = i;
                        CapaDatos.Detalle_ventas producto = (CapaDatos.Detalle_ventas)LstCarritoActual.SelectedItem;
                        pbll.RestarStock(producto.cod_producto, producto.cantidad);

                        i++;
                    }

                    LstCarritoActual.ItemsSource = null;
                }
            }
        }

        private void BtnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (LstCarritoActual.SelectedItem == null)
            {
                MessageBox.Show("Tiene que seleccionar un item para eliminar");
            }
            else
            {
                CapaDatos.Detalle_ventas detalle = (CapaDatos.Detalle_ventas)LstCarritoActual.SelectedItem;
                dbll.DeleteUno(detalle.cod_detalle);
                if (LstCarritoActual.Items.Count <1)
                {
                    int cod_venta = vbll.GetUltima();
                    LstCarritoActual.ItemsSource = null;
                    vbll.Delete(cod_venta);

                }
                else
                {
                    int cod_venta = vbll.GetUltima();
                    Producto producto = (Producto)LstProductos.SelectedItem;

                    LstCarritoActual.ItemsSource = null;
                    LstCarritoActual.ItemsSource = dbll.GetDetalle_Ventas(cod_venta);
                }
                
            }
        }

        
    }
}
