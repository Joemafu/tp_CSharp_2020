using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo <T>
    {
        /// <summary>
        /// Guarda en un archivo
        /// </summary>
        /// <param name="archivo">path conde se guardará el archivo.</param>
        /// <param name="datos">Tipo de dato que va a guardar</param>
        /// <returns>Retorna true en caso de éxito, caso contrario false</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee de un archivo
        /// </summary>
        /// <param name="archivo">Path del archivoa leer</param>
        /// <param name="datos">Tipo de dato que va a leer</param>
        /// <returns>Retorna true si leyo correctamente, caso contrario false</returns>
        bool Leer(string archivo, out T datos);
    }
}
