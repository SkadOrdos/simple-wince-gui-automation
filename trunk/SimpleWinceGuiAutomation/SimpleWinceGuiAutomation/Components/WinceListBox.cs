using System;
using System.Collections.Generic;
using System.Text;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    public class WinceListBox
    {
        private readonly IntPtr ptr;
        private int LB_GETCOUNT = 0x018B;
        private int LB_GETCURSEL = 0x0188;

        private int LB_GETTEXT = 0x0189;
        private int LB_GETTEXTLEN = 0x018A;
        private int LB_SETCURSEL = 0x0186;

        public WinceListBox(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public int SelectedItem
        {
            get { return PInvoke.SendMessage(ptr, LB_GETCURSEL, (IntPtr) 0, (IntPtr) 0).ToInt32(); }
        }

        public List<String> Items
        {
            get
            {
                var items = new List<string>();
                IntPtr ptr = PInvoke.SendMessage(this.ptr, LB_GETCOUNT, (IntPtr) 0, (IntPtr) 0);
                for (int i = 0; i < ptr.ToInt32(); i++)
                {
                    items.Add(GetListItem(i));
                }
                return items;
            }
        }

        private string GetListItem(int index)
        {
            int size = PInvoke.SendMessage(ptr, LB_GETTEXTLEN, new IntPtr(index), new IntPtr(0)).ToInt32();
            var sb = new StringBuilder(size);
            PInvoke.SendMessage(ptr, LB_GETTEXT, new IntPtr(index), sb);
            return sb.ToString();
        }

        public void Select(string value)
        {
            List<string> items = Items;
            for (int i = 0; i < items.Count; i++)
            {
                if (value == items[i])
                {
                    PInvoke.SendMessage(ptr, LB_SETCURSEL, (IntPtr) i, (IntPtr) 0);
                }
            }
        }
    }
}