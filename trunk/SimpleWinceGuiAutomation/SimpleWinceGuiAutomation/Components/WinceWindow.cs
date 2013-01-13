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

        public ComponentRequester<WinceButton> Buttons
        {
            get
            {
                return new ComponentRequester<WinceButton>(ptr => new WinceButton(ptr),
                                                           e =>
                                                           e.Class.ToLower().Contains("button") && !isCheckBox(e) &&
                                                           !isRadio(e), handle);
            }
        }

        public ComponentRequester<WinceCheckBox> CheckBoxes
        {
            get { return new ComponentRequester<WinceCheckBox>(ptr => new WinceCheckBox(ptr), isCheckBox, handle); }
        }

        public ComponentRequester<WinceTextBox> TextBoxes
        {
            get
            {
                return new ComponentRequester<WinceTextBox>(ptr => new WinceTextBox(ptr),
                                                            e => e.Class.ToLower().Contains("edit"), handle);
            }
        }

        public ComponentRequester<WinceComboBox> ComboBoxes
        {
            get
            {
                return new ComponentRequester<WinceComboBox>(ptr => new WinceComboBox(ptr),
                                                             e => e.Class.ToLower().Contains("combobox"), handle);
            }
        }

        public ComponentRequester<WinceContainer> Containers
        {
            get { return new ComponentRequester<WinceContainer>(ptr => new WinceContainer(ptr), isContainer, handle); }
        }

        public ComponentRequester<WinceLabel> Labels
        {
            get { return new ComponentRequester<WinceLabel>(ptr => new WinceLabel(ptr), isLabel, handle); }
        }


        public ComponentRequester<WinceRadio> Radios
        {
            get { return new ComponentRequester<WinceRadio>(ptr => new WinceRadio(ptr), isRadio, handle); }
        }

        public ComponentRequester<WinceListBox> ListBoxes
        {
            get
            {
                return new ComponentRequester<WinceListBox>(ptr => new WinceListBox(ptr),
                                                            e => e.Class.ToLower().Contains("listbox"), handle);
            }
        }

        private static Boolean isCheckBox(WinComponent component)
        {
            if (!component.Class.ToLower().Contains("button"))
            {
                return false;
            }
            int style = component.Style;
            int BS_TYPEMASK = 0x0000000F;
            int BS_CHECKBOX = 0x2;
            int BS_AUTOCHECKBOX = 0x3;
            style = style & BS_TYPEMASK;
            return (style == BS_AUTOCHECKBOX || style == BS_CHECKBOX);
        }

        private static Boolean isRadio(WinComponent component)
        {
            if (!component.Class.ToLower().Contains("button"))
            {
                return false;
            }
            int style = component.Style;
            int BS_TYPEMASK = 0x0000000F;
            int BS_RADIOBUTTON = 0x0004;
            int BS_AUTORADIOBUTTON = 0x0009;
            style = style & BS_TYPEMASK;
            return (style == BS_RADIOBUTTON || style == BS_AUTORADIOBUTTON);
        }

        private bool isContainer(WinComponent c)
        {
            return c.Class.ToLower().Equals("#netcf_agl_base_");
        }

        private bool isLabel(WinComponent c)
        {
            return c.Class.ToLower().Equals("static");
        }
    }
}