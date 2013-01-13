using System;
using System.Diagnostics;

namespace SimpleWinceGuiAutomation
{
    public class WinceApplication
    {
        private readonly Process process;

        public WinceApplication(IntPtr handle, Process process)
        {
            this.process = process;
            MainWindow = new WinceWindow(handle);
        }


        public WinceWindow MainWindow { get; private set; }

        public void Kill()
        {
            process.Kill();
        }
    }
}