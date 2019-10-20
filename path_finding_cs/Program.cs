using path_finding_cs.mapSetter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace path_finding_cs
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();

            MapSetter mapSetter = new MapSetter(mainForm);

            mainForm.mapSetter = mapSetter;

            Application.Run(mainForm);
        }
    }
}
