using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Model
{
    public class LaunchableFile : ILaunchable
    {
        public FileInfo Info { get; }

        public ProcessStartInfo ProcessStart { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DirectoryInfo WorkingDirectory { get; set; }

        public bool CanLaunch { get => File.Exists(Info.FullName); }
        public bool AsAdmin { get; set; }
        public bool UseShell { get; set; }

        public string Shell { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"System32\cmd.exe");
        public string ShellPrefix { get; set; } // e.g. "python " to start a python scipt

        public LaunchableFile(string filePath, string dirPath = "", string arguments = "", bool useShell = false, bool asAdmin = false, string shellPrefix = "")
        {
            Info = new FileInfo(filePath);
            WorkingDirectory = new DirectoryInfo(string.IsNullOrEmpty(dirPath) ? Path.GetDirectoryName(filePath) : dirPath);
            Name = Info.Name;
            ShellPrefix = shellPrefix;
            AsAdmin = asAdmin;
            UseShell = useShell;
            InitializeProcess(arguments);
        }

        public void Start()
        {
            Process.Start(ProcessStart);
        }

        private void InitializeProcess(string arguments)
        {
            ProcessStart = new ProcessStartInfo(Info.FullName)
            {
                Arguments = arguments,
                WorkingDirectory = this.WorkingDirectory.FullName
            };

            if (AsAdmin)
            {
                ProcessStart.UseShellExecute = AsAdmin;
                ProcessStart.Verb = "runas";
            }

            if (UseShell)
            {
                ProcessStart.UseShellExecute = UseShell;
                ProcessStart.Arguments = $"{ ShellPrefix } { ProcessStart.FileName } { ProcessStart.Arguments }";
                ProcessStart.FileName = Shell;
            }
        }
    }
}
