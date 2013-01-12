using System;

namespace SimpleWinceGuiAutomation
{
    public class WinceContainer
    {
        private readonly IntPtr ptr;

        public WinceContainer(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }
}