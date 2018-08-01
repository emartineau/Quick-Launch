using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DansCSharpLibrary.Serialization;

namespace QuickLaunch.Model
{
    /// <summary>
    /// The application's model. Stores and interprets user-defined Launchables. Facilitates ViewModel's interaction with Launchables.
    /// </summary>
    class Launcher
    {
        public string SavePath { get; set; }
        public Dictionary<string, Launchable> launchables;

        public Launcher()
        {
            launchables = XmlSerialization.ReadFromXmlFile<Dictionary<string, Launchable>>(SavePath)?? new Dictionary<string, Launchable>();
        }

        public void SaveToFile()
        {
            XmlSerialization.WriteToXmlFile(SavePath, launchables);
        }
    }
}
