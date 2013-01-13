using System;
using SimpleWinceGuiAutomation.Components;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    public class WinceCheckBox : WinceComponent
    {
        public WinceCheckBox(IntPtr handle) : base(handle) { }

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