using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuickLaunch.ViewModel
{
    class LauncherOpCommand : ICommand
    {
        private QLViewModel QLViewModel;
        private LauncherOps.LauncherOp LauncherOp;

        public event EventHandler CanExecuteChanged;

        public LauncherOpCommand(QLViewModel qlViewModel, LauncherOps.LauncherOp launcherOp)
        {
            QLViewModel = qlViewModel;
            LauncherOp = launcherOp;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LauncherOp(QLViewModel);
        }
    }
}
