using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Generar un proyecto del tipo Windows Forms llamado MiCalculadoracon sólo el siguiente formulario:*/
namespace MiCalculadora
{
/*  El nombre de la clase del formulario debe ser FormCalculadora.*/
    static class FormCalculadora
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LaCalculadora());
        }


    }
}
