using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Model
{
    interface ILauncher
    {
        string SavePath { get; set; }
        IDictionary<string, ILaunchable> Launchables { get; set; }

        void WriteToFile();
        IDictionary<string, ILaunchable> ReadFromFile();
    }
}
