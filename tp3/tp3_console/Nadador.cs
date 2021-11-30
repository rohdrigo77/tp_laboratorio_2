using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nadador : Socix
    {
        private EPileta tipoPileta;
        private EEstilos estiloPreferido;

        public Nadador()
        : base()
        {
        }
        /*public Nadador(int dni, string nombre, string apellido, EGenero genero, int edad,ECuota valorCuota, ETipoSocix tipoSocix, int cantMedallas, EPileta pileta, EEstilos estiloPreferido, string fechaAptaFisica, string fechaAsociacion)
        : base(dni, nombre, apellido, genero, edad, valorCuota, tipoSocix, cantMedallas, fechaAptaFisica, fechaAsociacion)
        {
            this.tipoPileta = pileta;
            this.estiloPreferido = estiloPreferido;
            
        }*/

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendLine($"{base.Mostrar()}");
                sb.AppendLine($"Pileta en la que nada: {this.TipoPileta}");
                sb.AppendLine($"Estilo preferido de nado: {this.EstiloPreferido}");
            }
            catch (Exception)
            {
                throw;
            }

            return sb.ToString();
        }

        public EPileta TipoPileta
        {
            set
            {
                this.tipoPileta = value;
            }
            get
            {
                return this.tipoPileta;
            }
        }

        public EEstilos EstiloPreferido
        {
            set
            {
                this.estiloPreferido = value;
            }
            get
            {
                return this.estiloPreferido;
            }
        }

        public override ECuota ValorCuota
        {
            set
            {
                if(this.Edad <= 12)
                {         
                    if (value == ECuota.NinixsNatacion)
                    {
                        this.valorCuota = value;
                    }
                }
                else
                {
                    if (value == ECuota.AdultxsNatacion)
                    {
                        this.valorCuota = value;
                    }
                }
            }
            get
            {
                return this.valorCuota;
            }

        }
    }
}
