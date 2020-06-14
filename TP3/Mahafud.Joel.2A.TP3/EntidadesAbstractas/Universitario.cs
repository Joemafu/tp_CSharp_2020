using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        /// <summary>
        /// Atributos de instancia;
        /// </summary>
        private int legajo;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Sobrecarga del constructor.
        /// </summary>
        /// <param name="legajo">Legajo del Universitario</param>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Sobrecarga Equals. Compara igualdad entre objetos.
        /// </summary>
        /// <param name="obj">Objeto a comparar con la instancia que llama al método.</param>
        /// <returns>Retorna true si son iguales, false si son distintos.</returns>
        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj is Universitario)
            {
                ret = ((Universitario)obj)==this;
            }
            return ret;
        }

        /// <summary>
        /// Genera un string con todos los valores de la instancia de Universitario que lo invoca.
        /// </summary>
        /// <returns>String con valores de sus atributos.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this.legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Genera un string con la clase que toma el Universitario.
        /// </summary>
        /// <returns>Retorna un string con la clase que toma.</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara desigualdad entre Universitarios por legajo.
        /// </summary>
        /// <param name="pg1">Universitario 1 a comparar</param>
        /// <param name="pg2">Universitario 2 a comparar</param>
        /// <returns>Retorna true si tienen diferentes legajos, false si son iguales.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Compara igualdad entre Universitarios por legajo.
        /// </summary>
        /// <param name="pg1">Universitario 1 a comparar</param>
        /// <param name="pg2">Universitario 2 a comparar</param>
        /// <returns>Retorna true si tienen mismo legajo, false si son diferentes.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool ret = false;

            if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                ret = true;
            }

            return ret;
        }
    }
}