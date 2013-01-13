using System;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    public class WinceRadio
    {
        private readonly IntPtr ptr;

        public WinceRadio(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public String Text
        {
            get { return WindowHelper.GetText(ptr); }
            set { WindowHelper.SetText(ptr, value); }
        }

        public bool Checked
        {
            get { return (int) PInvoke.SendMessage(ptr, PInvoke.BM_GETCHECK, (IntPtr) 0x0, (IntPtr) 0) == 1; }
        }

        public void Click()
        {
            WindowHelper.Click(ptr);
        }
    }
}