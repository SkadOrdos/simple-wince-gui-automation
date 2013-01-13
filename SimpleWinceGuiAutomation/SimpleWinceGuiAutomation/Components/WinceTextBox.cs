using System;
using SimpleWinceGuiAutomation.Components;

namespace SimpleWinceGuiAutomation
{
    public class WinceTextBox : WinceComponent
    {

        public WinceTextBox(IntPtr ptr) : base(ptr) { }

        public String Text
        {
            get { return WindowHelper.GetText(Handle); }
            set {WindowHelper.SetText(Handle, value);}
        }
    }
}