using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;
using Excepciones;

namespace Entidades
{
    public class Club
    {
        private List<Socix> listaDeSocixs;
        protected string razonSocial;

        public Club()
        {
            this.listaDeSocixs = new List<Socix>();
        }

        public Club(string nombreClub)
        :this()
        {
            this.razonSocial = nombreClub;
        }
        public string RazonSocial
        {
            get
            {
                return this.razonSocial;
            }

        }

        public List<Socix> ListaSocixs
        {
            get
            {
                return this.listaDeSocixs;
            }
            set
            {
                this.listaDeSocixs = value;
            }
        }


        public int TotalMedallasGanadasNatacion
        {
            get
            {
                return this.CalcularTotalMedallasNatacion();
            }
        }

        public int TotalMedallasGanadas
        {
            get
            {
                return this.CalcularTotalMedallas();
            }
        }

        public int TotalMedallasGanadasFutbolistas
        {
            get
            {
                return this.CalcularTotalMedallasFutbol();
            }
        }

        public int TotalMedallasGanadasPugilistas
        {
            get
            {
                return this.CalcularTotalMedallasBox();
            }
        }

        public int CalcularTotalMedallas()
        {
            int totalMedallas = 0;

            foreach (Socix socix in this.listaDeSocixs)
            {
                totalMedallas += socix.CantidadMedallas;
            }

            return totalMedallas;
        }

        public int CalcularTotalMedallasNatacion()
        {
            int totalMedallas = 0;

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix is Nadador)
                {
                    totalMedallas += socix.CantidadMedallas;
                }
                
            }

            return totalMedallas;
        }
        public int CalcularTotalMedallasFutbol()
        {
            int totalMedallas = 0;

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix is Futbolista)
                {
                    totalMedallas += socix.CantidadMedallas;
                }
               
            }

            return totalMedallas;
        }
        public int CalcularTotalMedallasBox()
        {
            int totalMedallas = 0;

            foreach (Socix socix in this.listaDeSocixs)
            {
                if (socix is Pugilista)
                {
                    totalMedallas += socix.CantidadMedallas;
                }
                
            }

            return totalMedallas;
        }

        public static Club operator + (Club miClub, Socix socix )
        {
            try
            {
                if (!new GestorBaseDeDatos().DniExistente(socix.DNI))
                {
                    miClub.ListaSocixs.Add(socix);
                }
            }
            catch (Exception ex)
            {
                throw new DniExistenteException("El dni ingresado es inválido o existente", ex);
            }
          
            
            return miClub;
                      
        }

    }
}
