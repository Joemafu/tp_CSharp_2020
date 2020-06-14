using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        /// <summary>
        /// Enumerado de nacionalidades.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        /// <summary>
        /// Atributos de instancia.
        /// </summary>
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Propiedad lectura y escritura de apellido
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                try
                {
                    if (!(ValidarNombreApellido(value) is null))
                    {
                        this.apellido = value;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Propiedad lectura y escritura de dni
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set
            {
                try
                {
                    if (ValidarDNI(this.Nacionalidad, value) != -1)
                    {
                        this.dni = value;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Propiedad lectura y escritura de nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }

            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad lectura y escritura de nombre.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (!(ValidarNombreApellido(value) is null))
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// Propiedad solo escritura de DNI (a través de string).
        /// </summary>
        public string StringToDNI
        {
            set
            {
                int aux;
                
                aux = ValidarDNI(this.nacionalidad, value);
                if (aux > 0)
                {
                    this.DNI = aux;
                }
            }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Sobrecarga de constructor
        /// </summary>
        /// <param name="nombre">Nombre de persona</param>
        /// <param name="apellido">Apellido de persona</param>
        /// <param name="nacionalidad">Nacionalidad de persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Sobrecarga de constructor
        /// </summary>
        /// <param name="nombre">Nombre de persona</param>
        /// <param name="apellido">Apellido de persona</param>
        /// <param name="dni">DNI de persona</param>
        /// <param name="nacionalidad">Nacionalidad de persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Sobrecarga de constructor
        /// </summary>
        /// <param name="nombre">Nombre de persona</param>
        /// <param name="apellido">Apellido de persona</param>
        /// <param name="dni">DNI de persona</param>
        /// <param name="nacionalidad">Nacionalidad de persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) :this (nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Castea Persona a string.
        /// </summary>
        /// <returns>Retorna un string con los valores del objeto Persona.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("NOMBRE COMPLETO: ");
            sb.AppendLine(this.apellido + ", " + this.nombre);
            sb.AppendLine("NACIONALIDAD: " + this.nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Valida que la nacionalidad concuerde con el número de DNI que recibe por parámetros.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            int ret = -1;
            if ((dato > 0 && dato < 90000000 && nacionalidad == ENacionalidad.Argentino) || (dato > 89999999 && dato < 100000000 && nacionalidad == ENacionalidad.Extranjero))
            {
                ret = dni;
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
            return ret;
        }

        /// <summary>
        /// Valida que la nacionalidad concuerde con el número de DNI que recibe por parámetros.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int ret = -1;

            if (int.TryParse(dato, out dni)&&dni>0&&dni<100000000)
            {
                ret = ValidarDNI(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException("DNI inválido exception");
            }
            return ret;
        }

        /// <summary>
        /// Valida que el nombre o apellido que recibe contenga solo letras.
        /// </summary>
        /// <param name="dato">Nombre o Apellido a validar</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string ret = null;
            if (dato.All(char.IsLetter))
            {
                ret = dato;
            }
            return ret;
        }

    }
}
