using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SimpleWinceGuiAutomation.Core
{
    class WinceComponentsFinder
    {
        public static int BM_GETCHECK = 0xF0;
        public static int BM_SETCHECK = 0xF0;

        public List<WinceComponent> ListChilds(IntPtr handle)
        {
            var childs = new List<WinceComponent>();
            var hwndCur = PInvoke.GetWindow(handle, (uint)PInvoke.GetWindowFlags.GW_CHILD);
            RecurseFindWindow(hwndCur, childs);
            return childs;
        }

        private static void RecurseFindWindow(IntPtr hWndParent, List<WinceComponent> childs)
        {
            var chArWindowClass = new char[32];
            if (hWndParent == IntPtr.Zero)
                return;
            var pointers = new List<IntPtr>();

            IntPtr hwndCur = PInvoke.GetWindow(hWndParent, (uint)PInvoke.GetWindowFlags.GW_HWNDFIRST);
            do
            {
                pointers.Add(hwndCur);
                PInvoke.GetClassName(hwndCur, chArWindowClass, 256);
                var strWndClass = new string(chArWindowClass);
                strWndClass = strWndClass.Substring(0, strWndClass.IndexOf('\0'));

                var length = PInvoke.GetWindowTextLength(hwndCur);
                var sb = new StringBuilder(length + 1);
                PInvoke.GetWindowText(hwndCur, sb, sb.Capacity);

                PInvoke.RECT rct;
                PInvoke.GetWindowRect(hwndCur, out rct);

                var style = PInvoke.GetWindowLong(hwndCur, PInvoke.GWL_STYLE);


                childs.Add(new WinceComponent(strWndClass, sb.ToString(), hwndCur, rct.Left, rct.Top, style));

                hwndCur = PInvoke.GetWindow(hwndCur, (uint)PInvoke.GetWindowFlags.GW_HWNDNEXT);
            } while (hwndCur != IntPtr.Zero);

            foreach (var pointer in pointers)
            {
                RecurseFindWindow(PInvoke.GetWindow(pointer, (uint)PInvoke.GetWindowFlags.GW_CHILD), childs);
            }
        }
    }
}
