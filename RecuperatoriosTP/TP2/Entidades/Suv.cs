﻿using System;
using System.Text;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        public Suv (Vehiculo.EMarca marca, string chasis, ConsoleColor color)
        : base(marca, chasis, color)
        {
        }
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {

                return ETamanio.Grande;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.Append($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

    }
}
