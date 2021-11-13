using P2_KELVIN_20180193.BLL;
using P2_KELVIN_20180193.Entidades;
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

namespace P2_KELVIN_20180193.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cTipoTareas.xaml
    /// </summary>
    public partial class cTipoTareas : Window
    {
        public cTipoTareas()
        {
            InitializeComponent();
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<TipoTareas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                        listado = TipoTareasBLL.GetTiposTarea();
                        break;
                    case 1: 
                        listado = TipoTareasBLL.GetList(e => e.TipoTareaId == UtilidadesBLL.ToInt(CriterioTextBox.Text));
                        break;
                    case 2: 
                        listado = TipoTareasBLL.GetList(e => e.DescripcionTipoTarea.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 3:
                        listado = TipoTareasBLL.GetList(e => e.TiempoAcumulado == UtilidadesBLL.ToInt(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = TipoTareasBLL.GetList(e => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
