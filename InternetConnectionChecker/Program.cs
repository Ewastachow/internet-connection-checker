using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime.InteropServices;

namespace InternetConnectionChecker
{
    class Program
    {
        private static FileManager fm;
        private static List<string> ipAddressList;
        private static Timer aTimer;
        private static int delay;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        private static void initialize()
        {
            fm = new FileManager();

            ipAddressList = new List<string>(new string[]
            {
                "www.google.com",
                "www.onet.pl"
            });

            aTimer = new Timer(10000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = delay;
            aTimer.Enabled = true;

            delay = 10000;
        }

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            initialize();
            
            Console.Read();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            fm.Path = AppDomain.CurrentDomain.BaseDirectory + DateTime.Today.ToString("yyyy-MM-dd") + "-netLog.txt";
            // fm.Path = "C:\\NetConnectionChecker\\" + DateTime.Today.ToString("yyyy -MM-dd") + "-netLog.txt";
            fm.GenerateStatus(ipAddressList);
        }
    }
}
