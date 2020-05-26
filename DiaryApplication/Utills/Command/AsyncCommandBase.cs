using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Utills.Command
{
    public abstract class AsyncCommandBase : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);
        public abstract Task ExecuteAsync(object parameter);
        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
    }
}
