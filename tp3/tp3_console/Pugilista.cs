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

        public Pugilista(int dni, string nombre, string apellido, EGenero genero, int edad, ECuota valorCuota, int cantMedallas, EPeso categoria, ETipoSocix tipoSocix, int cantidadPeleas, string fechaAsociacion, string fechaAptaFisica)
        : base(dni, nombre, apellido, genero, edad, valorCuota,tipoSocix,cantMedallas,fechaAptaFisica,fechaAsociacion)
        {
            this.categoriaPeso = categoria;
            this.cantidadPeleas = cantidadPeleas;
        }

        public override EPeso CategoriaPeso
        {
            get
            {
                return this.categoriaPeso;
            }
        }

        public override int CantidadPeleas
        {
            get
            {
                return this.cantidadPeleas;
            }
        }
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            base.ToString();
            sb.AppendLine($"Categoría en peso: {this.CategoriaPeso}");
            sb.AppendLine($"Cantidad de peleas: {this.CantidadPeleas}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }


    }
}
