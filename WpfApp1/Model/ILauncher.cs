using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Model
{
    /// <summary>
    /// Contains Launchables and Launchables configuration storage logic.
    /// </summary>
    interface ILauncher
    {
        string SavePath { get; set; }
        IDictionary<string, ILaunchable> Launchables { get; set; }

        /// <summary>
        /// Writes the Launchables collection to a file.
        /// </summary>
        void WriteToFile();

        /// <summary>
        /// Reads the Launcables collection from a file.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, ILaunchable> ReadFromFile();
    }
}
