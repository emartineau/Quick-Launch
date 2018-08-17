using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Model
{
    class LaunchableDirectory : ILaunchable
    {
        public FileSystemInfo Info { get; }

        public ProcessStartInfo ProcessStart { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DirectoryInfo WorkingDirectory { get; set; }

        public bool CanLaunch { get => Directory.Exists(Info.FullName); }
        public bool AsAdmin { get; set; }
        public bool UseShell { get; set; }

        public string Shell { get; set; } = Path.Combine(Environment.SpecialFolder.System.ToString(), "Powershell.exe");
        public string ShellPrefix { get; set; }

        public LaunchableDirectory(string path, string arguments, bool asAdmin = false) { }

        public void Start()
        {
            if (UseShell)
            {
                ProcessStart.WorkingDirectory = Info.FullName;
            }
            else
            {
                Process.Start("explorer.exe", Info.FullName);
            }
        }
    }
}
