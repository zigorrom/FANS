using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FANS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //System.Diagnostics.Process myProcess = System.Diagnostics.Process.GetCurrentProcess();
            //myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            var a = FANS.classes.Callibration.GetInstance(DigitalAnalyzerNamespace.DigitalAnalyzerSpectralRange.Discret499712Freq1_1600Step1Freq1647_249856Step61);
            //a.Calibrate();
        }
    }
}
