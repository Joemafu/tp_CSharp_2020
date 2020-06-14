using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo <T>
    {
        /// <summary>
        /// Guarda en un archivo xml
        /// </summary>
        /// <param name="archivo">path conde se guardará el archivo.</param>
        /// <param name="datos">Tipo de dato que va a guardar</param>
        /// <returns>Retorna true en caso de éxito, caso contrario false</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool exito = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                    exito = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return exito;            
        }

        /// <summary>
        /// Lee de un archivo xml
        /// </summary>
        /// <param name="archivo">Path del archivo a leer</param>
        /// <param name="datos">Tipo de dato que va a leer</param>
        /// <returns>Retorna true si leyo correctamente, caso contrario false</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool exito = false;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                    exito = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return exito;
        }
    }
}
