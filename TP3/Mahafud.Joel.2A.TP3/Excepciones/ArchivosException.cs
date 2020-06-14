using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepción que se da cuando ocurre un error al leer o escribir un archivo.
        /// </summary>
        public ArchivosException(Exception innerException) : base ("Error con el archivo.", innerException)
        {

        }
    }
}
