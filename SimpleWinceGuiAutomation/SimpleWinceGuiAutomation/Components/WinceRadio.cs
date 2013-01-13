using System;
using SimpleWinceGuiAutomation.Core;
using SimpleWinceGuiAutomation.Wince;

namespace SimpleWinceGuiAutomation.Components
{
    public class WinceRadio : WinceComponent
    {
        public WinceRadio(IntPtr ptr) : base(ptr) { }

        public String Text
        {
            get { return WindowHelper.GetText(Handle); }
        }

        public bool Checked
        {
            get { return (int) PInvoke.SendMessage(Handle, PInvoke.BM_GETCHECK, (IntPtr) 0x0, (IntPtr) 0) == 1; }
        }

        public void Click()
        {
            WindowHelper.Click(Handle);
        }
    }
}