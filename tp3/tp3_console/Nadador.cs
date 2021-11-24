using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate string PrintearNadador(Nadador nadador);
    public class Nadador : Socix
    {
        private EPileta tipoPileta;
        private EEstilos estiloPreferido;
        private PrintearNadador printearSocix;

        public Nadador(int dni, string nombre, string apellido, EGenero genero, int edad,ECuota valorCuota, ETipoSocix tipoSocix, int cantMedallas, EPileta pileta, EEstilos estiloPreferido, string fechaAptaFisica, string fechaAsociacion)
        : base(dni, nombre, apellido, genero, edad, valorCuota, tipoSocix, cantMedallas, fechaAptaFisica, fechaAsociacion)
        {
            this.tipoPileta = pileta;
            this.estiloPreferido = estiloPreferido;
            printearSocix = MostrarNadadorx;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder(276438, Int32.MaxValue);

            try
            {
               

                base.ToString();
                sb.AppendLine($"Pileta en la que nada: {this.Pileta}");
                sb.AppendLine($"Estilo preferido de nado: {this.EstiloPreferido}");
            }
            catch (Exception)
            {
                throw;
            }

            return sb.ToString();
        }

        public EPileta Pileta
        {
            get
            {
                return this.tipoPileta;
            }
        }

        public override EEstilos EstiloPreferido
        {
            get
            {
                return this.estiloPreferido;
            }
        }

        public override string ToString()
        {
            return Mostrar();
        }

        public string MostrarNadadorx(Nadador nadadorx)
        {
            return nadadorx.Mostrar();
        }


    }
}
