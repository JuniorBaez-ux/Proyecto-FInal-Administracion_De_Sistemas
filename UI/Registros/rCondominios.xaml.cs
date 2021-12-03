using Proyecto_FInal_Administracion_De_Sistemas.BLL;
using Proyecto_FInal_Administracion_De_Sistemas.Entidades;
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

namespace Proyecto_FInal_Administracion_De_Sistemas.UI.Registros
{
    /// <summary>
    /// Interaction logic for rCondominios.xaml
    /// </summary>
    public partial class rCondominios : Window
    {
        private Condominios condominios = new Condominios();
        public rCondominios()
        {
            condominios = new Condominios();
            InitializeComponent();
            this.DataContext = condominios;
            LLenarComboCondominio();
            
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var Condominios = CondominiosBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (Condominios != null)
            {
                this.condominios = Condominios;
            }
            else
            {
                this.condominios = new Condominios();
                MessageBox.Show("Este Condominio no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var paso = CondominiosBLL.Guardar(this.condominios);

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
            Condominios existe = CondominiosBLL.Buscar(this.condominios.CondominioId);

            if (CondominiosBLL.Eliminar(this.condominios.CondominioId))
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
            condominios = new Condominios();
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
            if (IdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un ID!");
            }
            if (CostoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un Precio!");
            }
            return esValido;
        }

        private void LLenarComboCondominio()
        {
            this.TipoComboBox.ItemsSource = TipoCondominiosBLL.GetList(x => true);
            this.TipoComboBox.SelectedValuePath = "TipoCondominioId";
            this.TipoComboBox.DisplayMemberPath = "Tipo";

            if (TipoComboBox.Items.Count > 0)
            {
                TipoComboBox.SelectedIndex = 0;
            }
        }

        private void GuardarComboBox()
        {
            condominios.TipoCondominiosId = TipoComboBox.SelectedValue.ToString().ToInt();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.condominios;
        }
    }
}
