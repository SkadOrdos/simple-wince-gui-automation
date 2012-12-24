using System;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    public class WinceButton
    {
        private readonly IntPtr handle;

        public WinceButton(IntPtr handle)
        {
            this.handle = handle;
        }

        public String Text
        {
            get { return WindowHelper.GetText(handle); }
            set { WindowHelper.SetText(handle, value); }
        }

        public void Click()
        {
            WindowHelper.Click(handle);
        }
    }
}