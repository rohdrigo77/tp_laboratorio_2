using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Propiedad Numero
        /// </summary>
        public string Numero
        {
            
            get 
            {
                return (this.numero).ToString();
            }
                      
            set
            {
                if (double.TryParse(value, out double doble))
                {
                    this.numero = doble;
                }            
            }
        }

        /// <summary>
        /// Operador implicito de clase Operando segun parametro recibido
        /// </summary>
        /// <param name="d"></param>
        public static implicit operator Operando(double d)
        {
            return new Operando(d);
        }
        /// <summary>
        /// Constructor publico operando
        /// </summary>
        public Operando()
        : this(0)
        {  
        }
        /// <summary>
        /// Constructor publico operando que asigna el parametro recibido al atributo "numero"
        /// </summary>
        /// <param name="numero"></param>
        public Operando (double numero)
        { 
            this.numero = numero;
        }
        /// <summary>
        /// Constructor publico operando que asigna el parametro recibido al atributo "numero" luego de conversión
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Operador resta
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>resta entre operandos</returns>
        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Operador multiplicacion
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>multiplicacion entre operandos</returns>
        public static double operator * (Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Operador division
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>division entre operandos</returns>
        public static double operator / (Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }

        }

        /// <summary>
        /// Operador suma
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>suma entre operandos</returns>
        public static double operator + (Operando n1, Operando n2)
        {
            return n1 + n2;
        }

        /// <summary>
        /// Metodo para saber si el parametro recibido es binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>true si es binario, false si no</returns>
        public bool EsBinario(string binario)
        {
            bool estado = true;

            for (int i = 0; i<binario.Length; i++)
            {
                if (Convert.ToInt32(binario[i]) < 0 && Convert.ToInt32(binario[i]) > 1)
                {    
                    estado = false;
                    break;
                }
            }

            return estado;
        }

        /// <summary>
        /// Metodo para convertir numero binario en decimal
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>numero binario en decimal, "valor invalido" si no</returns>
        public string BinarioDecimal (string numero)
        {     
            double numDecimal = 0;

            if (numero[0] != '-')
            {
                if (EsBinario(numero))
                {
                    numDecimal = Convert.ToInt32(numero.ToString(), 2);

                }
                else
                {
                    return "Valor invalido";
                }
            }
               
            
            return numDecimal.ToString();

        }

        /// <summary>
        /// Metodo para convertir de decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>numero decimal convertido en binario</returns>
        public string DecimalBinario(double numero)
        {
            string numBin = string.Empty;
            int numInt = (int) numero; 

            if (numInt == 0)
            {
                numBin = "0";
            }
            else
            {
                if (numInt > 0)
                {
                    while (numInt > 0)
                    {
                        numBin = (int)numInt % 2 + numBin;
                        numInt = (int)numInt / 2;
                    }
                }

            }
            
            return numBin;
            
        }

        /// <summary>
        /// Metodo para convertir un string que representa a un numero decimal en binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            string bin = "";
            int estado = 1;

            foreach (char c in numero)
            {
                if (Char.IsNumber(c) == false)
                {
                    bin = "Valor Inválido";
                    estado = -1;
                    break;
                }
            }

            if (estado > 0)
            {
                if ( int.Parse(numero) > 0)
                {
                    bin = DecimalBinario(double.Parse(numero));
                }
                
            }

            return bin;

        }



       





















    }
}
