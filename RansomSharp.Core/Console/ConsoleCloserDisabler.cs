//using Microsoft.Win32;
//using System.Runtime.InteropServices;

//namespace RansomSharp.Core.Console
//{
//    public class ConsoleCloserDisabler
//    {
//        [DllImport("kernel32.dll")]
//        private static extern IntPtr GetConsoleWindow();

//        [DllImport("user32.dll")]
//        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

//        [DllImport("user32.dll")]
//        private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

//        private const uint SC_CLOSE = 0xF060;
//        private const uint MF_GRAYED = 0x00000001;
//        private const uint MF_BYCOMMAND = 0x00000000;

//        public static void DisableCloseButton()
//        {
//            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Console");
//            objRegistryKey.SetValue("AllowAltF4Close", "0", RegistryValueKind.DWord);

//            IntPtr hWndConsole = GetConsoleWindow();
//            if (hWndConsole == IntPtr.Zero)
//            {
//                System.Console.WriteLine("Failed to get console window handle.");
//                return;
//            }

//            IntPtr hSysMenu = GetSystemMenu(hWndConsole, false);
//            if (hSysMenu == IntPtr.Zero)
//            {
//                System.Console.WriteLine("Failed to get system menu.");
//                return;
//            }

//            if (!EnableMenuItem(hSysMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED))
//                System.Console.WriteLine("Failed to disable close button.");
//        }
//    }
//}
