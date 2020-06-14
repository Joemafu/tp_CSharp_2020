using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Excepción que se da cuando el DNI de una persona está fuera de los parámetros establecidos.
        /// </summary>
        public DniInvalidoException() : base()
        {

        }

        /// <summary>
        /// Excepción que se da cuando el DNI de una persona está fuera de los parámetros establecidos.
        /// </summary>
        public DniInvalidoException(Exception e) : base ("DNI inválido",e)
        {

        }

        /// <summary>
        /// Excepción que se da cuando el DNI de una persona está fuera de los parámetros establecidos.
        /// </summary>
        public DniInvalidoException(string message) : base (message)
        {

        }

        /// <summary>
        /// Excepción que se da cuando el DNI de una persona está fuera de los parámetros establecidos.
        /// </summary>
        public DniInvalidoException(string message, Exception e) : base (message, e)
        {

        }
    }
}
