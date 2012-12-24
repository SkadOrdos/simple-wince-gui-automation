using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleWinceGuiAutomation.AppTest
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}