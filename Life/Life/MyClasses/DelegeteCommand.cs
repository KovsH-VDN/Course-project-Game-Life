using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Life
{
    class DelegeteCommand : ICommand
    {
        private Action execute;

        public DelegeteCommand(Action execute) => this.execute = execute;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => execute();


        public event EventHandler CanExecuteChanged;

    }
}
