using Proyecto_FInal_Administracion_De_Sistemas.UI.Consultas;
using Proyecto_FInal_Administracion_De_Sistemas.UI.Registros;
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

namespace Proyecto_FInal_Administracion_De_Sistemas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static object user;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            rClientes clientes = new rClientes();
            clientes.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            rCondominios condominios = new rCondominios();
            condominios.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            cClientes clientesc = new cClientes();
            clientesc.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            cCondominios condominiosc = new cCondominios();
            condominiosc.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            rRecibos recibos = new rRecibos();
            recibos.Show();
        }
    }
}
