using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Clase estática Calculadora:
    public static class Calculadora
    {
/*      El método ValidarOperador será privado y estático. 
        Deberá validar que el operador recibido sea +, -, / o *. Caso contrario retornará +.*/
        /// <summary>
        /// Valida que el dato ingresado sea un operador aceptado y lo retorna.
        /// En caso negativo, retorna '+'.
        /// </summary>
        /// <param name="operador"></param> Recibe un string con el operador.
        /// <returns></returns> Retorna el operador si es válido, de lo contrario retorna '+'.
        private static string ValidarOperador(string operador)
        {
            string ret = "+";

            if (operador == "-" || operador == "/" || operador == "*")
            {
                ret = operador;
            }
            return ret;
        }

        /*  El método Operar será de clase: validará y realizará la operación pedida entre ambos números.*/
        /// <summary>
        /// Realiza una operación (suma, resta, división o multiplicación) a partir de los parámetros recibidos.
        /// </summary>
        /// <param name="num1"></param> Objeto del tipo Numero para operar. 
        /// <param name="num2"></param> Objeto del tipo Numero para operar.
        /// <param name="operador"></param> Operador a utilizar.
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    {
                        resultado = num1 + num2;
                        break;
                    }
                case "-":
                    {
                        resultado = num1 - num2;
                        break;
                    }
                case "/":
                    {
                        resultado = num1 / num2;
                        break;
                    }
                case "*":
                    {
                        resultado = num1 * num2;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return resultado;
        }
    }
}
