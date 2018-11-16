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
        public string SaveFolderPath { get; set; } = Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), "QuickLaunch");
        public string SavePath { get => Path.Combine(SaveFolderPath, "Loadout.cfg"); set => SavePath = value; }
        public Launchables Launchables { get; set; }
        private Dictionary<string, LaunchableFile> LFiles { get; }
        private Dictionary<string, LaunchableDirectory> LDirs { get; }

        public Launcher()
        {
            Launchables = ReadFromFile();
        }

        public Launchables ReadFromFile()
        {
            return File.Exists(SavePath) ? JsonConvert.DeserializeObject<Launchables>(File.ReadAllText(SavePath)) : new Dictionary<string, ILaunchable>();
        }

        public void WriteToFile()
        {
            if (!Directory.Exists(SaveFolderPath))
                Directory.CreateDirectory(SaveFolderPath);
            var saveFileText = JsonConvert.SerializeObject(Launchables);
            var FilesConfig = JsonConvert.SerializeObject(LFiles);
            var DirsConfig = JsonConvert.SerializeObject(LDirs);
            using (StreamWriter sw = new StreamWriter(SavePath))
            {
                sw.Write($"{FilesConfig}\n---------\n{DirsConfig}");
                sw.Close();
            }
        }
    }
}
