using LibrusWP.Model;
using LibrusWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibrusWP.Commands
{
    public class ChangePresenceSelectionCommand: ICommand
    {
        private PresencePageViewModel vm;
        public ChangePresenceSelectionCommand(PresencePageViewModel vm)
        {
            this.vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return parameter is PresenceModel;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var model = parameter as PresenceModel;
            if(model.Present)
            {
                model.Present = false;
            }
            else
            {
                model.Present = true;
            }
        }
    }
}
