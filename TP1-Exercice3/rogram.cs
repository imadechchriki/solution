// Program.cs - Point d'entrée du programme
using System;
using System.Windows.Forms;

namespace MagasinReprographie
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormFacture());
        }
    }
}