using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        /// <summary>
        /// Atributos de instancia.
        /// </summary>
        private Queue<Universidad.EClases> clasesDelDia;

        /// <summary>
        /// Atributos de clase.
        /// </summary>
        private static Random random;

        /// <summary>
        /// Inicializa el atributo clasesDelDía y pone en cola 2 clases generadas aleatoriamente.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Profesor() : base()
        {
            this._randomClases();
        }

        /// <summary>
        /// Constructor de Clase.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Sobrecarga de constructor.
        /// </summary>
        /// <param name="id">Legajo del Universitario..</param>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._randomClases();
        }

        /// <summary>
        /// Castea a string los datos del Profesor.
        /// </summary>
        /// <returns>string con los valores de atributo del profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Genera un string con las clases del día de una instancia de Profesor.
        /// </summary>
        /// <returns>string con las clases del día de la instancia de Profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Publica un string con los atributos de un Profesor.
        /// </summary>
        /// <returns>string con los atributos de una instancia de Profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara desigualdad entre Profesor y Clase.
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna true si el Profesor no da esa Clase, false en caso contrario.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Compara igualdad entre Profesor y Clase.
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna true si el Profesor da esa Clase, false en caso contrario.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool ret = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}
