using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public static class LoadProcesses
    {
        /// <summary>
        /// Gets all the processes that are currently running and filters the processes
        /// by removing windows default processes
        /// </summary>
        /// <returns></returns>
        public static List<Process> GetRunningProcesses()
        {
            List<Process> procs = new List<Process>();

            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.MainWindowHandle != (IntPtr)0x00000000 || proc.MainWindowTitle != "")
                    procs.Add(proc);
            }

            return procs;
        }

        /// <summary>
        /// Loads all the saved processes from the Local Resources
        /// </summary>
        public static Process[] LoadFromFile()
        {
            return Process.GetProcesses();
        }

        /// <summary>
        /// Save all the selected processes to the Local Resources
        /// </summary>
        public static void SaveToFile(Process[] proc_list)
        {

        }
    }
}
