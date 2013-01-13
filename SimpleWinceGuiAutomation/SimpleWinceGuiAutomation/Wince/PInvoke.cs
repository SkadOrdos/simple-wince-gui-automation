using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace SimpleWinceGuiAutomation.Core
{
    class PInvoke
    {
        [DllImport("coredll.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hwnd, uint relationship);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetClassName(IntPtr hwnd, StringBuilder windowClass, int maxText);

        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("coredll.dll")]
        public static extern bool SetWindowText(IntPtr hwnd, string text);

        [DllImport("coredll.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);


        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        public const int GWL_STYLE = (-16);

        public static int WM_LBUTTONDOWN = 0x0201;
        public static int WM_LBUTTONUP = 0x0202;
        public static int BM_GETCHECK = 0x00F0;
        public static int BM_SETCHECK = 0x00F1;
        public static int WM_SETTEXT = 0x000C;

        [Flags]
        public enum GetWindowFlags
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
        }


        [DllImport("coredll.dll", CharSet = CharSet.Auto, SetLastError =
false, EntryPoint = "SendMessage")]
        public static extern IntPtr SendRefMessage(IntPtr hWnd, uint Msg, int
        wParam, StringBuilder lParam);

        public static IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, StringBuilder lParam)
        {
            var size = lParam.Capacity;
            var lpv = VirtualAlloc(IntPtr.Zero, 2 * 1024 * 1024, MemUsageFlags.MEM_RESERVE, PageAccessFlags.PAGE_NOACCESS);
            var pbuffer = VirtualAlloc(lpv, 65536, MemUsageFlags.MEM_COMMIT, PageAccessFlags.PAGE_READWRITE);
            var res = SendMessage(hWnd, Msg, wParam, pbuffer);
            byte[] content = new byte[size * 2];
            uint nbBytesRead = 0;
            ReadProcessMemory((uint)Process.GetCurrentProcess().Id, pbuffer, content, (uint)content.Length, ref nbBytesRead);
            VirtualFree(lpv, 65536, MemUsageFlags.MEM_RELEASE);
            lParam.Append(Encoding.Unicode.GetString(content, 0, content.Length));
            return res;
        }

        [DllImport("Coredll.dll")]
        extern public static IntPtr VirtualAlloc(IntPtr lpAddress, UInt32
        dwSize, MemUsageFlags flAllocationType, PageAccessFlags
        flProtect);

        [DllImport("Coredll.dll")]
        extern public static bool VirtualFree(IntPtr lpAddress, UInt32 dwSize,
        MemUsageFlags dwFreeType);



        //Flags
        [FlagsAttribute]
        public enum PageAccessFlags : int
        {

            PAGE_READONLY = 0x02,
            PAGE_READWRITE = 0x04,
            PAGE_EXECUTE = 0x10,
            PAGE_EXECUTE_READ = 0x20,
            PAGE_EXECUTE_READWRITE = 0x40,
            PAGE_GUARD = 0x100,
            PAGE_NOACCESS = 0x01,
            PAGE_NOCACHE = 0x200,
            PAGE_PHYSICAL = 0x400
        }


        public enum MemUsageFlags : int
        {
            MEM_COMMIT = 0x1000,
            MEM_RESERVE = 0x2000,
            MEM_DECOMMIT = 0x4000,
            MEM_RELEASE = 0x8000
        }

        [DllImport("Coredll.dll")]
        public static extern bool ReadProcessMemory(uint hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, ref  uint lpNumberOfBytesRead); 

    }
}
