using System;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Menu men = new Menu();
            Application.Run(men);
        }
    }
}