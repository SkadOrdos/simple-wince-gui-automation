using System;
using SimpleWinceGuiAutomation.Components;

namespace SimpleWinceGuiAutomation
{
    public class WinceLabel : WinceComponent
    {
        public WinceLabel(IntPtr ptr) : base(ptr) { }
        
        public String Text
        {
            get { return WindowHelper.GetText(Handle); }
        }
    }
}