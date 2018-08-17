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
    interface ILaunchable
    {
        ProcessStartInfo ProcessStart { get; }

        string Name { get; set; }
        string Description { get; set; }
        
        FileSystemInfo Info { get; }
        DirectoryInfo WorkingDirectory { get; set; }

        bool CanLaunch { get; }
        bool AsAdmin { get; set; }
        bool UseShell { get; set; }
        string Shell { get; set; }
        string ShellPrefix { get; set; } //precedes filepath to execute via a PATH variable i.e. "Python'

        /// <summary>
        /// Starts the launchable.
        /// </summary>
        void Start();
    }
}
