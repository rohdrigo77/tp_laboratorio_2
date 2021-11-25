using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Futbolista : Socix
    {

        private int partidosJugados;
        private ECategoria categoria;
        private int posicion;

        public Futbolista()
        : base()
        {
        }
        public Futbolista(int dni, string nombre, string apellido, EGenero genero, int edad, ECuota cuota, ETipoSocix tipoSocix, int medallas, int partidosJugados, int posicion,string fechaAsociacion, string fechaAptaFisica)
        :base(dni,nombre,apellido,genero,edad,cuota,tipoSocix,medallas, fechaAsociacion, fechaAptaFisica)
        {           
            this.partidosJugados = partidosJugados;
            this.posicion = posicion;
            
        }

        public override int PartidosJugados
        {
            set
            {
                this.partidosJugados = value;
            }
            get
            {
                return this.partidosJugados;
            }
        }

        public override ECategoria Categoria
        {
            set
            {
                this.categoria = value;
            }
            get
            {
                return this.categoria;
            }
        }

        public override int Posicion
        {
            set
            {
                if (value == 0)
                {
                    if (this is Futbolista)
                    {
                        throw new PosicionException("Posición inválida. Elija una del 1 al 11."); 
                    }
                    else
                    {
                        this.posicion = value;
                    }
                }
                if (value >= 1 && value <=11)
                {
                    this.posicion = value;
                }
            }
            get
            {
                return this.posicion;
            }
        }

        public override ECuota ValorCuota
        {
            set
            {
                if (this.Edad <= 12)
                {
                    if (value == ECuota.NinixsFutbol)
                    {
                        this.valorCuota = value;
                    }
                }
                else
                {
                    this.valorCuota = ECuota.AdultxsFutbol;
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

            base.Mostrar();
            sb.AppendLine($"Categoría: {this.Categoria}");
            sb.AppendLine($"Posición de juego: {this.Posicion}");
            sb.AppendLine($"Cantidad de partidos jugados: {this.PartidosJugados}");

            return sb.ToString();
        }





    }
}
