using Stroy.Class;
using Stroy.Stranichki;
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

namespace Stroy
{

    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();
            DateBase.DB = new Entities1();
            FrameClass.FrameMain = FrmMain;
            FrameClass.FrameMain.Navigate(new AdminList());

        }
    }
}
