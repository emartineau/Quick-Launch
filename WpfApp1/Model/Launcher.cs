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
    using Launchables = IDictionary<string, ILaunchable>;
    /// <summary>
    /// The application's model. Stores and interprets user-defined Launchables. Facilitates ViewModel's interaction with Launchables.
    /// </summary>
    class Launcher : ILauncher
    {
        public string SavePath { get; set; } = $"{Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), "QuickLaunch/loadout.cfg")}";
        public Launchables Launchables { get; set; }

        public Launcher()
        {
            Launchables = ReadFromFile();
        }

        public Launchables ReadFromFile()
        {
            return Directory.Exists(SavePath) ? JsonConvert.DeserializeObject<Launchables>(SavePath) : new Dictionary<string, ILaunchable>();
        }

        public void WriteToFile()
        {
            var saveFileText = JsonConvert.SerializeObject(Launchables);
            using (StreamWriter sw = new StreamWriter(SavePath))
            {
                sw.Write(saveFileText);
                sw.Close();
            }
        }
    }
}
