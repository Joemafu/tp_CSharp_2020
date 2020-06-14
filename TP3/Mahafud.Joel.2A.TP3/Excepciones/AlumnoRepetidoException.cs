using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Excepción que se da cuando se intenta añadir un alumno repetido a una Universidad.
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }
    }
}
