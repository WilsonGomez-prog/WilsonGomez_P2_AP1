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
using WilsonGomez_P2_AP1.UI.Consultas;
using WilsonGomez_P2_AP1.UI.Registro;

namespace WilsonGomez_P2_AP1
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

        private void rPartidasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPartidas rPartidas = new rPartidas();

            rPartidas.Show();
        }

        private void cPartidasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cPartidas cPartidas = new cPartidas();

            cPartidas.Show();
        }
    }
}
