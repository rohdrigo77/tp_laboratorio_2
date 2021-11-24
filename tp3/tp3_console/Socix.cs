using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Excepciones;

namespace Entidades
{
    public abstract class Socix
    {
        private int dni;
        private string nombre;
        private string apellido;
        private EGenero genero;
        private int edad;
        private ECuota valorCuota;
        private ETipoSocix tipoSocix;
        private int cantidadMedallas;
        private string fechaDeAsociacion;
        private string fechaUltimaAptaFisica;
        public Socix(int dni, string nombre, string apellido, EGenero genero, int edad, ECuota valorCuota, ETipoSocix tipoSocix, int cantidadMedallas, string fechaAptaFisica, string fechaAsociacion)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.genero = genero;
            this.valorCuota = valorCuota;
            this.tipoSocix = tipoSocix;
            this.cantidadMedallas = cantidadMedallas;
            this.fechaUltimaAptaFisica = fechaAptaFisica;
            this.fechaDeAsociacion = fechaAsociacion;   
            
        }

        public int DNI
        {
            set
            {
                if (!(new GestorBaseDeDatos().DniExistente(value)))
                {
                    this.dni = value;
                }
                else
                {
                    throw new DniExistenteException("El DNI ingresado ya existe. Ingrese otro diferente.");
                }

            }
            get
            {
                return this.dni;
            }
           
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }

        public EGenero Genero
        {
            get
            {
                return this.genero;
            }
        }

        public int Edad
        {
            set
            {
                
                if (value >= 3 && value < 100)
                {
                    this.edad = value;
                }
                else
                {
                    throw new EdadNoAdmitidaException("Edad no admitida. Ingrese una edad de 3 a 100.");
                }

            }
            get 
            {
                return this.edad;
            }

        }

        public ECuota ValorCuota 
        { 
            set
            {
                if(value >= 0)
                {
                    this.valorCuota = value;
                }
                else
                {
                    throw new MenorQueCeroException("El valor ingresado no es válido. Ingrese un número mayor o igual a 0");
                }
            }
            get
            {
                return this.valorCuota;
            }
        }

        public int CantidadMedallas
        {
            set
            {
                if (value >= 0)
                {
                    this.cantidadMedallas = value;
                }
                else
                {
                    throw new MenorQueCeroException("El valor ingresado no es válido. Ingrese un número mayor o igual a 0");
                }
            }
            get
            {
                return this.cantidadMedallas;
            }
        }

        public virtual int Posicion { get; }

        public virtual int PartidosJugados { get; }

        public virtual ECategoria Categoria { get; }
        public virtual EPileta TipoPileta { get; }
        public virtual EEstilos EstiloPreferido { get; }
        public virtual EPeso CategoriaPeso { get; }
        public virtual int CantidadPeleas { get; }

        public ETipoSocix TipoSocix
        {
            get
            {
                return this.tipoSocix;
            }
        }


        public string FechaDeAsociacion
        {
            get
            {
                return this.fechaDeAsociacion;
            }
        }

        public string FechaDeAptaFisica
        {
            get
            {
                return this.fechaUltimaAptaFisica;
            }
        }

        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"--- Datos soci@ ---");
            sb.AppendLine($"DNI: {this.DNI}");
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");
            sb.AppendLine($"Genero: {this.Genero}");
            sb.AppendLine($"Edad: {this.Edad}");
            sb.AppendLine($"Valor cuota: {this.ValorCuota}");
            sb.AppendLine($"Cantidad de medallas: {this.CantidadMedallas}");
            sb.AppendLine($"Tipo de socix: {this.TipoSocix}");
            sb.AppendLine($"Fecha de última apta física presentada: {this.FechaDeAptaFisica}");
            sb.AppendLine($"Socix desde: {this.FechaDeAsociacion}");


            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();         
        }



        public static bool operator == (Socix s1, Socix s2)
        {
            return s1.Equals(s2) && (new GestorBaseDeDatos().DniExistente(s1.DNI));
        }

        public static bool operator !=(Socix s1, Socix s2)
        {
            return !(s1 == s2);
        }

    }
}
