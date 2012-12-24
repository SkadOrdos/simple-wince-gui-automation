using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SimpleWinceGuiAutomation.Helpers
{
     
    public class WinceComponentDto
    {
        public WinceComponentDto(string @class, string text, IntPtr handle, int left, int top, int style)
        {
            Class = @class;
            Text = text;
            Handle = handle;
            Left = left;
            Top = top;
            Style = style;
        }

        public String Class { get; private set; }
        public String Text { get; private set; }
        public IntPtr Handle { get; private set; }
        public int Left { get; private set; }
        public int Top { get; private set; }
        public int Style { get; private set; }
        
    }

    public class ComponentsFinder
    {

        public List<WinceComponentDto> ListChilds(IntPtr handle)
        {
            var childs = new List<WinceComponentDto>();
            var hwndCur = GetWindow(handle, (uint)GetWindowFlags.GW_CHILD);
            RecurseFindWindow(hwndCur, childs);
            return childs;
        }

        private static void RecurseFindWindow(IntPtr hWndParent, List<WinceComponentDto> childs)
        {
            var chArWindowClass = new char[32];
            if (hWndParent == IntPtr.Zero)
                return;
            var pointers = new List<IntPtr>();

            IntPtr hwndCur = GetWindow(hWndParent, (uint)GetWindowFlags.GW_HWNDFIRST);
            do
            {
                pointers.Add(hwndCur);
                GetClassName(hwndCur, chArWindowClass, 256);
                var strWndClass = new string(chArWindowClass);
                strWndClass = strWndClass.Substring(0, strWndClass.IndexOf('\0'));

                var length = GetWindowTextLength(hwndCur);
                var sb = new StringBuilder(length + 1);
                GetWindowText(hwndCur, sb, sb.Capacity);

                RECT rct;
                GetWindowRect(hwndCur, out rct);

                var style = GetWindowLong(hwndCur, GWL_STYLE);
                

                childs.Add(new WinceComponentDto(strWndClass, sb.ToString(), hwndCur, rct.Left, rct.Top, style));

                hwndCur = GetWindow(hwndCur, (uint)GetWindowFlags.GW_HWNDNEXT);
            } while (hwndCur != IntPtr.Zero);

            foreach (var pointer in pointers)
            {
                RecurseFindWindow(GetWindow(pointer, (uint)GetWindowFlags.GW_CHILD), childs);
            }
        }

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string _ClassName, string _WindowName);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hwnd, uint relationship);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int GetClassName(IntPtr hwnd, char[] windowClass, int maxText);

        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("coredll.dll")]
        public static extern bool SetWindowText(IntPtr hwnd, string text);

        [DllImport("coredll.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("coredll.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        private const int GWL_STYLE = (-16);

        public static int WM_LBUTTONDOWN = 0x0201;
        public static int WM_LBUTTONUP = 0x0202;
        public static int BM_GETCHECK = 0x00F0;
        public static int BM_SETCHECK = 0x00F1;

        [Flags]
        private enum GetWindowFlags
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
        }
    }
}
