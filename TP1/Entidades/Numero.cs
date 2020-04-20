using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        /*  El atributo numero es privado.*/
        private double numero;

        /*  El constructor por defecto(sin parámetros) asignará valor 0 al atributo numero.*/
        /// <summary>
        /// Asigna el valor 0 al atributo numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        ///  Asigna el valor del double recibido al atributo numero.
        /// </summary>
        /// <param name="numero"></param> Recibe un double por parámetro
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Asigna el string al atributo numero del Numero, previa validación del mismo.
        /// </summary>
        /// <param name="strNumero"></param> Recibe un número en formato string.
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /*  ValidarNumero comprobará que el valor recibido sea numérico, y lo retornará en formato double. 
         *  Caso contrario, retornará 0.*/
        /// <summary>
        /// Intenta convertir el string recibido a double y lo devuelve.
        /// En caso de no conseguirlo (por no ser un string numérico) retorna 0 por defecto.
        /// dev
        /// </summary>
        /// <param name="strNumero"></param> Recibe un string. 
        /// <returns></returns> Retorna el string convertido a doble o 0 si no lo logra.
        private double ValidarNumero(string strNumero)
        {
            double ret = 0;
            try
            {
                ret = Convert.ToDouble(strNumero);
            }
            catch
            {

            }
            return ret;
        }

        /*  El método SetNumero asignará un valor al atributo número, previa validación.
        *   En este lugar será el único en todo el código que llame al método ValidarNumero.*/
        /// <summary>
        /// Valida que el string contenga un numero y lo setea.
        /// </summary>
        private string SetNumero
        {
            set 
            { 
                this.numero=ValidarNumero(value);
            }
        }


        /* Los métodos BinarioDecimal y DecimalBinario convertirán el Resultado, 
        *  trabajarán con enteros positivos, quedándose para esto con el valor absoluto
        *  y entero del double recibido:
        *            
        *  El método BinarioDecimalconvertirá un número binario a decimal, en caso de ser posible.
        *  Caso contrario retornará "Valor inválido".
        */
        /// <summary>
        /// Valida que el string recibido contenga un numero y que esté en formato binario (ceros y unos) y
        /// lo convierte a decimal (digitos del 0 al 9) tomando solo su parte entera absoluta.
        /// Caso contrario retorna "Valor inválido".
        /// </summary>
        /// <param name="binario"></param> Espera un numero binario en formato string
        /// <returns></returns> Un string con el numero convertido a decimal en caso de éxito, o 
        /// "Valor inválido" en caso de error. 
        public string BinarioDecimal(string binario)
         {
            double entero;
            string ret = "Valor inválido";
            bool esBinario = true;

            if (!String.IsNullOrEmpty(binario))
            {
                foreach (char digito in binario)
                {
                    if (digito != '1' && digito != '0' && digito != '-' && digito != ',')
                    {
                        esBinario = false;
                        break;
                    }
                }
                if (esBinario == true)
                {
                    entero = (int)Convert.ToDouble(binario);
                    entero = Math.Abs(entero);
                    ret = Convert.ToString(Convert.ToInt64(Convert.ToString(entero), 2));
                }
            }
            return ret;
        }

        /*  Los métodos BinarioDecimal y DecimalBinario convertirán el Resultado, 
        *  trabajarán con enteros positivos, quedándose para esto con el valor absoluto
        *  y entero del double recibido:
        *            
        *  Ambas opciones del método DecimalBinario convertirán un número decimal a binario, 
        *  en caso de ser posible. Caso contrario retornará "Valor inválido". Reutilizar código.
        */
        /// <summary>
        /// Valida que el doble recibido sea un número, toma su parte entera absoluta y la convierte a binario.
        /// De no ser posible retorna "Valor inválido"
        /// </summary>
        /// <param name="numero"></param> Recibe un doble con el número a convertir.
        /// <returns></returns> Retorna un string con el numero convertido a binario, o "Valor inválido" en caso de error
        public string DecimalBinario(double numero)
        {
            string ret = "Valor inválido";
            
            if (!Double.IsNaN(numero))
            {
                numero = (int)Math.Abs(numero);

                ret = Convert.ToString(Convert.ToInt64(Convert.ToString(numero), 10),2); ;
            }

            return ret;
        }

        /*  Los métodos BinarioDecimal y DecimalBinario convertirán el Resultado, 
        *  trabajarán con enteros positivos, quedándose para esto con el valor absoluto
        *  y entero del double recibido:
        *            
        *  Ambas opciones del método DecimalBinarioconvertirán un número decimal a binario, 
        *  en caso de ser posible. Caso contrario retornará "Valor inválido". Reutilizar código.
        */
        /// <summary>
        /// Espera un numero en formato string, valida que sea un numero y lo convierte a binario a través de una sobrecarga.
        /// De no se posible, retorna "Valor inválido.
        /// </summary>
        /// <param name="numero"></param> Recibe un numero en string.
        /// <returns></returns> Retorna un string con el número recibido en base binaria. 
        public string DecimalBinario(string numero)
        {
            double doble;
            bool esValido;
            string ret = "Valor inválido";

            esValido = Double.TryParse(numero, out doble);

            if(esValido==true)
            {
                ret = DecimalBinario(doble);
            }

            return ret;
        }

        /*  Los operadores realizarán las operaciones correspondientes entre dos números.*/
        /// <summary>
        /// Suma dos objetos del tipo "Numero" a través de su atributo "numero".
        /// </summary>
        /// <param name="n1"></param> Objeto del tipo Numero.
        /// <param name="n2"></param> Objeto del tipo Numero.
        /// <returns></returns> 
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos objetos del tipo "Numero" a través de su atributo "numero".
        /// </summary>
        /// <param name="n1"></param> Objeto del tipo Numero.
        /// <param name="n2"></param> Objeto del tipo Numero.
        /// <returns></returns> 
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /*      Si se tratara de una división por 0, retornará double.MinValue.*/
        /// <summary>
        /// Divide dos objetos del tipo "Numero" a través de su atributo "numero".
        /// En caso de división por cero, devuelve el mínimo valor de un doble.
        /// </summary>
        /// <param name="n1"></param> Objeto del tipo Numero.
        /// <param name="n2"></param> Objeto del tipo Numero.
        /// <returns></returns> 
        public static double operator /(Numero n1, Numero n2)
        {
            double ret = double.MinValue;
            if (n2.numero != 0)
            {
                ret = n1.numero / n2.numero;
            }
            return ret;
        }

        /// <summary>
        /// Multiplica dos objetos del tipo "Numero" a través de su atributo "numero".
        /// </summary>
        /// <param name="n1"></param> Objeto del tipo Numero.
        /// <param name="n2"></param> Objeto del tipo Numero.
        /// <returns></returns> 
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

    }
}
