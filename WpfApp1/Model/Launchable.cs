using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace QuickLaunch.Model
{
    /// <summary>
    /// Makes a specified file or directory launchable by the launcher.
    /// </summary>
    class Launchable
    {
        private ProcessStartInfo processStart;

        public string Name { get; set; }
        public string Description { get; set; }

        public FileInfo File { get; }
        public DirectoryInfo WorkingDirectory { get; set; }

        public bool AsAdmin { get; set; }
        public bool UseShell { get; set; }
        public string Shell { get; set; } = Path.Combine(Environment.SpecialFolder.System.ToString(), "Powershell.exe");

        public FileSystemInfo Info { get; }

        /// <summary>
        /// Launchable constructor.
        /// </summary>
        /// <param name="path">Path of file or directory to be launched.</param>
        /// <param name="arguments">Arguments for execution.</param>
        /// <param name="asAdmin">Execute with administrative priviledges.</param>
        public Launchable(string path, string arguments, bool asAdmin = false)
        {
            Info = new FileInfo(path);
            if (!Info.Exists)
                Info = new DirectoryInfo(path);

            InitializeProcess(arguments);
        }

        /// <summary>
        /// Starts the launchable.
        /// </summary>
        /// <param name="asAdmin">Execute with administrative priviledges.</param>
        public void Start()
        {
            if (AsAdmin)
            {
            processStart.UseShellExecute = AsAdmin;
            processStart.Verb = "runas";
            }

            if (UseShell)
            {
                Process.Start(Shell, processStart.FileName + processStart.Arguments);
            }
            else
            {
                Process p = new Process
                {
                    StartInfo = processStart
                };

                p.Start();
            }
        }

        private void InitializeProcess(string arguments)
        {
            processStart = new ProcessStartInfo(File.FullName)
            {
                Arguments = arguments,
                WorkingDirectory = this.WorkingDirectory.FullName
            };
        }
    }
}
