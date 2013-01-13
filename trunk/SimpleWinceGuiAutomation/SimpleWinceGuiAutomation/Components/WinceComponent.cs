using System;

namespace SimpleWinceGuiAutomation.Components
{
    public class WinceComponent
    {
        protected IntPtr Handle { get; private set; }

        public WinceComponent(IntPtr handle)
        {
            Handle = handle;
        }

        public String Text
        {
            get { return WindowHelper.GetText(Handle); }
        }

        public WindowHelper.Size Size
        {
            get
            {
                return WindowHelper.GetSize(Handle);
            }
        }

        public WindowHelper.Location Location
        {
            get
            {
                return WindowHelper.GetLocation(Handle);
            }
        }
    }
}
