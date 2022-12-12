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
    /// Lógica de interacción para Proveedores.xaml
    /// </summary>
    public partial class Proveedores : Window
    {
        ProveedorBLL pbll = new ProveedorBLL();
        public Proveedores()
        {
            InitializeComponent();
            LstProveedores.ItemsSource = pbll.GetProveedores();
        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre para el proveedor");
            }
            else if(string.IsNullOrEmpty(TxtTelefono.Text))
            {
                MessageBox.Show("Debe ingresar un numero de telefono");
            }
            else
            {
                pbll.Add(TxtNombre.Text, TxtTelefono.Text);
                TxtNombre.Text = null;
                TxtTelefono.Text = null;
                LstProveedores.ItemsSource = null;
                LstProveedores.ItemsSource = pbll.GetProveedores();
            }

        }

        private void BtnAñadir_Click(object sender, RoutedEventArgs e)
        {
            BtnAñadir.Visibility = Visibility.Hidden;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnConfirmar.Visibility = Visibility.Visible;
            LblTelefono.Visibility = Visibility.Visible;
            TxtTelefono.Visibility = Visibility.Visible;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            BtnAñadir.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Hidden;
            BtnConfirmar.Visibility = Visibility.Hidden;
            LblTelefono.Visibility = Visibility.Hidden;
            TxtTelefono.Visibility = Visibility.Hidden;
            TxtNombre.Text = null;
            TxtTelefono.Text = null;
            LstProveedores.ItemsSource = null;
            LstProveedores.ItemsSource = pbll.GetProveedores();
        }

        private void TxtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TxtNombre.Text == null)
            {
                LstProveedores.ItemsSource = null;
                LstProveedores.ItemsSource = pbll.GetProveedores();
            }
            else
            {
                LstProveedores.ItemsSource = null;
                LstProveedores.ItemsSource = pbll.GetPorNombre(TxtNombre.Text);
                BtnAñadir.Visibility = Visibility.Hidden;

            }
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaActual = new MainWindow();
            this.Close();
            ventanaActual.Show();
        }
    }
}
