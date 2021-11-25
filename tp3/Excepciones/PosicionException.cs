using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{ 
    public class PosicionException : Exception
    {
        public PosicionException(string mensaje)
        : base(mensaje)
        {
        }

        public PosicionException(string mensaje, Exception innerException)
       : base(mensaje, innerException)
        {
        }
    }
}
