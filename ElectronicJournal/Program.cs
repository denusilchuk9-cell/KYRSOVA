using System;
using System.Windows.Forms;
using ElectronicJournal.Forms;

namespace ElectronicJournal
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}