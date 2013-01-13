using System;
using System.Collections.Generic;
using System.Text;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation.Wince
{
    internal class WinceComponentsFinder
    {
        public List<WinComponent> ListChilds(IntPtr handle)
        {
            var childs = new List<WinComponent>();
            IntPtr hwndCur = PInvoke.GetWindow(handle, (uint) PInvoke.GetWindowFlags.GW_CHILD);
            RecurseFindWindow(hwndCur, childs);
            return childs;
        }

        private static void RecurseFindWindow(IntPtr hWndParent, List<WinComponent> childs)
        {
            if (hWndParent == IntPtr.Zero)
                return;
            var pointers = new List<IntPtr>();

            IntPtr hwndCur = PInvoke.GetWindow(hWndParent, (uint) PInvoke.GetWindowFlags.GW_HWNDFIRST);
            do
            {
                pointers.Add(hwndCur);
                var chArWindowClass = new StringBuilder(257);
                PInvoke.GetClassName(hwndCur, chArWindowClass, 256);
                string strWndClass = chArWindowClass.ToString();
                //strWndClass = strWndClass.Substring(0, strWndClass.IndexOf('\0'));

                int length = PInvoke.GetWindowTextLength(hwndCur);
                var sb = new StringBuilder(length + 1);
                PInvoke.GetWindowText(hwndCur, sb, sb.Capacity);

                PInvoke.RECT rct;
                PInvoke.GetWindowRect(hwndCur, out rct);

                int style = PInvoke.GetWindowLong(hwndCur, PInvoke.GWL_STYLE);


                childs.Add(new WinComponent(strWndClass, sb.ToString(), hwndCur, rct.Left, rct.Top, style));

                hwndCur = PInvoke.GetWindow(hwndCur, (uint) PInvoke.GetWindowFlags.GW_HWNDNEXT);
            } while (hwndCur != IntPtr.Zero);

            foreach (IntPtr pointer in pointers)
            {
                RecurseFindWindow(PInvoke.GetWindow(pointer, (uint) PInvoke.GetWindowFlags.GW_CHILD), childs);
            }
        }
    }
}