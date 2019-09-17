using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Interop;
using MessageBox = System.Windows.MessageBox;

namespace WatchExeTime.BLL.Service
{
    [Flags]
    public enum HotKeyModifiers
    {
        Alt = 1,        // MOD_ALT
        Control = 2,    // MOD_CONTROL
        Shift = 4,      // MOD_SHIFT
        WindowsKey = 8,     // MOD_WIN
    }
    public class HotKeyService
    {
        // Required interop declarations for working with hotkeys
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hwnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32", SetLastError = true)]
        public static extern int UnregisterHotKey(IntPtr hwnd, int id);
        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);
        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalDeleteAtom(short nAtom);

        public const int WM_HOTKEY = 0x312;

        /// <summary>
        /// The unique ID to receive hotkey messages
        /// </summary>
        public short HotkeyID { get; private set; }

        /// <summary>
        /// Handle to the window listening to hotkeys
        /// </summary>
        private IntPtr _windowHandle;

        /// <summary>
        /// Callback for hot keys
        /// </summary>
        Action<int> _onHotKeyPressed;

        // --------------------------------------------------------------------------
        /// <summary>
        /// ctor
        /// </summary>
        // --------------------------------------------------------------------------

        public HotKeyService(Window handlerWindow, Action<int> hotKeyHandler)
        {
            _onHotKeyPressed = hotKeyHandler;

            // Create a unique Id for this class in this instance
            string atomName = Thread.CurrentThread.ManagedThreadId.ToString("X8") + this.GetType().FullName;
            HotkeyID = GlobalAddAtom(atomName);

            // Set up the hook to listen for hot keys
            _windowHandle = new WindowInteropHelper(handlerWindow).Handle;
            if (_windowHandle == null)
            {
                throw new ApplicationException("Cannot find window handle.  Try calling this on or after OnSourceInitialized()");
            }
            var source = HwndSource.FromHwnd(_windowHandle);
            source.AddHook(HwndHook);
        }

        // --------------------------------------------------------------------------
        /// <summary>
        /// Intermediate processing of hotkeys
        /// </summary>
        // --------------------------------------------------------------------------
        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY && wParam.ToInt32() == HotkeyID)
            {
                _onHotKeyPressed?.Invoke(lParam.ToInt32());
                handled = true;
            }
            return IntPtr.Zero;
        }

        // --------------------------------------------------------------------------
        /// <summary>
        /// Tell what key you want to listen for.  Returns an id representing
        /// this particular key combination.  Use this in your handler to 
        /// disambiguate what key was pressed.
        /// </summary>
        // --------------------------------------------------------------------------
        public uint ListenForHotKey(Keys key, HotKeyModifiers modifiers)
        {
            RegisterHotKey(_windowHandle, HotkeyID, (uint)modifiers, (uint)key);
            return (uint)modifiers | (((uint)key) << 16);
        }

        // --------------------------------------------------------------------------
        /// <summary>
        /// Stop listening for hotkeys
        /// </summary>
        // --------------------------------------------------------------------------
        private void StopListening()
        {
            if (this.HotkeyID != 0)
            {
                UnregisterHotKey(_windowHandle, HotkeyID);
                // clean up the atom list
                GlobalDeleteAtom(HotkeyID);
                HotkeyID = 0;
            }
        }

        // --------------------------------------------------------------------------
        /// <summary>
        /// Dispose
        /// </summary>
        // --------------------------------------------------------------------------
        public void Dispose()
        {
            StopListening();
        }
    }

}
