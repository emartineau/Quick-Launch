using QuickLaunch.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

            string makePath(string path) => Path.Combine(Environment.CurrentDirectory, @"ApplicationData\", path);

            Launchables.Add("SlideShow", new LaunchableFile(makePath(@"Demo\FileSlideShow.exe"), "", ""));
            Launchables.Add("PowerShell-Project", new LaunchableDirectory(makePath(@"Demo\"), "", true));
            Launchables.Add("Py Batch Save", new LaunchableFile(makePath(@"Demo\BatchSave.py"), "", "", false, false, "/C python"));
            Launchables.Add("Py Dupe Check", new LaunchableFile(makePath(@"Demo\DupeCheck.py"), "", "Collection", false, false, "/C python"));

            InitCommands();

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
                LaunchableExecutables.Add(launchable.Key, new RelayCommand(() => launchable.Value.Start(), () => launchable.Value.CanLaunch));
            }
        }
    }
}
