using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="marca">marca</param>
        /// <param name="codigo">numero de chasis</param>
        /// <param name="color">color</param>
        public Camioneta(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {

        }
        
        /// <summary>
        /// Expone el contenido deun objeto de la clase Camioneta a través de un string
        /// </summary>
        /// <returns>Contenido del objeto de clase Camioneta en formato string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
