using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        /// <summary>
        /// Enumerado de clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        /// <summary>
        /// Atributos de instancia
        /// </summary>
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// Propiedad Alumnos de lectura y escritura 
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad Instructores de lectura y escritura
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Propiedad Jornada de lectura y escritura
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Indexador de Jornada
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i]=value; }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Guarda una Universidad en un archivo xml
        /// </summary>
        /// <param name="uni">Universidad a guardar</param>
        /// <returns>Retorna true en caso de éxito, false en caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            bool ret = false;
            Xml < Universidad > xml = new Xml<Universidad>();
            try
            {
                ret=xml.Guardar("archivo.xml", uni);
            }
            catch
            {

            }
            return ret;
        }

        /// <summary>
        /// Lee una Universidad desde un archivo xml
        /// </summary>
        /// <returns>Retorna la Universidad leída.</returns>
        public static Universidad Leer()
        {
            Universidad ret = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                xml.Leer("archivo.xml", out ret);
            }
            catch
            {

            }
            return ret;
        }
        
        /// <summary>
        /// Castea Universidad a string.
        /// </summary>
        /// <param name="uni">Universidad a castear</param>
        /// <returns>String con los valores de la Universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.Append(item.ToString());
            }

            // Dejo este bloque comentado en caso de que haya que imprimir
            // el resto de los datos de Universidad.
            
            /*sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in uni.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("PROFESORES:");
            foreach (Profesor item in uni.Instructores)
            {
                sb.AppendLine(item.ToString());
            }*/

            return sb.ToString();
        }

        /// <summary>
        /// Publica un string con los campos y valores de una Universidad
        /// </summary>
        /// <returns>String con los atributos de la Universidad que la invoca</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Compara desigualdad entre Universidad y Alumno
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el Alumno no está inscripto en la Universidad, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara desigualdad entre Universidad y Profesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>Retorna true si el Profesor no trabaja en la Universidad, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Compara Universidad y Clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Clase</param>
        /// <returns>Retorna el primer Profesor de la Universidad que no de la clase indicada</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor ret = new Profesor();
            foreach(Profesor item in g.Instructores)
            {
                if(item!=clase)
                {
                    ret=item;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Agrega una Clase a una Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna la Universidad con los cambios aplicados, en caso de éxito y la misma Universidad en caso contrario</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = g == clase;
            Jornada j = new Jornada(clase, p);
            foreach(Alumno item in g.Alumnos)
            {
                if(item==clase)
                {
                    j+=item;
                }
            }
            g.Jornadas.Add(j);
            return g;
        }

        /// <summary>
        /// Agrega un Alumno a una Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Alumno</param>
        /// <returns>Retorna la Universidad con los cambios aplicados, en caso de éxito y la misma Universidad en caso contrario</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g!=a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }

        /// <summary>
        /// Agrega un Profesor a una Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Profesor</param>
        /// <returns>Retorna la Universidad con los cambios aplicados, en caso de éxito y la misma Universidad en caso contrario</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if(g!=i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }

        /// <summary>
        /// Compara igualdad entre Universidad y Alumno
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna false si el Alumno no está inscripto en la Universidad, true en caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool ret = false;

            foreach(Alumno item in g.Alumnos)
            {
                if(item == a)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        /// <summary>
        /// Compara igualdad entre Universidad y Profesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>Retorna false si el Profesor no trabaja en la Universidad, true en caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool ret = false;

            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        /// <summary>
        /// Compara Universidad y Clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Clase</param>
        /// <returns>Retorna el primer Profesor de la Universidad que de la clase indicada</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor ret = new Profesor();
            bool exito = false;
            foreach (Profesor item in g.Instructores)
            {
                if (item == clase)
                {
                    ret = item;
                    exito = true;
                    break;
                }
            }
            if (exito == false)
            {
                throw new SinProfesorException();
            }
            return ret;
        }

        
    }
}
