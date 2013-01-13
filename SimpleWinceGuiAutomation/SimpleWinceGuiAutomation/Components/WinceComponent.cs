using System;
using SimpleWinceGuiAutomation.Wince;

namespace SimpleWinceGuiAutomation.Components
{
    public abstract class WinceComponent
    {
        protected IntPtr Handle { get; private set; }

        protected WinceComponent(IntPtr handle)
        {
            Handle = handle;
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

        public bool Enabled
        {
            get { return PInvoke.IsWindowEnabled(Handle); }
        }            
    }
}
