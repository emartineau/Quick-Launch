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

        public QLViewModel()
        {
            Launcher = new Launcher();
        }

        public IDictionary<string, ILaunchable> Launchables { get => Launcher.Launchables; set => Launcher.Launchables = value; }
        public IDictionary<string ,ICommand> LaunchableExecutables { get; set; }
        public ICommand SaveConfig { get; set; }

        private void InitCommands()
        {
            SaveConfig = new RelayCommand(() => Launcher.WriteToFile(), () => true);

            LaunchableExecutables = new Dictionary<string, ICommand>();
            foreach (var launchable in Launchables)
            {
                LaunchableExecutables.Add(launchable.Value.Name, new RelayCommand(() => launchable.Value.Start(), () => launchable.Value.CanLaunch));
            }
        }
    }
}
