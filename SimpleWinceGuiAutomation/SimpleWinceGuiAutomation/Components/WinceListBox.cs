using System;

namespace SimpleWinceGuiAutomation
{
    public class WinceListBox
    {
        private readonly IntPtr ptr;

        public WinceListBox(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }
}