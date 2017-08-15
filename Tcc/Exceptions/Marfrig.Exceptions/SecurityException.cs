using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Exceptions
{
    public class SecurityException: Exception
    {
        /// Construtor da exceção.
        /// </summary>
        /// <param name="message">Mensagem da exceção.</param>
        public SecurityException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Construtor padrão da exceção.
        /// </summary>
        public SecurityException()
            : base()
        {
        }
    }
}
