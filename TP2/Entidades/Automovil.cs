using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        private ETipo tipo;
        public enum ETipo 
        { 
            Monovolumen,
            Sedan
        }

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">marca</param>
        /// <param name="codigo">numero de chasis</param>
        /// <param name="color">color</param>
        public Automovil (EMarca marca, string codigo, ConsoleColor color)
            : base (codigo, marca, color)
        {
            this.tipo = ETipo.Monovolumen;
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="marca">marca</param>
        /// <param name="codigo">numero de chasis</param>
        /// <param name="color">color</param>
        /// <param name="tipo">tipo de automovil</param>
        public Automovil (EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : this (marca, codigo, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Expone el contenido deun objeto de la clase Automovil a través de un string
        /// </summary>
        /// <returns>Contenido del objeto de clase Automovil en formato string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
