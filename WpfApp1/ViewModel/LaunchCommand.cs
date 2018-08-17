using QuickLaunch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuickLaunch.ViewModel
{
    class LaunchCommand : ICommand
    {
        private ILaunchable Launchable;

        public LaunchCommand(ILaunchable launchable)
        {
            Launchable = launchable;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; //TODO: Block if launchable file/folder path does not currently exist.
        }

        public void Execute(object parameter)
        {
            Launchable.Start();
        }
    }
}
