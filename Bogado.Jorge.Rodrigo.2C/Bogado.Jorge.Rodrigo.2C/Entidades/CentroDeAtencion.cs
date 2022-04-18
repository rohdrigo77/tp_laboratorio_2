using System;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class CentroDeAtencion
    {
        private CancellationTokenSource cancellationTokenSource;
        private string nombre;
        private PuestoNoPrioritario puestoNoPrioritario;
        private PuestoPrioritario puestoPrioritario;
        private Task tarea;
        public event DelegadoCaja InformarPuestoDeAtencion;

        public CentroDeAtencion(string nombre)
        {
            this.nombre = nombre;
        }
        public bool AbrirNegocio
        {
            set 
            { 
            }
            get 
            { 
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public PuestoNoPrioritario PuestoNoPrioritario
        {
            get
            {
                return this.puestoNoPrioritario;
            }
        }

        public PuestoPrioritario PuestoPrioritario
        {
            get { return this.puestoPrioritario; }
        }

        public void IngresarCliente (Cliente cliente)
        {

        }
       
    }
}
