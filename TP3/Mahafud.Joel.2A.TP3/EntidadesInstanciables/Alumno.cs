using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        /// <summary>
        /// Enumerado de estados de cuenta.
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        /// <summary>
        /// Atrinbutos de instancia.
        /// </summary>
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno() : base()
        {

        }

        /// <summary>
        /// Sobrecarga del constructor.
        /// </summary>
        /// <param name="id">Legajo del Universitario.</param>
        /// <param name="nombre">Nombre de la Persona.</param>
        /// <param name="apellido">Apellido de la Persona.</param>
        /// <param name="dni">DNI de la Persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base (id,nombre,apellido,dni,nacionalidad) 
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Sobrecarga del constructor.
        /// </summary>
        /// <param name="id">Legajo del Universitario.</param>
        /// <param name="nombre">Nombre de la Persona.</param>
        /// <param name="apellido">Apellido de la Persona.</param>
        /// <param name="dni">DNI de la Persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        /// <param name="estadoCuenta">Estado de cuenta del Alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Castea a String todos los atributos del objeto Alumno.
        /// </summary>
        /// <returns>String con los valores de los atributos de la instancia.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append("ESTADO DE LA CUENTA: ");
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                {
                    sb.AppendLine("Cuota al día");
                    break;
                }
                case EEstadoCuenta.Becado:
                {
                    sb.AppendLine("Tiene beca");
                    break;
                }
                case EEstadoCuenta.Deudor:
                {
                    sb.AppendLine("Pago pendiente");
                    break;
                }
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Genera un string con la clase que toma el alumno.
        /// </summary>
        /// <returns>String con la clase que toma el alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma;
        }

        /// <summary>
        /// Publica un string con los datos del Alumno.
        /// </summary>
        /// <returns>String con los valores del alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara por diferencia si un alumno toma determinada clase.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna false si el alumno toma la clase, true si no la toma.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool ret = true;
            if (a.claseQueToma == clase)
            {
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// Compara por igualdad si un alumno toma determinada clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna true si y solo si el alumno toma la clase y no es deudor, false en caso de no cumplir alguno de los requisitos</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool ret = false;
            if ((!(a != clase)) && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                ret = true;
            }
            return ret;
        }
    }
}
