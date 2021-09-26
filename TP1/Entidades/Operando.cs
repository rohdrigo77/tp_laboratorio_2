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

        public string Numero
        {
            
            get 
            {
                return Convert.ToString(this.numero);
            }
                      
            set
            {
                if (ValidarOperando(value) > 0)
                {
                    this.numero = Convert.ToDouble(value);
                }            
            }
        }

        public static implicit operator Operando(double d)
        {
            return new Operando(d);
        }

        public Operando()
        {
            this.numero = 0;
        }
        public Operando (double numero)
        { 
            this.numero = numero;
        }
        public Operando(string strNumero)
        {
            this.numero = Convert.ToDouble(strNumero);
        }
        public static double operator - (Operando n1, Operando n2)
        {
            return n1 - n2;
        }
        public static double operator * (Operando n1, Operando n2)
        {
            return n1 * n2;
        }
        public static double operator / (Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1 / n2;
            }
            else
            {
                return double.MinValue;
            }

        }
        public static double operator + (Operando n1, Operando n2)
        {
            return n1 + n2;
        }
        public double ValidarOperando(string strNumero)
        {          
            if (double.TryParse(strNumero,out double doble))
            {
                return doble; 
            }
            else
            {
                return 0;
            }
        }
        public bool EsBinario(string binario)
        {
            bool estado = true;

            for (int i = 0;i<binario.Length;i++)
            {
                if (binario[i] < 0 && binario[i] > 1)
                {    
                    estado = false;
                    break;
                }
            }

            return estado;
        }
        public string BinarioDecimal (string numero)
        {
            string estado;
     
            if (EsBinario(numero))
            {
                

                estado = Convert.ToInt64(numero, 2).ToString();

                

            }
            else
            {
                estado = "Número inválido";
            }

            return estado;

        }

        public string DecimalBinario(double numero)
        {
            string numBin = string.Empty;
            int numInt =(int) numero;

            if (numInt == 0)
            {
                numBin = "0";
            }
            else
            {
                while (numInt > 0)
                {
                    numBin = (int)numInt % 2 + numBin;
                    numInt = (int)numInt / 2;
                }

            }
            
            return numBin;
            
        }

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
                bin = DecimalBinario(Convert.ToDouble(numero));
            }

            return bin;

        }



       





















    }
}
