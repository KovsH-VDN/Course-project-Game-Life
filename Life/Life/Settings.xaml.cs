using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Life
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Setting Setting { get; set; }

        public Settings(Setting setting)
        {
            Setting = new Setting(setting);
            DataContext = Setting;

            InitializeComponent();
        }


        private void Move(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        

        private void Minimized(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Maximized(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;

            else if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private void CancelBack(object sender, RoutedEventArgs e)
        {
            Exit(sender, e);
        }
        private void OkBack(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
