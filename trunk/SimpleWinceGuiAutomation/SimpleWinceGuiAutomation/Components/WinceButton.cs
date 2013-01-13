using System;

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
        }

        public int Height
        {
            get
            {
                WindowHelper.RECT rect = WindowHelper.GetRect(handle);
                return rect.Bottom - rect.Top;
            }
        }

        public void Click()
        {
            WindowHelper.Click(handle);
        }
    }
}