using P2_KELVIN_20180193.UI.Consulta;
using P2_KELVIN_20180193.UI.Registro;
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

namespace P2_KELVIN_20180193
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TipoTareasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cTipoTareas consulta = new cTipoTareas();
            consulta.Show();
        }

        private void ProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProyecto registro = new rProyecto();
            registro.Show();
        }

        private void ProyectoCMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cProyecto proy = new cProyecto();
            proy.Show();
        }
    }
}
