using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NombreApellidoInvalidoException : Exception
    {

        public NombreApellidoInvalidoException (string mensaje)
        : base(mensaje)
        {

        }

        public NombreApellidoInvalidoException(string mensaje, Exception innerException)
        : base(mensaje,innerException)
        {

        }
    }
}
