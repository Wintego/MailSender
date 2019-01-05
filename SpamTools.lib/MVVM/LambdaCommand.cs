using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpamTools.lib.MVVM
{
    public class LambdaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private Action<object> _OnExecuteAction;
        private Func<object, bool> _CanExecuteFunc;
        public LambdaCommand(Action<object> OnExecuteAction, Func<object, bool> CanExecuteFunc)
        {
            _OnExecuteAction = OnExecuteAction;
            _CanExecuteFunc = CanExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecuteFunc?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _OnExecuteAction?.Invoke(parameter);
        }
    }
}
