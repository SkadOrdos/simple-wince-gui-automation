using System;
using System.Runtime.InteropServices;
using System.Text;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    internal static class WindowHelper
    {
        public static String GetText(IntPtr handle)
        {
            int length = PInvoke.GetWindowTextLength(handle);
            var sb = new StringBuilder(length + 1);
            PInvoke.GetWindowText(handle, sb, sb.Capacity);
            return sb.ToString();
        }

        public static void SetText(IntPtr handle, string value)
        {
            PInvoke.SetWindowText(handle, value);
        }

        public static void Click(IntPtr handle)
        {
#if PocketPC
            PInvoke.SendMessage(handle, PInvoke.WM_LBUTTONDOWN, (IntPtr) 0x1, (IntPtr) 0);
            PInvoke.SendMessage(handle, PInvoke.WM_LBUTTONUP, (IntPtr) 0x1, (IntPtr) 0);
#else
            const int BM_CLICK = 0x00F5;
            PInvoke.SendMessage(handle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
#endif
        }

        [DllImport("coredll.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

        public static RECT GetRect(IntPtr handle)
        {
            RECT r;
            if (!GetWindowRect(handle, out r))
            {
                throw new Exception("");
            }
            return r;
        }

        #region Nested type: RECT

        public struct RECT
        {
            public int Bottom;
            public int Left;
            public int Right;
            public int Top;
        }

        #endregion
    }
}