using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda en un archivo de texto
        /// </summary>
        /// <param name="archivo">path conde se guardará el archivo.</param>
        /// <param name="datos">String a guardar</param>
        /// <returns>Retorna true en caso de éxito, caso contrario false</returns>
        public bool Guardar (string archivo, string datos)
        {
            bool exito = false;

            try
            {
                StreamWriter sw = new StreamWriter(archivo,false,Encoding.UTF8);
                sw.WriteLine(datos);
                sw.Close();
                exito = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return exito;
        }

        /// <summary>
        /// Lee de un archivo de texto
        /// </summary>
        /// <param name="archivo">Path del archivo a leer</param>
        /// <param name="datos">String que recibirá el contenido leído</param>
        /// <returns>Retorna true si leyo correctamente, caso contrario false</returns>
        public bool Leer (string archivo, out string datos)
        {
            bool exito = false;

            try
            {
                using (StreamReader sr = new StreamReader(archivo,Encoding.UTF8))
                {
                    datos=sr.ReadToEnd();
                }
                exito = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return exito;
        }
    }
}
