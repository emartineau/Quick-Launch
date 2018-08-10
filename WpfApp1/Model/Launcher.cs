using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace QuickLaunch.Model
{
    using Launchables = Dictionary<string, Launchable>;
    /// <summary>
    /// The application's model. Stores and interprets user-defined Launchables. Facilitates ViewModel's interaction with Launchables.
    /// </summary>
    class Launcher
    {
        public string SavePath { get; set; } = $"{Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), "QuickLaunch/loadout.cfg")}";
        public Launchables launchables;

        public Launcher()
        {
            launchables = Directory.Exists(SavePath) ? JsonConvert.DeserializeObject<Launchables>(SavePath) : new Launchables();
        }

        public void SaveToFile()
        {
            var saveFileText = JsonConvert.SerializeObject(launchables);
            using (StreamWriter sw = new StreamWriter(SavePath))
            {
                sw.Write(saveFileText);
                sw.Close();
            }
        }
    }
}
