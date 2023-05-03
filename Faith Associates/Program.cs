using Faith_Associates.Screens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]     
        static void Main()
        {
            if(Priorprocess() != null)
            {
                MessageBox.Show("Application is already running");
                return;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginScreen());
            }
        }

        private static Process Priorprocess()
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName))
                {
                    return p;
                }
            }
            return null;
        }
    }
}
