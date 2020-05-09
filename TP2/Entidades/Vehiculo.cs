using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        private string chasis;
        private ConsoleColor color;
        private EMarca marca;

        /// <summary>
        /// Enumerador de Marcas
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        /// <summary>
        /// Enumerador de Tamaños
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Castea de forma explícita un objeto de tipo Vehiculo a objeto de tipo string
        /// </summary>
        /// <param name="p">String con el contenido del objeto Vehiculo</param>
        public static explicit operator string (Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>String con el contenido del objeto que invoca al método</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Vahículo numero 1</param>
        /// <param name="v2">Vahículo numero 2</param>
        /// <returns>true o false si son iguales o distintos respectivamente</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis  == v2.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Vahículo numero 1</param> 
        /// <param name="v2">Vahículo numero 2</param> 
        /// <returns>true o false si son distintos o iguales respectivamente</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="chasis">numero de chasis</param>
        /// <param name="marca">marca</param>
        /// <param name="color">color</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// Sirve como la función hash predeterminada.
        /// </summary>
        /// <returns>Código hash para el objeto actual.</returns> 
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
  
        /// <summary>
        /// Determina si el objeto especificado es igual al objeto actual.
        /// </summary>
        /// <param name="obj">Objeto que se va a comparar con el objeto actual.</param>
        /// <returns>Es true si el objeto especificado es igual al objeto actual; en caso contrario, es false.</returns>
        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj is Vehiculo)
            {
                ret = this == (Vehiculo)obj;
            }
            return ret;
        }
    }
}
