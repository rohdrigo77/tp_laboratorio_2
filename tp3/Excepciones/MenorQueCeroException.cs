using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class MenorQueCeroException :Exception
    {
        public MenorQueCeroException (string mensaje)
        : base(mensaje)
        {

        }

        public MenorQueCeroException(string mensaje, Exception innerException)
        : base(mensaje, innerException)
        {

        }
    }
}
