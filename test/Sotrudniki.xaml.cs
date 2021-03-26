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

namespace test
{
    /// <summary>
    /// Логика взаимодействия для Sotrudniki.xaml
    /// </summary>
    public partial class Sotrudniki : UserControl
    {
        public Sotrudniki()
        {
            InitializeComponent();
            for(int i = 0; i < 20; i++)
            {
                data.Children.Add(new kartochka());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.openClose(new Menu(),false);
        }
    }
}
