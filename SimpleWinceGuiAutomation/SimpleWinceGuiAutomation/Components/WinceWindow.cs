using System;

namespace SimpleWinceGuiAutomation
{
    public class WinceWindow
    {
        private readonly IntPtr handle;

        public WinceWindow(IntPtr handle)
        {
            this.handle = handle;
        }

        public ComponentRequester<WinceButton> Buttons
        {
            get 
            {
                return new ComponentRequester<WinceButton>(ptr => new WinceButton(ptr), e => e.Class.ToLower() == "button" && (e.Style & 0x0002) == 0, handle);
            }
        }

        public ComponentRequester<WinceCheckBox> CheckBoxes
        {
            get { return new ComponentRequester<WinceCheckBox>(ptr => new WinceCheckBox(ptr), e => (e.Style & 0x0002) != 0, handle); }
        }

        public ComponentRequester<WinceTextBox> TextBoxes
        {
            get { return new ComponentRequester<WinceTextBox>(ptr => new WinceTextBox(ptr), e => e.Class.ToLower() == "edit", handle); }
        }
    }

    public class WinceTextBox
    {
        private readonly IntPtr ptr;

        public WinceTextBox(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public String Text
        {
            get { return WindowHelper.GetText(ptr); }
            set { WindowHelper.SetText(ptr, value); }
        }
    }
}