using QuickLaunch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuickLaunch.ViewModel
{
    class QLViewModel
    {
        public readonly ILauncher Launcher;

        public Dictionary<string, ILaunchable> Launchables { get => Launcher.Launchables; set => Launcher.Launchables = value; }
        public ICommand SaveConfig { get; set; }

        public QLViewModel()
        {
            Launcher = new Launcher();
        }

        private void InitCommands()
        {
            SaveConfig = new RelayCommand(() => Launcher.WriteToFile(), () => true);
        }
    }
}
