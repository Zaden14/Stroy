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
    /// Логика взаимодействия для Redakt.xaml
    /// </summary>
    public partial class Redakt : Window
    {
        string path;
        bool IsCreate = false;
        List<MaterialSupplier> MS = DateBase.DB.MaterialSupplier.ToList();
        public Redakt()
        {
            InitializeComponent();
            CBType.ItemsSource = DateBase.DB.MaterialType.ToList();
            CBType.SelectedValuePath = "ID";
            CBType.DisplayMemberPath = "Title";

            CBPost.ItemsSource = DateBase.DB.Supplier.ToList();
            CBPost.SelectedValuePath = "ID";
            CBPost.DisplayMemberPath = "Title";
            IsCreate = true;
            LBTitle.SelectedValuePath = "ID";
            LBTitle.DisplayMemberPath = "Title";
        }
        Material MaterialEdit = new Material();
        public Redakt(Material editImport)
        {
            InitializeComponent();
            MaterialEdit = editImport;

            CBType.ItemsSource = DateBase.DB.MaterialType.ToList();

        }

        private void CBName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CBTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BRedakt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
