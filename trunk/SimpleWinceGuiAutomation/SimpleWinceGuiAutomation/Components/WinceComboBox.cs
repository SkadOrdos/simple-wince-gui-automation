using System;
using System.Collections.Generic;
using System.Text;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    public class WinceComboBox
    {
        private readonly IntPtr ptr;

        public WinceComboBox(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public String Text
        {
            get { return WindowHelper.GetText(ptr); }
        }


        int CB_GETLBTEXT = 0x0148;
        private int CB_GETLBTEXTLEN = 0x149;
        private int CB_GETCOUNT = 0x0146;
        int CB_SETCURSEL = 0x014E;

        private string GetComboItem(int index)
        {
            var size = PInvoke.SendMessage(ptr, CB_GETLBTEXTLEN, new IntPtr(index), new IntPtr(0)).ToInt32();
            StringBuilder ssb = new StringBuilder(size);
            var getSize = PInvoke.SendMessage(ptr, CB_GETLBTEXT, new IntPtr(index), ssb).ToInt32();
            return ssb.ToString();
        }

        public List<String> Items
        {
            get
            {
                List<String> items = new List<string>();
                IntPtr ptr = PInvoke.SendMessage(this.ptr, CB_GETCOUNT, (IntPtr)0, (IntPtr)0);
                for (var i = 0; i < ptr.ToInt32(); i++)
                {
                    items.Add(GetComboItem(i));
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
                    PInvoke.SendMessage(ptr, CB_SETCURSEL, (IntPtr)i, (IntPtr)0);
                    return;
                }
            }
            throw new Exception("No item named : " + value);
        }
    }
}