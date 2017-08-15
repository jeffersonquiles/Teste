using Tcc.Framework.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Core.BusinessEntities
{
    public class PhoneProvider : BusinessEntityBase <PhoneProvider>
    {
        public string Name { get; set; }

        public PhoneProvider()
        {
           
        }
    }
}
