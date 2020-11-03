using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WilsonGomez_P2_AP1.BLL;
using WilsonGomez_P2_AP1.Entidades;

namespace WilsonGomez_P2_AP1.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para cPartidas.xaml
    /// </summary>
    public partial class cPartidas : Window
    {
        public cPartidas()
        {
            InitializeComponent();

            DesdeDataPicker.SelectedDate = Convert.ToDateTime("1/01/0001");
            HastaDataPicker.SelectedDate = DateTime.Now;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Proyectos>();
            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                listado = ProyectosBLL.GetList(e => true);
            }
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProyectosBLL.GetList(e => e.ProyectoId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                    case 1:
                        listado = ProyectosBLL.GetList(e => e.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                }
            }

            listado = ProyectosBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate && c.Fecha.Date <= HastaDataPicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
