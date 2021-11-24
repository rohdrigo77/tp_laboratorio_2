using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ErrorArchivosException : Exception
    {
        public ErrorArchivosException(string mensaje) : base(mensaje)
        {
        }

        public ErrorArchivosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }

    }
}

