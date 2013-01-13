using System;

namespace SimpleWinceGuiAutomation.Components
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