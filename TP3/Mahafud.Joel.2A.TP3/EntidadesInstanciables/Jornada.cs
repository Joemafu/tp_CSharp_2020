using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        /// <summary>
        /// Atributos de instancia.
        /// </summary>
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Propiedad Alumnos de lectura y escritura.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad Clase de lectura y escritura.
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Propiedad Instructor de lectura y escritura.
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Sobrecarga del constructor.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Guarda una Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        /// <returns>Retorna true en caso de éxito, false en caso contrario.</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool ret = false;

            Texto txt = new Texto();
            try
            {
                ret = txt.Guardar("archivo.txt", jornada.ToString());
            }
            catch
            {

            }
            return ret;
        }

        /// <summary>
        /// Lee un archivo de texto.
        /// </summary>
        /// <returns>Devuelve un string con el texto leído.</returns>
        public static string Leer()
        {
            string ret=null;

            Texto txt = new Texto();
            try
            {
                txt.Leer("archivo.txt", out ret);
            }
            catch
            {

            }
            return ret;
        }

        /// <summary>
        /// Convierte un objeto Jornada a string
        /// </summary>
        /// <returns>String con los valores de la Jornada que lo invoca.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DE " + this.clase + " POR " + this.instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this.Alumnos)
            {
                sb.Append(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        /// <summary>
        /// Compara desigualdad entre jornada y alumno.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Retorna false si el alumno está en la lista de la Jornada true caso contrario </returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a una Jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna la Jornada con el alumno agregado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j!=a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Compara desigualdad entre jornada y alumno.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Retorna true si el alumno está en la lista de la Jornada false caso contrario </returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool ret = false;
            foreach (Alumno item in j.alumnos)
            {
                if (item==a)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}