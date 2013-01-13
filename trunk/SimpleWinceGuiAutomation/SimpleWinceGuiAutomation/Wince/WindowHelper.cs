using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SimpleWinceGuiAutomation.Wince
{
    public static class WindowHelper
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

        private static RECT GetRect(IntPtr handle)
        {
            RECT r;
            if (!GetWindowRect(handle, out r))
            {
                throw new Exception("");
            }
            return r;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public class Location
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public class Size
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public static Location GetLocation(IntPtr handle)
        {
            var rect = GetRect(handle);
            return new Location { X = rect.left, Y = rect.top };
        }

        public static Size GetSize(IntPtr handle)
        {
            var rect = GetRect(handle);
            return new Size { Height = rect.bottom - rect.top, Width = rect.right - rect.left };
        }
    }
}