using System;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    public class WinceCheckBox
    {
        private readonly IntPtr handle;

        public WinceCheckBox(IntPtr handle)
        {
            this.handle = handle;
        }

        public bool Checked
        {
            get { return (int)PInvoke.SendMessage(handle, PInvoke.BM_GETCHECK, (IntPtr)0x0, (IntPtr)0) == 1; }
            set { PInvoke.SendMessage(handle, PInvoke.BM_SETCHECK, (IntPtr)(value ? 1 : 0), (IntPtr)0); }
        }


        public String Text
        {
            get { return WindowHelper.GetText(handle); }
            set { WindowHelper.SetText(handle, value); }
        }
    }
}