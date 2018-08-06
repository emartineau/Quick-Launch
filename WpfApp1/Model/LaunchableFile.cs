using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Model
{
    class LaunchableFile : Launchable
    {
        private FileInfo fileInfo;
        public new FileSystemInfo Info { get; }

        public LaunchableFile(string path, string arguments, bool asAdmin = false) : base(path, arguments, asAdmin)
        {
            InitializeProcess(arguments);
        }

        public override void Start()
        {
            if (AsAdmin)
            {
                processStart.UseShellExecute = AsAdmin;
                processStart.Verb = "runas";
            }

            if (UseShell)
            {
                Process.Start(Shell, ShellPrefix + processStart.FileName + processStart.Arguments);
            }
            else
            {
                Process p = new Process
                {
                    StartInfo = processStart
                };

                p.Start();
            }
        }

        private void InitializeProcess(string arguments)
        {
            base.processStart = new ProcessStartInfo(File.FullName)
            {
                Arguments = arguments,
                WorkingDirectory = this.WorkingDirectory.FullName
            };
        }
    }
}
