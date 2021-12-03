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

namespace Proyecto_FInal_Administracion_De_Sistemas.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cCondominios.xaml
    /// </summary>
    public partial class cCondominios : Window
    {
        public cCondominios()
        {
            InitializeComponent();
        }

        private void BuscarCriterioButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Condominios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //ClienteId
                        int.TryParse(CriterioTextBox.Text, out int CondominioId);
                        listado = CondominiosBLL.GetList(a => a.CondominioId == CondominioId);
                        break;

                    case 1: //NombreCliente
                        listado = CondominiosBLL.GetList(a => a.Nombre.ToLower().Contains(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = CondominiosBLL.GetList(c => true);
            }

            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = listado;
        }
    }
}
