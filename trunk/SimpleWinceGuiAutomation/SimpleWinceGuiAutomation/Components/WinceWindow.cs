using System;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    public class WinceWindow
    {
        private readonly IntPtr handle;

        public WinceWindow(IntPtr handle)
        {
            this.handle = handle;
        }

        static Boolean isCheckBox(WinComponent component)
        {
            if (!component.Class.ToLower().Contains("button"))
            {
                return false;
            }
            var style = component.Style;
            int BS_TYPEMASK = 0x0000000F;
            int BS_CHECKBOX = 0x2;
            int BS_AUTOCHECKBOX = 0x3;
            style = style & BS_TYPEMASK;
            return (style == BS_AUTOCHECKBOX || style == BS_CHECKBOX);
        }

        public ComponentRequester<WinceButton> Buttons
        {
            get 
            {
                return new ComponentRequester<WinceButton>(ptr => new WinceButton(ptr), e => e.Class.ToLower().Contains("button") && !isCheckBox(e), handle);
            }
        }

        public ComponentRequester<WinceCheckBox> CheckBoxes
        {
            get { return new ComponentRequester<WinceCheckBox>(ptr => new WinceCheckBox(ptr), isCheckBox, handle); }
        }

        public ComponentRequester<WinceTextBox> TextBoxes
        {
            get { return new ComponentRequester<WinceTextBox>(ptr => new WinceTextBox(ptr), e => e.Class.ToLower().Contains("edit"), handle); }
        }

        public ComponentRequester<WinceComboBox> ComboBoxes
        {
            get { return new ComponentRequester<WinceComboBox>(ptr => new WinceComboBox(ptr), e => e.Class.ToLower().Contains("combobox"), handle); }
        }
    }

    public class WinceComboBox
    {
        private readonly IntPtr ptr;

        public WinceComboBox(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }
}