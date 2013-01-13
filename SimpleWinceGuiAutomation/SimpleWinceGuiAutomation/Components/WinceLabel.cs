using System;

namespace SimpleWinceGuiAutomation.Components
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