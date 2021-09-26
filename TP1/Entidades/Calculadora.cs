﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado;

            switch (ValidarOperador(operador))
            {
                case '*':
                    resultado = Convert.ToDouble(num1.Numero) * Convert.ToDouble(num2.Numero);
                    break;
                case '/':
                    resultado = Convert.ToDouble(num1.Numero) / Convert.ToDouble(num2.Numero);
                    break;
                case '-':
                    resultado = Convert.ToDouble(num1.Numero) - Convert.ToDouble(num2.Numero);
                    break;
                default:
                    resultado = Convert.ToDouble(num1.Numero) + Convert.ToDouble(num2.Numero);
                    break;
            }

            return resultado;
        }

        private static char ValidarOperador(char operador)
        {
            if (operador == '*' || operador == '/' || operador == '-')
            {
                return operador;
            }
            else
            {
                return '+';
            }   
        }
    }
}
