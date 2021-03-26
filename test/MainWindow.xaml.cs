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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool closeOpenanim = false;
        List<UserControl> ls = new List<UserControl>()
        {
            new Menu()
        };
        static List<UserControl> state = new List<UserControl>();
        public MainWindow()
        {
            InitializeComponent();
            openClose(ls[0],false);

        }

        public static void openClose(UserControl uc,bool open = true)
        {
            if (closeOpenanim) return;
            closeOpenanim = true;

            ThicknessAnimation ta = new ThicknessAnimation();
            
            ThicknessAnimation ta2 = new ThicknessAnimation();
            ThicknessAnimation ta3 = new ThicknessAnimation();
            if (open)
            {
                ta = new ThicknessAnimation(new Thickness(0, 708, 0, 0), new Duration(TimeSpan.FromSeconds(0.5)));
                ta2 = new ThicknessAnimation(new Thickness(51, 40, 51, 40), new Duration(TimeSpan.FromSeconds(0.5)));
                ta3 = new ThicknessAnimation(new Thickness(46, 12, 46, 12), new Duration(TimeSpan.FromSeconds(0.5)));
            }
            else
            {
                ta = new ThicknessAnimation(new Thickness(0, 60, 0, 0), new Duration(TimeSpan.FromSeconds(0.5)));
                ta2 = new ThicknessAnimation(new Thickness(51, 50, 51, 698), new Duration(TimeSpan.FromSeconds(0.5)));
                ta3 = new ThicknessAnimation(new Thickness(46, 9, 46, 9), new Duration(TimeSpan.FromSeconds(0.5)));
            }
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            if (!open)
            {
                state.Add(uc);
                mainWindow.telo.Children.Clear();
            }
            ta.Completed += ta_Completed;
            
            mainWindow.bottom.BeginAnimation(MarginProperty, ta);
            mainWindow.body.BeginAnimation(MarginProperty, ta2);
            mainWindow.bottomscroll.BeginAnimation(MarginProperty, ta3);
            mainWindow.headerscroll.BeginAnimation(MarginProperty, ta3);
        }
        static private void ta_Completed(object sender, EventArgs e)
        {
            closeOpenanim = false;
            if (state.Count > 0)
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.telo.Children.Add(state[0]);
                state.Remove(state[0]);
                openClose(null);
            }

            
            
            
        }

        private void bottom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
