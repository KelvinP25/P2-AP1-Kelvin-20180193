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
    /// Interaction logic for cProyecto.xaml
    /// </summary>
    public partial class cProyecto : Window
    {
        public cProyecto()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Proyectos>();
            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    //case 0:
                    //    if(DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                    //    {
                    //        listado = ProyectosBLL.GetList(e => e.ProyectoId == UtilidadesBLL.ToInt(CriterioTextBox.Text))
                    //    }
                }
            }
        }
    }
}
