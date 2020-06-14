using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Excepción que se da cuando no hay un profesor para dar determinada clase
        /// </summary>
        public SinProfesorException() : base ("No hay profesor para la clase.")
        {

        }
    }
}
