using System;
using System.Text;
using System.Windows.Forms;

namespace ExtractWithEncodingTool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Application.Run(new Form1());
        }
    }
}
