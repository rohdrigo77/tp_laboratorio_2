using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IAtendedor
    {
        Queue<Cliente> FilaClientes
        {
            get; set;
        }

        string NombrePuestoAtencion
        {
            get;
        }

        string AtenderClientes();
    }
}
