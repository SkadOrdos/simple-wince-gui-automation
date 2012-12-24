using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SimpleWinceGuiAutomation
{
    public class WinceApplicationFactory
    {
        public static WinceApplication StartFromTypeInApplication<T>()
        {
            var assemblyToTest = typeof(T).Assembly;
            var theDirectory = Path.GetDirectoryName(assemblyToTest.GetName().CodeBase.Replace("file:///", ""));
            var applicationName = Path.GetFileName(assemblyToTest.GetName().CodeBase.Replace("file:///", ""));
            var p = Process.Start(theDirectory + @"\" + applicationName, "");

            for (int ix = 0; ix < 500; ++ix)
            {
                Thread.Sleep(100);
                p.Refresh();
                if (p.MainWindowHandle != IntPtr.Zero) break;
            }
            return new WinceApplication(p.MainWindowHandle, p);
        }
    }
}