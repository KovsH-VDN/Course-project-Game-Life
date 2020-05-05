using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace Life
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyCellVM myCellVm;

        public MainWindow()
        {
            myCellVm = new MyCellVM(new Setting());

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
            Close();
        }


        private void NewGame(object sender, RoutedEventArgs e)
        {
            Game game = new Game(myCellVm);

            Visibility = Visibility.Collapsed;
            var res = game.ShowDialog();



            if (res == false)
                Close();
            else if (res == true)
            {
                Visibility = Visibility.Visible;
            }
        }
        private void NewSetting(object sender, RoutedEventArgs e)
        {
            Settings setting = new Settings(myCellVm.MyCellsModel.Setting);

            Visibility = Visibility.Collapsed;
            var res = setting.ShowDialog();



            if (res == false)
            {
                Visibility = Visibility.Visible;
            }
            else if (res == true)
            {
                Visibility = Visibility.Visible;
                myCellVm.MyCellsModel.Setting = setting.Setting;
            }
        }
        
    }
}
