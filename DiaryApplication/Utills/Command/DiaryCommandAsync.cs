using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Utills.Command
{
    public class DiaryCommandAsync : AsyncCommandBase
    {
        private readonly Func<Task> command;
        public DiaryCommandAsync(Func<Task> command)
        {
            this.command = command;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override Task ExecuteAsync(object parameter)
        {
            return command();
        }
    }
}
