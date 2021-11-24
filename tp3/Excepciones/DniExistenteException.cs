using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniExistenteException : Exception
    {
        public DniExistenteException(string mensaje)
        :base(mensaje)
        {
        }

        public DniExistenteException(string mensaje, Exception innerException)
       : base(mensaje,innerException)
        {
        }
    }
}
