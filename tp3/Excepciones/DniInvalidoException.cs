using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException(string mensaje)
        :base(mensaje)
        {
        }

        public DniInvalidoException(string mensaje, Exception innerException)
       : base(mensaje,innerException)
        {
        }
    }
}
