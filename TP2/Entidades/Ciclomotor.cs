﻿using System;
using System.Text;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
        : base(marca,chasis,color)
        {
        }

        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.Append($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
