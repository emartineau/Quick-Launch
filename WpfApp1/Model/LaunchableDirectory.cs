using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Model
{
    class LaunchableDirectory : Launchable
    {
        private DirectoryInfo directoryInfo;
        public new FileSystemInfo Info { get; }

        public LaunchableDirectory(string path, string arguments, bool asAdmin = false) : base(path, arguments, asAdmin) { }

        public override void Start()
        {
            if (UseShell)
            {
                processStart.WorkingDirectory = Info.FullName;
            }
            else
            {
                Process.Start("explorer.exe", directoryInfo.FullName);
            }
        }
    }
}
