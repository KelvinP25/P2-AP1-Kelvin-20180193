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

namespace P2_KELVIN_20180193.UI.Registro
{
    /// <summary>
    /// Interaction logic for rProyecto.xaml
    /// </summary>
    public partial class rProyecto : Window
    {
        private Proyectos proyectos = new Proyectos();
        private ProyectosDetalle detalles = new ProyectosDetalle();
        public rProyecto()
        {
            InitializeComponent();

            TipoTareaComboBox.ItemsSource = TipoTareasBLL.GetTiposTarea();
            TipoTareaComboBox.SelectedValuePath = "TipoTareaId";
            TipoTareaComboBox.DisplayMemberPath = "DescripcionTipoTarea";
            TotalTextBox.Text = "0";
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = proyectos;
        }
        private void Limpiar()
        {
            this.DataContext = new Proyectos();
            this.DataContext = proyectos;
        }
        private bool ExisteEnDB()
        {
            Proyectos esValido = ProyectosBLL.Buscar(proyectos.ProyectoId);

            return (esValido != null);
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos encontrado = ProyectosBLL.Buscar(proyectos.ProyectoId);

            if(encontrado != null)
            {
                proyectos = encontrado;
                Actualizar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("EL proyecto no existe en la base de datos", "fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            proyectos.Detalle.Add(new ProyectosDetalle(UtilidadesBLL.ToInt(ProyectoIdTextBox.Text), (int)TipoTareaComboBox.SelectedValue,
                RequerimientoTextBox.Text, UtilidadesBLL.ToInt(TiempoTextBox.Text), (TipoTareas)TipoTareaComboBox.SelectedItem, proyectos));

            TotalTextBox.Text = proyectos.Total.ToString();
            Actualizar();
            TotalTextBox.Focus();
            TotalTextBox.Clear();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if(DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                proyectos.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                proyectos.Total -= UtilidadesBLL.ToInt(TotalTextBox.Text);
                Actualizar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if(proyectos.ProyectoId==0){
                paso = ProyectosBLL.Guardar(proyectos);
            }
            else
            {
                if (ExisteEnDB())
                {
                    paso = ProyectosBLL.Guardar(proyectos);
                }
                else
                {
                    MessageBox.Show("No Existe en Base de Datos", "ERROR");

                }
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar", "fallo",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos existe = ProyectosBLL.Buscar(proyectos.ProyectoId);

            if(existe == null)
            {
                MessageBox.Show("No existe en la base de datos", "fallo",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ProyectosBLL.Eliminar(proyectos.ProyectoId);
                MessageBox.Show("Eliminado", "Exito",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    
    }
}
