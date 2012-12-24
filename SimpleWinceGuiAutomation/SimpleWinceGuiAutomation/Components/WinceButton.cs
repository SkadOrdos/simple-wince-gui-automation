﻿using System;
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
            PInvoke.SendMessage(handle, PInvoke.WM_LBUTTONDOWN, (IntPtr)0x1, (IntPtr)0);
            PInvoke.SendMessage(handle, PInvoke.WM_LBUTTONUP, (IntPtr)0x1, (IntPtr)0);
        }
    }
}