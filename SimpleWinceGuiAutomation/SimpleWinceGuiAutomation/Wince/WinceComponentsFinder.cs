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

        public List<WinComponent> ListChilds(IntPtr handle)
        {
            var childs = new List<WinComponent>();
            var hwndCur = PInvoke.GetWindow(handle, (uint)PInvoke.GetWindowFlags.GW_CHILD);
            RecurseFindWindow(hwndCur, childs);
            return childs;
        }

        private static void RecurseFindWindow(IntPtr hWndParent, List<WinComponent> childs)
        {
            if (hWndParent == IntPtr.Zero)
                return;
            var pointers = new List<IntPtr>();

            IntPtr hwndCur = PInvoke.GetWindow(hWndParent, (uint)PInvoke.GetWindowFlags.GW_HWNDFIRST);
            do
            {
                pointers.Add(hwndCur);
                StringBuilder chArWindowClass = new StringBuilder(257);
                PInvoke.GetClassName(hwndCur, chArWindowClass, 256);
                var strWndClass = chArWindowClass.ToString();
                //strWndClass = strWndClass.Substring(0, strWndClass.IndexOf('\0'));

                var length = PInvoke.GetWindowTextLength(hwndCur);
                var sb = new StringBuilder(length + 1);
                PInvoke.GetWindowText(hwndCur, sb, sb.Capacity);

                PInvoke.RECT rct;
                PInvoke.GetWindowRect(hwndCur, out rct);

                var style = PInvoke.GetWindowLong(hwndCur, PInvoke.GWL_STYLE);


                childs.Add(new WinComponent(strWndClass, sb.ToString(), hwndCur, rct.Left, rct.Top, style));

                hwndCur = PInvoke.GetWindow(hwndCur, (uint)PInvoke.GetWindowFlags.GW_HWNDNEXT);
            } while (hwndCur != IntPtr.Zero);

            foreach (var pointer in pointers)
            {
                RecurseFindWindow(PInvoke.GetWindow(pointer, (uint)PInvoke.GetWindowFlags.GW_CHILD), childs);
            }
        }
    }
}
