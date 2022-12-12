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
using CapaNegocio;
using CapaDatos;

namespace CapaCliente
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        ClienteBLL cbll = new ClienteBLL();
        int on;
        public Clientes()
        {
            
            InitializeComponent();
            LstClientes.ItemsSource = cbll.GetClientes();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaActual = new MainWindow();
            this.Close();
            ventanaActual.Show();
        }

        private void BtnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            TxtDeudaCliente.Visibility = Visibility.Visible;
            LblDeudaCliente.Visibility = Visibility.Visible;
            TxtTelefonoCliente.Visibility = Visibility.Visible;
            LblTelefonoCliente.Visibility = Visibility.Visible;
            BtnConfirmar.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnNuevoCliente.Visibility = Visibility.Hidden;
            

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ComoNuevo();

        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNombreCliente.Text)) 
            {
                MessageBox.Show("Tiene que poner un nombre");
            }else if (string.IsNullOrEmpty(TxtDeudaCliente.Text) & (bool)CheckDeudor.IsChecked)
            {
                MessageBox.Show("Falta ingresar la deuda");
            }else if(!int.TryParse(TxtDeudaCliente.Text, out int deudaCliente) & (bool)CheckDeudor.IsChecked)
            {
                MessageBox.Show("El valor de la deuda es invalido");
            }
            else
            {
                bool deudor = false;
                if ((bool)CheckDeudor.IsChecked)
                {
                     deudor = true;
                }else { deudaCliente = 0; }
                string nombreCliente = TxtNombreCliente.Text;
                string telefonoCliente = TxtTelefonoCliente.Text;

                cbll.Add(nombreCliente, telefonoCliente, deudor,deudaCliente);
                ////////
                LstClientes.ItemsSource = null;
                LstClientes.ItemsSource = cbll.GetClientes();
                ///////////
                ComoNuevo();
                

            }
        }

        private void CheckDeudor_Click(object sender, RoutedEventArgs e)
        {
            if (BtnConfirmar.Visibility == Visibility.Visible)
            {
                if ((bool)TxtDeudaCliente.IsEnabled)
                {
                    TxtDeudaCliente.IsEnabled = false;
                    TxtDeudaCliente.Text = null;
                }
                else { TxtDeudaCliente.IsEnabled = true; }
            }
            else
            {
                on++;
                if (on % 2 != 0)
                {
                    LstClientes.ItemsSource = null;
                    LstClientes.ItemsSource = cbll.GetDeudores();
                }
                else {
                    LstClientes.ItemsSource = null;
                    LstClientes.ItemsSource = cbll.GetClientes();
                }
                
            }
            


        }


        private void BtnActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (LstClientes.SelectedItem != null)
            {
                CapaDatos.Clientes clientes = (CapaDatos.Clientes)LstClientes.SelectedItem;
                TxtNombreCliente.Text = clientes.nom_cliente;
                TxtDeudaCliente.Text = clientes.deuda.ToString();
                TxtTelefonoCliente.Text = clientes.telefono_cliente;
                /////
                TxtNombreCliente.IsEnabled = false;
                TxtDeudaCliente.IsEnabled = true;


                ///////
                TxtDeudaCliente.Visibility = Visibility.Visible;
                LblDeudaCliente.Visibility = Visibility.Visible;
                TxtTelefonoCliente.Visibility = Visibility.Visible;
                LblTelefonoCliente.Visibility = Visibility.Visible;
                BtnAceptarActualizacion.Visibility = Visibility.Visible;
                BtnCancelar.Visibility = Visibility.Visible;
                BtnActualizarCliente.Visibility = Visibility.Hidden;
                BtnNuevoCliente.Visibility = Visibility.Hidden;
                CheckDeudor.Visibility = Visibility.Hidden;
            }
            else { MessageBox.Show("Debe seleccionar un cliente para actualizar"); }
            

        }

        private void BtnAceptarActualizacion_Click(object sender, RoutedEventArgs e)
        {
            CapaDatos.Clientes clientes = (CapaDatos.Clientes)LstClientes.SelectedItem;

            if(int.TryParse(TxtDeudaCliente.Text,out int deudaCliente))
            {
                cbll.ActualizarDeuda(clientes, deudaCliente);
            }
            else { MessageBox.Show("No se pudo actualizar la deuda debido a un error en la digitacion"); }

            cbll.ActualizarTelefono(clientes, TxtTelefonoCliente.Text);


            /////////////////
            ComoNuevo();
            
        }

        private void ComoNuevo()
        {
            TxtDeudaCliente.Visibility = Visibility.Hidden;
            LblDeudaCliente.Visibility = Visibility.Hidden;
            TxtTelefonoCliente.Visibility = Visibility.Hidden;
            LblTelefonoCliente.Visibility = Visibility.Hidden;
            BtnConfirmar.Visibility = Visibility.Hidden;
            BtnCancelar.Visibility = Visibility.Hidden;
            BtnAceptarActualizacion.Visibility = Visibility.Hidden;
            BtnNuevoCliente.Visibility = Visibility.Visible;
            BtnActualizarCliente.Visibility = Visibility.Visible;
            CheckDeudor.Visibility = Visibility.Visible;
            TxtNombreCliente.IsEnabled = true;
            TxtDeudaCliente.IsEnabled = false;
            TxtDeudaCliente.Text = null;
            TxtNombreCliente.Text = null;
            TxtTelefonoCliente.Text = null;
            LstClientes.ItemsSource = null;
            LstClientes.ItemsSource = cbll.GetClientes();
        }

        private void TxtNombreCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            LstClientes.ItemsSource = null;
            if (!string.IsNullOrEmpty(TxtNombreCliente.Text))
            {
                LstClientes.ItemsSource = cbll.GetClientePorNombre(TxtNombreCliente.Text);
            }
            else { LstClientes.ItemsSource = cbll.GetClientes(); }
            
        }
    }
}
