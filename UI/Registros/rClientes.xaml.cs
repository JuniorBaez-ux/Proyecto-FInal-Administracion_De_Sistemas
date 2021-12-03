using Proyecto_FInal_Administracion_De_Sistemas.BLL;
using Proyecto_FInal_Administracion_De_Sistemas.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_FInal_Administracion_De_Sistemas.UI.Registros
{
    /// <summary>
    /// Interaction logic for rClientes.xaml
    /// </summary>
    public partial class rClientes : Window
    {
        private Clientes cliente = new Clientes();
        public rClientes()
        {
            cliente = new Clientes();
            InitializeComponent();
            this.DataContext = cliente;
            LLenarComboCondominio();
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var Cliente = ClientesBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (Cliente != null)
            {
                this.cliente = Cliente;
            }
            else
            {
                this.cliente = new Clientes();
                MessageBox.Show("Este Cliente no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            GuardarComboBox();
            var paso = ClientesBLL.Guardar(this.cliente);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Informacion almacenada correctamente!");
            }
            else
                MessageBox.Show("La informacion no pudo ser almacenada correctamente.");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes existe = ClientesBLL.Buscar(this.cliente.ClienteId);

            if (ClientesBLL.Eliminar(this.cliente.ClienteId))
            {
                Limpiar();
                MessageBox.Show("Su cliente ha sido eliminado con exito");
            }
            else
            {
                MessageBox.Show("No fue posible eliminarlo");
            }
        }

        private void Limpiar()
        {
            cliente = new Clientes();
            Cargar();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un nombre!");
            }
            if (CedulaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un numero de cedula!");
            }
            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar un numero de telefono!");
            }
            if (DireccionTextBox.Text.Length <= 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar una direccion!");
            }
            if (ClientesBLL.ExisteCedula(CedulaTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Debe ingresar una cedula que no exista....");
            }
            if (!CedulaTextBox.Text.Contains("-"))
            {
                esValido = false;
                MessageBox.Show("Debe arreglar el formato de la cedula ....");
            }
            if (!TelefonoTextBox.Text.Contains("-") && !TelefonoTextBox.Text.Contains("-"))
            {
                esValido = false;
                MessageBox.Show("Debe arreglar el formato del telefono....");
            }
            return esValido;
        }

        private void LLenarComboCondominio()
        {
            this.CondominioComboBox.ItemsSource = CondominiosBLL.GetList(x => true);
            this.CondominioComboBox.SelectedValuePath = "CondominioId";
            this.CondominioComboBox.DisplayMemberPath = "Nombre";

            if (CondominioComboBox.Items.Count > 0)
            {
                CondominioComboBox.SelectedIndex = 0;
            }
        }

        private void GuardarComboBox()
        {
            cliente.CondominioId = CondominioComboBox.SelectedValue.ToString().ToInt();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.cliente;
        }
    }
}
