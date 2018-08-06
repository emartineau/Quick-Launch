using QuickLaunch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.ViewModel
{
    class QLViewModel
    {
        private Launcher launcher;

        public Dictionary<string, Launchable> Launchables { get => launcher.launchables; set => launcher.launchables = value; }


    }
}
