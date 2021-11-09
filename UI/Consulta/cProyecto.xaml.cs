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
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.ProyectoId == UtilidadesBLL.ToInt(CriterioTextBox.Text)
                            && e.Fecha.Date <= HastaDatePicker.SelectedDate && e.Fecha.Date >= DesdeDatePicker.SelectedDate);


                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.ProyectoId == UtilidadesBLL.ToInt(CriterioTextBox.Text)
                           && e.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.ProyectoId == UtilidadesBLL.ToInt(CriterioTextBox.Text)
                           && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProyectosBLL.GetList(e => e.ProyectoId == UtilidadesBLL.ToInt(CriterioTextBox.Text));
                        }
                        break;

                    case 1:
                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower())
                            && e.Fecha.Date <= HastaDatePicker.SelectedDate && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower())
                             && e.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower())
                            && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProyectosBLL.GetList(e => e.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower()));
                        }
                        break;
                    case 2:
                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.Total.Equals(UtilidadesBLL.ToInt(CriterioTextBox.Text))
                            && e.Fecha.Date <= HastaDatePicker.SelectedDate && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.Total.Equals(UtilidadesBLL.ToInt(CriterioTextBox.Text))
                             && e.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(e => e.Total.Equals(UtilidadesBLL.ToInt(CriterioTextBox.Text))
                            && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProyectosBLL.GetList(e => e.Total.Equals(UtilidadesBLL.ToInt(CriterioTextBox.Text)));
                        }
                        break;
                }
            }
            else
            {
                listado = ProyectosBLL.GetList(e => true);
            }
            if(DesdeDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex <0)
            {
                listado = ProyectosBLL.GetList(e => e.Fecha.Date >= DesdeDatePicker.SelectedDate);
            }
            if (HastaDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = ProyectosBLL.GetList(e => e.Fecha.Date <= HastaDatePicker.SelectedDate);
            }
            if((DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0))
            {
                listado = ProyectosBLL.GetList(e => e.Fecha.Date >= DesdeDatePicker.SelectedDate && e.Fecha.Date <= HastaDatePicker.SelectedDate);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
