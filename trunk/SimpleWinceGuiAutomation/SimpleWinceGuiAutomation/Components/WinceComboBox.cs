﻿using System;
using System.Collections.Generic;
using System.Text;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation.Components
{
    public class WinceComboBox : WinceComponent
    {
        private const int CB_GETCOUNT = 0x0146;
        private const int CB_GETLBTEXT = 0x0148;
        private const int CB_GETLBTEXTLEN = 0x149;
        private const int CB_SETCURSEL = 0x014E;

        public WinceComboBox(IntPtr ptr) : base(ptr) { }

        public String Text
        {
            get { return WindowHelper.GetText(Handle); }
        }

        public List<String> Items
        {
            get
            {
                var items = new List<string>();
                IntPtr ptr = PInvoke.SendMessage(Handle, CB_GETCOUNT, (IntPtr) 0, (IntPtr) 0);
                for (int i = 0; i < ptr.ToInt32(); i++)
                {
                    items.Add(GetComboItem(i));
                }
                return items;
            }
        }

        private string GetComboItem(int index)
        {
            int size = PInvoke.SendMessage(Handle, CB_GETLBTEXTLEN, new IntPtr(index), new IntPtr(0)).ToInt32();
            var ssb = new StringBuilder(size);
            PInvoke.SendMessage(Handle, CB_GETLBTEXT, new IntPtr(index), ssb).ToInt32();
            return ssb.ToString();
        }


        public void Select(string value)
        {
            List<string> items = Items;
            for (int i = 0; i < items.Count; i++)
            {
                if (value == items[i])
                {
                    PInvoke.SendMessage(Handle, CB_SETCURSEL, (IntPtr) i, (IntPtr) 0);
                    return;
                }
            }
            throw new Exception("No item named : " + value);
        }
    }
}