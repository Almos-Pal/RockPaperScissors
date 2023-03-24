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

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for Gameover.xaml
    /// </summary>
    public partial class Gameover : Window
    {
        public Gameover()
        {
            InitializeComponent();
        }

        private void MainWindow(object sender, RoutedEventArgs e)
        {
            RockPaperScissors.MainWindow p = new RockPaperScissors.MainWindow();
            p.Show();
            this.Close();
        }
        private void StatsWindow(object sender, RoutedEventArgs e)
        {
            RockPaperScissors.StatsWindow p = new RockPaperScissors.StatsWindow();
            p.Show();
            this.Close();
        }

    }
}
