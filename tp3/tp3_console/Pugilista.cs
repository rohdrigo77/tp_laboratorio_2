using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pugilista : Socix
    {
        private EPeso categoriaPeso;
        private int cantidadPeleas;

        public Pugilista()
        : base()
        {
        }

        public Pugilista(int dni, string nombre, string apellido, EGenero genero, int edad, ECuota valorCuota, int cantMedallas, EPeso categoria, ETipoSocix tipoSocix, int cantidadPeleas, string fechaAsociacion, string fechaAptaFisica)
        : base(dni, nombre, apellido, genero, edad, valorCuota,tipoSocix,cantMedallas,fechaAptaFisica,fechaAsociacion)
        {
            this.categoriaPeso = categoria;
            this.cantidadPeleas = cantidadPeleas;
        }

        public EPeso CategoriaPeso
        {
            set
            {
                this.categoriaPeso = value;
            }
            get
            {
                return this.categoriaPeso;
            }
        }

        public int CantidadPeleas
        {
            set
            {
                this.cantidadPeleas = value;
            }
            get
            {
                return this.cantidadPeleas;
            }
        }

        public override ECuota ValorCuota
        {
            set
            {
                if (this.Edad <= 12)
                {
                    if (value == ECuota.NinixsBoxeo)
                    {
                        this.valorCuota = value;
                    }
                }
                else
                {
                    this.valorCuota = ECuota.AdultxsBoxeo;
                }
            }
            get
            {
                return this.valorCuota;
            }

        }
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"Categoría en peso: {this.CategoriaPeso}");
            sb.AppendLine($"Cantidad de peleas: {this.CantidadPeleas}");

            return sb.ToString();
        }


    }
}
