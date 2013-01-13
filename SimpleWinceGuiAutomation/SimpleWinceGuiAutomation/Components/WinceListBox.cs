using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    public class WinceListBox
    {
        private readonly IntPtr ptr;

        public WinceListBox(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public int SelectedItem
        {
            get { return PInvoke.SendMessage(ptr, LB_GETCURSEL, (IntPtr)0, (IntPtr)0).ToInt32(); }
        }

        int LB_GETTEXT = 0x0189;
        private int LB_GETTEXTLEN = 0x018A;
        private int LB_GETCOUNT = 0x018B;
        int LB_SETCURSEL = 0x0186;
        private int LB_GETCURSEL = 0x0188;

        private string GetListItem(int index)
        {
            var size = PInvoke.SendMessage(ptr, LB_GETTEXTLEN, new IntPtr(index), new IntPtr(0)).ToInt32();
            var sb = new StringBuilder(size);
            PInvoke.SendMessage(ptr, LB_GETTEXT, new IntPtr(index), sb);
            return sb.ToString();
        }

        public List<String> Items
        {
            get
            {
                List<String> items= new List<string>();
                IntPtr ptr = PInvoke.SendMessage(this.ptr, LB_GETCOUNT, (IntPtr)0, (IntPtr)0);
                for (var i = 0; i < ptr.ToInt32(); i++)
                {
                    items.Add(GetListItem(i));
                }
                return items;
            }
        }

        public void Select(string value)
        {
            var items = Items;
            for (var i = 0; i < items.Count; i++)
            {
                if (value == items[i])
                {
                    PInvoke.SendMessage(ptr, LB_SETCURSEL, (IntPtr)i, (IntPtr)0);
                }
            }
        }
    }
}