using System;

namespace SimpleWinceGuiAutomation
{
    public class WinceTextBox
    {
        private readonly IntPtr ptr;

        public WinceTextBox(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public String Text
        {
            get { return WindowHelper.GetText(ptr); }
            set { WindowHelper.SetText(ptr, value); }
        }
    }
}