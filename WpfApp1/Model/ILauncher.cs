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
        Dictionary<string, ILaunchable> Launchables { get; set; }

        void WriteToFile();
        Dictionary<string, ILaunchable> ReadFromFile();
    }
}
