using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using SimpleWinceGuiAutomation.Helpers;

namespace SimpleWinceGuiAutomation
{
    public class WinceApplicationFactory
    {
        public static WinceApplication StartFromTypeInApplication<T>()
        {
            var assemblyToTest = typeof(T).Assembly;
            var theDirectory = Path.GetDirectoryName(assemblyToTest.GetName().CodeBase.Replace("file:///", ""));
            var applicationName = Path.GetFileName(assemblyToTest.GetName().CodeBase.Replace("file:///", ""));
            var p = Process.Start(theDirectory + @"\" + applicationName, "");

            for (int ix = 0; ix < 500; ++ix)
            {
                Thread.Sleep(100);
                p.Refresh();
                if (p.MainWindowHandle != IntPtr.Zero) break;
            }
            return new WinceApplication(p.MainWindowHandle, p);
        }
    }

    public class WinceApplication
    {
        private readonly Process process;

        public WinceApplication(IntPtr handle, Process process)
        {
            this.process = process;
            MainWindow = new WinceWindow(handle);
        }


        public WinceWindow MainWindow { get; private set; }

        public void Kill()
        {
            process.Kill();
        }
    }

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
                return new ComponentRequester<WinceButton>(ptr => new WinceButton(ptr), e => e.Class.ToLower() == "button", handle);
            }
        }

        public ComponentRequester<WinceCheckBox> CheckBoxes
        {
            get { return new ComponentRequester<WinceCheckBox>(ptr => new WinceCheckBox(ptr), e => (e.Style & 0x0002) != 0, handle); }
        }
    }

    public class WinceCheckBox
    {
        private readonly IntPtr handle;

        public WinceCheckBox(IntPtr handle)
        {
            this.handle = handle;
        }

        public bool Checked
        {
            get { return (int)ComponentsFinder.SendMessage(handle, ComponentsFinder.BM_GETCHECK, (IntPtr) 0x0, (IntPtr) 0) == 1; }
            set { ComponentsFinder.SendMessage(handle, ComponentsFinder.BM_SETCHECK, (IntPtr) (value ? 1 : 0), (IntPtr) 0); }
        }


        public String Text
        {
            get { return WindowHelper.GetText(handle); }
            set { WindowHelper.SetText(handle, value); }
        }
    }

    public class ComponentRequester<TComponent>
    {
        private Func<IntPtr, TComponent> componentFactory;
        private IntPtr handle;

        private Func<WinceComponentDto, bool> isKind;

        public ComponentRequester(Func<IntPtr, TComponent> componentFactory, Func<WinceComponentDto, bool> isKind, IntPtr handle)
        {
            this.componentFactory = componentFactory;
            this.isKind = isKind;
            this.handle = handle;
        }

        public List<TComponent> All
        {
            get
            {
                var childs = new ComponentsFinder().ListChilds(handle);
                return (from e in childs
                        where isKind(e)
                        orderby e.Top, e.Left
                        select componentFactory(e.Handle)).ToList();
            }
        }

        public List<TComponent> WithTexts(String text)
        {
            var childs = new ComponentsFinder().ListChilds(handle);
            return (from e in childs
                    where isKind(e) && text == e.Text
                    orderby e.Top, e.Left
                    select componentFactory(e.Handle)).ToList();
        }

        public TComponent WithText(String text)
        {
            return WithTexts(text).First();
        }


    }

    static class WindowHelper
    {
        public static String GetText(IntPtr handle)
        {
            int length = ComponentsFinder.GetWindowTextLength(handle);
            var sb = new StringBuilder(length + 1);
            ComponentsFinder.GetWindowText(handle, sb, sb.Capacity);
            return sb.ToString();
        }

        public static void SetText(IntPtr handle, string value)
        {
            ComponentsFinder.SetWindowText(handle, value);
        }
    }

    public class WinceButton
    {
        private readonly IntPtr handle;

        public WinceButton(IntPtr handle)
        {
            this.handle = handle;
        }

        public String Text
        {
            get { return WindowHelper.GetText(handle); }
            set { WindowHelper.SetText(handle, value); }
        }

        public void Click()
        {
            ComponentsFinder.SendMessage(handle, ComponentsFinder.WM_LBUTTONDOWN, (IntPtr)0x1, (IntPtr)0);
            ComponentsFinder.SendMessage(handle, ComponentsFinder.WM_LBUTTONUP, (IntPtr)0x1, (IntPtr)0);
        }
    }
}
