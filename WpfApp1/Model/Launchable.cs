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
    abstract class Launchable
    {
        protected ProcessStartInfo processStart;

        public string Name { get; set; }
        public string Description { get; set; }
        
        public FileSystemInfo Info { get; }
        public DirectoryInfo WorkingDirectory { get; set; }

        public bool AsAdmin { get; set; }
        public bool UseShell { get; set; }
        public string Shell { get; set; } = Path.Combine(Environment.SpecialFolder.System.ToString(), "Powershell.exe");
        public string ShellPrefix { get; set; } //precedes filepath to execute via a PATH variable i.e. "Python'


        /// <summary>
        /// Launchable constructor.
        /// </summary>
        /// <param name="path">Path of file or directory to be launched.</param>
        /// <param name="arguments">Arguments for execution.</param>
        /// <param name="asAdmin">Execute with administrative priviledges.</param>
        public Launchable(string path, string arguments, bool asAdmin = false)
        {
        }

        /// <summary>
        /// Starts the launchable.
        /// </summary>
        public abstract void Start();
    }
}
