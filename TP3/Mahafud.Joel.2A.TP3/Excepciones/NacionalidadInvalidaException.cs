using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Excepción que se da cuando la nacionalidad de una Persona no se condice con su DNI
        /// </summary>
        public NacionalidadInvalidaException() : base()
        {

        }

        /// <summary>
        /// Excepción que se da cuando la nacionalidad de una Persona no se condice con su DNI
        /// </summary>
        public NacionalidadInvalidaException(string message) : base (message)
        {

        }
    }
}
