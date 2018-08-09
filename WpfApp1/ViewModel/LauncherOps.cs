using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.ViewModel
{
    static class LauncherOps
    {
        public delegate void LauncherOp(QLViewModel qLViewModel);

        public static LauncherOp SaveOp = (qlvm) => qlvm.Launcher.SaveToFile();
    }
}
