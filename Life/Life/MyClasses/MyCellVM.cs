using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Life
{
    public class MyCellVM : BindableBase
    {
        public DispatcherTimer Timer { get; set; }
        public MyCellsModel MyCellsModel { get; set; }
        public ObservableCollection<MyCell> MyCells
        {
            get => MyCellsModel.MyCells;
            set
            {
                SetModelProperty(() => MyCellsModel.MyCells, newValue => MyCellsModel.MyCells = newValue, value, nameof(MyCells));
            }
        }


        public MyCellVM( Setting setting)
        {
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(timer_Tick);
            Timer.Interval = TimeSpan.FromSeconds(0.5);

            

            MyCellsModel = new MyCellsModel();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MyCellsModel.RefreshCells();
        }

        public ICommand RandFillingField
        {
            get => new DelegeteCommand(() => MyCellsModel.RandFilling());
        }
        public ICommand ClearField
        {
            get => new DelegeteCommand(() => MyCellsModel.ClearCells());
        }
        public ICommand NextFrame
        {
            get => new DelegeteCommand(() => MyCellsModel.RefreshCells());
        }
        public ICommand PausePlay
        {
            get => new DelegeteCommand(() => Timer.IsEnabled=!Timer.IsEnabled);
        }

        private bool SetModelProperty<T>(Func<T> get, Action<T> set, T value, string propName)
        {
            if (get().Equals(value)) return false;
            set(value);
            RaisePropertyChanged(propName);
            return true;
        }

    }
}
