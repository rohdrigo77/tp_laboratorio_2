using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class EdadNoAdmitidaException : Exception
    {
        public EdadNoAdmitidaException(string mensaje)
        : base(mensaje)
        {

        }

        public EdadNoAdmitidaException(string mensaje, Exception innerException)
        : base(mensaje, innerException)
        {

        }
    }
}
