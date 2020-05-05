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
using System.Windows.Threading;

namespace Life
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private MyCellVM myCellVm;

        public Game(MyCellVM myCellVm)
        {
            InitializeComponent();
            
            this.myCellVm = myCellVm;
            myCellVm.MyCellsModel.RandFilling();
            myCellVm.Timer.Start();

            DataContext = myCellVm;
        }
        private void Move(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void IsCheckedBoxis(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && ((CheckBox)sender).IsChecked != true)
                ((CheckBox)sender).IsChecked = !((CheckBox)sender).IsChecked;
            else if (e.RightButton == MouseButtonState.Pressed && ((CheckBox)sender).IsChecked != false)
                ((CheckBox)sender).IsChecked = !((CheckBox)sender).IsChecked;
        }
        private void Leave(object sender, MouseButtonEventArgs e)
        {
            IsCheckedBoxis(sender, e);
            e.Handled = true;
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
        private void Back(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
