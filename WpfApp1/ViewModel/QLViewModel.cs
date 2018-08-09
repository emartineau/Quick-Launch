using QuickLaunch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuickLaunch.ViewModel
{
    class QLViewModel
    {
        public readonly Launcher Launcher;

        public Dictionary<string, Launchable> Launchables { get => Launcher.launchables; set => Launcher.launchables = value; }

        public QLViewModel()
        {
            Launcher = new Launcher();
        }
    }
}
