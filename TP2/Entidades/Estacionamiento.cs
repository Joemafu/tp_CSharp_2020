﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        private int espacioDisponible;
        private List<Vehiculo> vehiculos;
        
        /// <summary>
        /// Constructor sin parámetros.
        /// </summary>
        public enum ETipo
        {
            Moto,
            Automovil,
            Camioneta,
            Todos
        }

        #region "Constructores"
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="espacioDisponible">Recibe cantidad de espacios disponibles en int</param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>String construído</returns> 
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case (ETipo.Camioneta):
                        {
                            if (v is Camioneta)
                            {
                                sb.AppendLine(v.Mostrar());
                            }
                            break;
                        }
                    case (ETipo.Moto):
                        {
                            if (v is Moto)
                            {
                                sb.AppendLine(v.Mostrar());
                            }
                            break;
                        }
                    case (ETipo.Automovil):
                        {
                            if (v is Automovil)
                            {
                                sb.AppendLine(v.Mostrar());
                            }
                            break;
                        }
                    default:
                        {
                            sb.AppendLine(v.Mostrar());
                            break;
                        }
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>String del estacionamiento y todos sus vehículos</returns> 
        public override string ToString()
        {
            return Estacionamiento.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>Lista luego de la adición</returns>  
        public static Estacionamiento operator + (Estacionamiento c, Vehiculo p)
        {
            bool vehiculoYaExiste=false;
            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                {
                    vehiculoYaExiste = true;
                    break;
                }
            }
            if(vehiculoYaExiste == false && c.espacioDisponible > c.vehiculos.Count)
            {
                c.vehiculos.Add(p);
            }
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns>Lista luego de la extracción</returns> 
        public static Estacionamiento operator - (Estacionamiento c, Vehiculo p)
        {
            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                {
                    c.vehiculos.Remove(v);
                    break;
                }
            }
            return c;
        }
        #endregion
    }
}
