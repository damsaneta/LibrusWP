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
    public class ChangeSubjectSelectionCommand: ICommand
    {
        private SelectionPageViewModel vm;
        public ChangeSubjectSelectionCommand(SelectionPageViewModel vm)
        {
            this.vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return parameter is SubjectModel;
        }

        public event EventHandler CanExecuteChanged;
      
        public void Execute(object parameter)
        {
            var model = parameter as SubjectModel;
            if(model.IsSelected)
            {
                return;
            }
            this.vm.SelectSubject(model);    
        }   
        
    }
}
