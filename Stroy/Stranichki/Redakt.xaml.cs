using Microsoft.Win32;
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
            CBType.SelectedValuePath = "ID";
            CBType.DisplayMemberPath = "Title";
            CBType.SelectedIndex = MaterialEdit.MaterialTypeID - 1;

            TBName.Text = MaterialEdit.Title;
            TBSklad.Text = MaterialEdit.CountInStock.ToString();
            TBUpakovka.Text = MaterialEdit.CountInPack.ToString();
            TBEd.Text = MaterialEdit.Unit.ToString();
            TBStoimost.Text = MaterialEdit.Cost.ToString();
            TBMin.Text = MaterialEdit.MinCount.ToString();

            if (MaterialEdit.Image != null)
            {
                BitmapImage BI = new BitmapImage(new Uri(MaterialEdit.Image, UriKind.RelativeOrAbsolute));
                Image.Source = BI;
            }

            CBPost.ItemsSource = DateBase.DB.Supplier.ToList();
            CBPost.SelectedValuePath = "ID";
            CBPost.DisplayMemberPath = "Title";

            List<Supplier> s = new List<Supplier>();

            foreach (MaterialSupplier t in DateBase.DB.MaterialSupplier)
            {
                if (t.MaterialID == MaterialEdit.ID)
                {
                    List<Supplier> tempS = DateBase.DB.Supplier.Where(x => x.ID == t.SupplierID).ToList();
                    s.AddRange(tempS);
                }
            }

            foreach (Supplier sup in s)
            {
                LBTitle.Items.Add(sup);
            }
            LBTitle.SelectedValuePath = "ID";
            LBTitle.DisplayMemberPath = "Title";

        }
        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            LBTitle.Items.RemoveAt(LBTitle.SelectedIndex);
        }

        private void BRedakt_Click(object sender, RoutedEventArgs e)
        {
            List<Supplier> sup = DateBase.DB.Supplier.ToList();
            for (int i = 0; i < LBTitle.Items.Count; i++)
            {
                if (CBPost.DisplayMemberPath[CBPost.SelectedIndex] == LBTitle.DisplayMemberPath[i])
                {
                    MessageBox.Show("Поставщик уже добавлен", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            LBTitle.Items.Add(sup.FirstOrDefault(x => x.ID == CBPost.SelectedIndex + 1));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                path = OFD.FileName;
                int n = path.IndexOf("materials");
                path = path.Substring(n);
                BitmapImage img = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                Image.Source = img;
            }
            catch
            {
                MessageBox.Show("Картинка не выбрана", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BDobav_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MaterialEdit.Title = TBName.Text;
                MaterialEdit.MaterialTypeID = CBType.SelectedIndex + 1;
                MaterialEdit.CountInStock = Convert.ToSingle(TBSklad.Text);
                MaterialEdit.Unit = TBEd.Text;
                MaterialEdit.CountInPack = Convert.ToInt32(TBUpakovka.Text);
                MaterialEdit.MinCount = Convert.ToInt32(TBMin.Text);
                MaterialEdit.Cost = Convert.ToDecimal(TBStoimost.Text);
                MaterialEdit.Description = TBOpis.Text;
                MaterialEdit.Image = path;
                if (IsCreate == true)
                {
                    DateBase.DB.Material.Add(MaterialEdit);
                }
                DateBase.DB.SaveChanges();
                List<MaterialSupplier> materialSuppliersOld = MS.Where(x => x.MaterialID == MaterialEdit.ID).ToList();
                if (materialSuppliersOld.Count != 0)
                {
                    foreach (MaterialSupplier ms in materialSuppliersOld)
                    {
                        DateBase.DB.MaterialSupplier.Remove(ms);
                    }
                }
                foreach (Supplier t in LBTitle.Items)
                {
                    MaterialSupplier ms = new MaterialSupplier();
                    ms.MaterialID = MaterialEdit.ID;
                    ms.SupplierID = t.ID;
                    DateBase.DB.MaterialSupplier.Add(ms);
                }
                DateBase.DB.SaveChanges();
                MessageBox.Show("Данные записаны", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось записать данные, повторите попытку", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BRemove_Click(object sender, RoutedEventArgs e)
        {
            if (IsCreate == true)
            {
                MessageBox.Show("Невозможно удалить запись, так как она еще не существует", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Редактирование", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                DateBase.DB.Material.Remove(MaterialEdit);
                DateBase.DB.SaveChanges();
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
