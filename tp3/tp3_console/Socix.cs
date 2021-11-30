using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Excepciones;
using System.Text.Json;

namespace Entidades
{
    public abstract class Socix
    {
        private int dni;
        private string nombre;
        private string apellido;
        private EGenero genero;
        private int edad;
        protected ECuota valorCuota;
        private ETipoSocix tipoSocix;
        private int cantidadMedallas;
        private string fechaDeAsociacion;
        private string fechaAptaFisica;
        private bool socixNuevx;

        [JsonConstructor]
        public Socix()
        {
            this.socixNuevx = true;
        }


        /*public Socix(int dni, string nombre, string apellido, EGenero genero, int edad, ECuota valorCuota, ETipoSocix tipoSocix, int cantidadMedallas, string fechaAptaFisica, string fechaAsociacion)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.genero = genero;
            this.valorCuota = valorCuota;
            this.tipoSocix = tipoSocix;
            this.cantidadMedallas = cantidadMedallas;
            this.fechaAptaFisica = fechaAptaFisica;
            this.fechaDeAsociacion = fechaAsociacion;
            
        }*/

        public bool SocixNuevx
        {
            set
            {
                this.socixNuevx = value;
            }
            get
            {
                return this.socixNuevx;
            }

        }

        public int DNI
        {
            set
            {
                if (value <= 99999999)
                {
                    if(!new GestorBaseDeDatos().DniExistente(value) || this.socixNuevx == false)
                    {
                        this.dni = value;
                    }
                    else
                    {           
                         throw new DniInvalidoException("El DNI ingresado ya existe o es invalido. Ingrese otro diferente.");                      
                    }
                                  
                }


            }
            get
            {
                return this.dni;
            }
           
        }
        public string Nombre
        {
            set
            {
                if(int.TryParse(value,out _) || value.Length > 50)
                {
                    throw new NombreApellidoInvalidoException("El nombre ingresado es inválido. Ingrese otro diferente.");
                }
                else
                {
                    this.nombre = value;
                }
            }
            get
            {
                return this.nombre;
            }
        }
        public string Apellido
        {
            set
            {
                if (int.TryParse(value, out _) || value.Length > 50)
                {
                    throw new NombreApellidoInvalidoException("El Apellido ingresado es inválido. Ingrese otro diferente.");
                }
                else
                {
                    this.apellido = value;
                }
            }
            get
            {
                return this.apellido;
            }
        }

        public EGenero Genero
        {
            set
            {
                this.genero = value;
            }
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

        public virtual ECuota ValorCuota {set; get;}

        public int CantidadMedallas
        {
            set
            {
                if (this.tipoSocix == ETipoSocix.Competitivo && value >= 0)
                {
                    this.cantidadMedallas = value;
                }
                else
                {
                    if (value == 0)
                    {
                        this.cantidadMedallas = value;
                    }
                    else
                    {
                        throw new MenorQueCeroException("El valor ingresado no es válido o socix no compite. Ingrese un número mayor o igual a 0, o haga competir al socix.");
                    }
                        
                }
            }
            get
            {
                return this.cantidadMedallas;
            }
        }
        /*
        public virtual int Posicion { set; get; }
        public virtual int PartidosJugados { set;  get; }
        public virtual ECategoria Categoria { set; get; }
        public virtual EPileta TipoPileta { set; get; }
        public virtual EEstilos EstiloPreferido { set; get; }
        public virtual EPeso CategoriaPeso { set;  get; }
        public virtual int CantidadPeleas { set;  get; }
        */
        public ETipoSocix TipoSocix
        {
            set
            {
                this.tipoSocix = value;
            }
            get
            {
                return this.tipoSocix;
            }
        }


        public string FechaDeAsociacion
        {
            set
            {
                this.fechaDeAsociacion = value;
            }
            get
            {
                return this.fechaDeAsociacion;
            }
        }

        public string FechaAptaFisica
        {
            set
            {
                this.fechaAptaFisica = value;
            }
            get
            {
                return this.fechaAptaFisica;
            }
        }

        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"--- Datos socix ---");
            sb.AppendLine($"DNI: {this.DNI}");
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");
            sb.AppendLine($"Genero: {this.Genero}");
            sb.AppendLine($"Edad: {this.Edad}");
            sb.AppendLine($"Valor cuota: {this.ValorCuota}");
            sb.AppendLine($"Cantidad de medallas: {this.CantidadMedallas}");
            sb.AppendLine($"Tipo de socix: {this.TipoSocix}");
            sb.AppendLine($"Fecha de última apta física presentada: {this.FechaAptaFisica}");
            sb.AppendLine($"Socix desde: {this.FechaDeAsociacion}");


            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();         
        }



    }
}
