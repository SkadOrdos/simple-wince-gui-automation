using System;

namespace SimpleWinceGuiAutomation
{
    public class WinceLabel
    {
        private readonly IntPtr ptr;

        public WinceLabel(IntPtr ptr)
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