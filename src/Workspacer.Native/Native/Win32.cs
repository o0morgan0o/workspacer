﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Workspacer
{
    public delegate void WinEventDelegate(IntPtr hWinEventHook, Win32.EVENT_CONSTANTS eventType, IntPtr hwnd, Win32.OBJID idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
    public delegate bool EnumDelegate(IntPtr hWnd, int lParam);

    public static partial class Win32
    {
        public class Message
        {
            public int message { get; set; }
        }
        
        [DllImport("user32.dll")]
        public static extern bool GetMessage(ref Message lpMsg, IntPtr handle, uint mMsgFilterInMain, uint mMsgFilterMax);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SendNotifyMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        public static readonly int WH_KEYBOARD_LL = 13;
        public static readonly int WH_MOUSE_LL = 14;
        public static readonly uint WM_KEYDOWN = 0x100;
        public static readonly uint WM_SYSKEYDOWN = 0x104;
        public static readonly uint WM_SYSCOMMAND = 0x0112;

        public static readonly uint WM_LBUTTONDOWN = 0x0201;
        public static readonly uint WM_LBUTTONUP = 0x0202;
        public static readonly uint WM_MOUSEMOVE = 0x0200;
        public static readonly uint WM_MOUSEWHEEL = 0x020A;
        public static readonly uint WM_MOUSEHWHEEL = 0x020E;
        public static readonly uint WM_RBUTTONDOWN = 0x0204;
        public static readonly uint WM_RBUTTONUP = 0x0205;

        public static readonly UIntPtr SC_MINIMIZE = (UIntPtr) 0xF020;
		public static readonly IntPtr SC_MINIMIZESigned = (IntPtr) 0xF020;
		public static readonly UIntPtr SC_MAXIMIZE = (UIntPtr) 0xF030;
		public static readonly IntPtr SC_MAXIMIZESigned = (IntPtr) 0xF030;
		public static readonly UIntPtr SC_RESTORE = (UIntPtr) 0xF120;
		public static readonly UIntPtr SC_CLOSE = (UIntPtr) 0xF060;

		public delegate IntPtr HookProc(int code, UIntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SetWindowsHookEx(int hookType, [MarshalAs(UnmanagedType.FunctionPtr)] HookProc lpfn, IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx([Optional] IntPtr hhk, int nCode, UIntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
		public static extern short GetKeyState(System.Windows.Forms.Keys nVirtKey);

        [DllImport("user32.dll", SetLastError=true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
    }
}