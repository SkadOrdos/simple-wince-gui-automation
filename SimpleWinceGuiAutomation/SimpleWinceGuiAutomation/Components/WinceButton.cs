using System;
using SimpleWinceGuiAutomation.Components;

namespace SimpleWinceGuiAutomation
{
    public class WinceButton : WinceComponent
    {        
        public WinceButton(IntPtr handle) : base(handle) { }

        public void Click()
        {
            WindowHelper.Click(Handle);
        }
        public String Text
        {
            get { return WindowHelper.GetText(Handle); }
        }
    }
}