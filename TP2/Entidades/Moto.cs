using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="marca">marca</param>
        /// <param name="codigo">numero de chasis</param>
        /// <param name="color">color</param>
        public Moto(EMarca marca, string codigo, ConsoleColor color) : base(codigo,marca,color)
        {

        }

        /// <summary>
        /// Expone el contenido deun objeto de la clase moto a través de un string
        /// </summary>
        /// <returns>Contenido del objeto de clase Moto en formato string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
