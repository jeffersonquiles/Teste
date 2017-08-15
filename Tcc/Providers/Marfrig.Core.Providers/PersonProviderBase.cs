using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Core.Providers
{
    public class PersonProviderBase : ProviderBase
    {
        public virtual int Teste()
        {
            throw new NotImplementedException();
        }
    }
}
