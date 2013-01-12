using System;
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


        uint CB_GETLBTEXT = 0x0148;
        private int CB_GETLBTEXTLEN = 0x149;
        private int CB_GETCOUNT = 0x0146;
        int CB_SETCURSEL = 0x014E;

        private string GetComboItem(int index)
        {
            var size = PInvoke.SendMessage(ptr, CB_GETLBTEXTLEN, new IntPtr(index), new IntPtr(0)).ToInt32();
            StringBuilder ssb = new StringBuilder(256, 256);
            var getSize = PInvoke.SendRefMessage(ptr, CB_GETLBTEXT, index, ssb).ToInt32();
            return ssb.ToString();
        }


        public void Select(string value)
        {
            IntPtr ptr = PInvoke.SendMessage(this.ptr, CB_GETCOUNT, (IntPtr)0, (IntPtr)0);
            for (var i = 0; i < ptr.ToInt32(); i++)
            {
                var item = GetComboItem(i);
                if (item == value)
                {
                    PInvoke.SendMessage(this.ptr, CB_SETCURSEL, (IntPtr)i, (IntPtr)0);
                }
            }

            
        }
    }
}