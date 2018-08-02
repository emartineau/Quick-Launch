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

        public FileInfo File { get; }
        public DirectoryInfo WorkingDirectory { get; set; }
        public string Shell { get; set; } = Path.Combine(Environment.SpecialFolder.System.ToString(), "cmd.exe");
        public bool AsAdmin { get; set; }

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
        /// <param name="useShell">Open a command-line shell, then execute from it.</param>
        public void Start(bool asAdmin = false, bool useShell = false)
        {
            processStart.UseShellExecute = asAdmin;
            processStart.Verb = "runas";

            if (useShell)
            {
                Process.Start(Shell, processStart.Arguments);
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
