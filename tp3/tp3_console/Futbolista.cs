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
        private PrintearFutbolista printearSocix;

        public Futbolista(int dni, string nombre, string apellido, EGenero genero, int edad, ECuota cuota, ETipoSocix tipoSocix, int medallas, int partidosJugados, int posicion,string fechaAsociacion, string fechaAptaFisica)
        :base(dni,nombre,apellido,genero,edad,cuota,tipoSocix,medallas, fechaAsociacion, fechaAptaFisica)
        {           
            this.partidosJugados = partidosJugados;

            if (edad >= 16 && edad <=18)
            {
                this.categoria = ECategoria.Juvenil; 
            }
            else if (edad == 14 || edad == 15)
            {
                this.categoria = ECategoria.Cadete;
            }
            else if (edad == 12 || edad == 13)
            {
                this.categoria = ECategoria.Infantil;
            }
            else if (edad == 10 || edad == 11)
            {
                this.categoria = ECategoria.Alevin;
            }
            else if (edad == 8 || edad == 9)
            {
                this.categoria = ECategoria.Benjamin;
            }
            else if (edad >= 5 && edad <= 7)
            {
                this.categoria = ECategoria.PreBenjamin;
            }
            else if (this.TipoSocix == ETipoSocix.Competitivo && (edad < 5 || edad > 18))
            {
                throw new EdadNoAdmitidaException("La edad mínima para jugar en competitivo es de 5 años y la máxima 18.");
            }
            else
            {
                this.categoria = ECategoria.Amateur;
            }

            this.posicion = posicion;
            
        }

        public override int PartidosJugados
        {
            get
            {
                return this.partidosJugados;
            }
        }

        public override ECategoria Categoria
        {
            get
            {
                return this.categoria;
            }
        }

        public override int Posicion
        {
            get
            {
                return this.posicion;
            }
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            base.ToString();
            sb.AppendLine($"Categoría: {this.Categoria}");
            sb.AppendLine($"Posición de juego: {this.Posicion}");
            sb.AppendLine($"Cantidad de partidos jugados: {this.PartidosJugados}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }



    }
}
