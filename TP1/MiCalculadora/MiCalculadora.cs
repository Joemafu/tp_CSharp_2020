using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    //Diagrama de clases acorde a lo solicitado en el enunciado.
    public partial class LaCalculadora : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public LaCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Realiza la operación indicada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string n1 = txtNumero1.Text;
            string n2 = txtNumero2.Text;
            string operador = cmbOperador.Text;

            lblResultado.Text = (Convert.ToString(Operar(n1, n2, operador)));
        }

        /*  El botón btnCerrardeberá cerrar el formulario.*/
        /// <summary>
        /// Cierra la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Limpia el contenido de los textbox, del combobox y del label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

         /*  El evento click del botón btnConvertirABinarioconvertirá el resultado,
         *   de existir, a binario.*/
         /// <summary>
         /// Convierte de decimal a binario.
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero n = new Numero();
            lblResultado.Text = n.DecimalBinario(lblResultado.Text);
        }

        /*  El evento click del botón btnConvertirADecimal convertirá el resultado,
        *   de existir y ser binario, a decimal.*/
        /// <summary>
        /// Convierte de binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero n = new Numero();
            lblResultado.Text = n.BinarioDecimal(lblResultado.Text);
        }

        /*  El método Limpiar será llamado por el evento click del botón btnLimpiar y
        *   borrará los datos de los TextBox, ComboBox y Label de la pantalla.*/
        /// <summary>
        /// Limpia el contenido de los textbox, del combobox y del label.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.ResetText();
            cmbOperador.ResetText();
            txtNumero2.ResetText();
            lblResultado.ResetText();
        }

        /*  El método Operar será estático recibirá los dos números y el operador para luego llamar
        *   al método Operar de Calculadora y retornar el resultado al método de evento del botón 
        *   btnOperar que reflejará el resultado en el Label txtResultado.*/
        /// <summary>
        /// Recibe dos numeros y un operador en string, opera a través del método Operar de la clase Calculadora
        /// y retorna el resultado en doble.  
        /// </summary>
        /// <param name="numero1"></param> Numero a operar en string.
        /// <param name="numero2"></param> Numero a operar en string.
        /// <param name="operador"></param> Operador a utilizar en string.
        /// <returns></returns>
        private static double Operar (string numero1, string numero2, string operador)
        {
            double ret;
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            ret = Calculadora.Operar(n1, n2, operador);

            return ret;
        }
    }
}
