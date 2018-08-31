using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_app_windows.Class.Common
{
    class SystemInfo
    {
        public SystemInfo() { }

        public string getExePath()
        {
            string exePath = Environment.GetCommandLineArgs()[0];
            string exeFullPath = System.IO.Path.GetFullPath(exePath);
            string startupPath = System.IO.Path.GetDirectoryName(exeFullPath);

            return startupPath;
        }
    }
}
