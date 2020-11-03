using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WilsonGomez_P2_AP1.UI.Registro
{
    /// <summary>
    /// Lógica de interacción para rPartidas.xaml
    /// </summary>
    public partial class rPartidas : Window
    {
        public Proyectos Proyectos;
        public rPartidas()
        {
            InitializeComponent();
            Proyectos = new Proyectos();
            this.DataContext = Proyectos;

            DetallesDataGrid.ItemsSource = new List<ProyectosDetalle>();

            TipoTareaIdComboBox.ItemsSource = TiposTareaBLL.GetTiposTareas();
            TipoTareaIdComboBox.SelectedValuePath = "TipoId";
            TipoTareaIdComboBox.DisplayMemberPath = "Descripcion";
        }

        public bool Existe()
        {
            var proyecto = ProyectosBLL.Buscar(Convert.ToInt32(IdTextbox.Text));

            return proyecto != null;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = Proyectos;
            DetallesDataGrid.ItemsSource = Proyectos.DetalleProyecto;
        }

        private void Limpiar()
        {
            this.Proyectos = new Proyectos();
            this.DataContext = this.Proyectos;

            DetallesDataGrid.ItemsSource = new List<ProyectosDetalle>();
            Actualizar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos anterior = ProyectosBLL.Buscar(Convert.ToInt32(IdTextbox.Text));

            if (anterior != null)
            {
                Proyectos = anterior;
                Actualizar();
                MessageBox.Show("Proyecto encontrado!!!!!");
            }
            else
            {
                MessageBox.Show("Lo sentimos.\nEl proyecto buscado no ha podido ser encontrado.");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarTarea())
            {
                this.Proyectos.DetalleProyecto.Add(new ProyectosDetalle(Convert.ToInt32(IdTextbox.Text), Convert.ToInt32(TipoTareaIdComboBox.SelectedValue) + 1, RequerimientoTextbox.Text, Convert.ToInt32(TiempoTextbox.Text)));
                this.Proyectos.DetalleProyecto.Where(a => true).Select(a => new { Descripcion = $"{TiposTareaBLL.Buscar(a.TipoTareaId).Descripcion}" });
                Proyectos.TiempoTotal = 0;
                foreach (ProyectosDetalle detalle in Proyectos.DetalleProyecto)
                {
                    Proyectos.TiempoTotal += detalle.Tiempo;
                }
                Actualizar();
            }
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            this.Proyectos.DetalleProyecto.RemoveAt(DetallesDataGrid.FrozenColumnCount);
            Proyectos.TiempoTotal = 0;
            foreach (ProyectosDetalle detalle in Proyectos.DetalleProyecto)
            {
                Proyectos.TiempoTotal += detalle.Tiempo;
            }
            Actualizar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool guardado = false;

            if (ValidarProyecto())
            {
                Proyectos.Fecha = Convert.ToDateTime(FechaDatePicker.SelectedDate.ToString());
                Proyectos.Descripcion = DescripcionTextbox.Text;

                if (string.IsNullOrWhiteSpace(IdTextbox.Text) || IdTextbox.Text == "0")
                    guardado = ProyectosBLL.Guardar(Proyectos);
                else
                {
                    if (!Existe())
                    {
                        MessageBox.Show("Este proyecto no se puede modificar \nporque no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    guardado = ProyectosBLL.Modificar(Proyectos);
                }

                if (guardado)
                {
                    Limpiar();
                    MessageBox.Show("El proyecto ha sido guardado correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("El proyecto no ha podido ser guardado.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Eliminar(Convert.ToInt32(IdTextbox.Text)))
            {
                MessageBox.Show("El proyecto ha sido eliminado correctamente.", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("El proyecto no pudo ser eliminado.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarProyecto()
        {
            bool EsValido = true;

            if (!ValidarCasillaNumerica(IdTextbox.Text))
            {
                EsValido = false;
                MessageBox.Show("La casilla Proyecto ID no puede tener \nni letras ni caracteres especiales.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!ValidarCasillaTexto(DescripcionTextbox.Text))
            {
                EsValido = false;
                MessageBox.Show("La casilla Descripcion no puede tener caracteres especiales.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (FechaDatePicker.SelectedDate > DateTime.Now)
            {
                EsValido = false;
                MessageBox.Show("La fecha seleccionada no puede ser mayor a la fecha actual.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            return EsValido;
        }

        private bool ValidarTarea()
        {
            bool EsValido = true;

            if (ValidarCasillaTexto(RequerimientoTextbox.Text))
            {
                EsValido = false;
                MessageBox.Show("La casilla Requerimiento no puede tener caracteres especiales.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!ValidarCasillaNumerica(TiempoTextbox.Text))
            {
                EsValido = false;
                MessageBox.Show("La casilla Tiempo no puede tener \nni letras ni caracteres especiales.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Convert.ToInt32(TipoTareaIdComboBox.SelectedValue) < 1)
            {
                EsValido = false;
                MessageBox.Show("Tiene que seleccionar un tipo de tarea", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return EsValido;
        }

        private bool ValidarCasillaNumerica(string texto)
        {
            foreach (char invalido in texto.ToCharArray())
            {
                if (!Char.IsDigit(invalido))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidarCasillaTexto(string texto)
        {
            List<char> invalidos = new List<char>() { '¡', '!', '@', '@', '+', '*', '\\', '/', '<', '>', '|', ':', ';', '¿', '?'};
            
            foreach (char invalido in texto.ToCharArray())
            {
                if (!Char.IsLetterOrDigit(invalido))
                {
                    return false;
                }

                if (invalidos.Contains(invalido))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
