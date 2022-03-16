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

namespace Stroy.Stranichki
{
    /// <summary>
    /// Логика взаимодействия для MinIzmen.xaml
    /// </summary>
    public partial class MinIzmen : Window
    {
        public MinIzmen(double max)
        {
            InitializeComponent();
            TBIzm.Text = max.ToString();
        }
        double newMinCount = 0;
        private void BIzm_Click(object sender, RoutedEventArgs e)
        {
            newMinCount = Convert.ToDouble(TBIzm.Text);
            this.Close();
        }
        public double NewMineCount
        {
            get
            {
                return newMinCount;
            }
        }
    }
}
