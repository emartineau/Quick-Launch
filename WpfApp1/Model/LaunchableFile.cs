using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Model
{
    class LaunchableFile : ILaunchable
    {
        public FileSystemInfo Info { get; }

        public ProcessStartInfo ProcessStart { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DirectoryInfo WorkingDirectory { get; set; }

        public bool CanLaunch { get => File.Exists(Info.FullName); }
        public bool AsAdmin { get; set; }
        public bool UseShell { get; set; }

        public string Shell { get; set; } = Path.Combine(Environment.SpecialFolder.System.ToString(), "Powershell.exe");
        public string ShellPrefix { get; set; }

        public LaunchableFile(string path, string arguments, bool asAdmin = false)
        {
            InitializeProcess(arguments);
        }

        public void Start()
        {
            if (AsAdmin)
            {
                ProcessStart.UseShellExecute = AsAdmin;
                ProcessStart.Verb = "runas";
            }

            if (UseShell)
            {
                Process.Start(Shell, ShellPrefix + ProcessStart.FileName + ProcessStart.Arguments);
            }
            else
            {
                Process p = new Process
                {
                    StartInfo = ProcessStart
                };

                p.Start();
            }
        }

        private void InitializeProcess(string arguments)
        {
            ProcessStart = new ProcessStartInfo(Info.FullName)
            {
                Arguments = arguments,
                WorkingDirectory = this.WorkingDirectory.FullName
            };
        }
    }
}
