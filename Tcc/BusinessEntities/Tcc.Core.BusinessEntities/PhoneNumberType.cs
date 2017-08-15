using Tcc.Framework.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Core.BusinessEntities
{
    public class PhoneNumberType : BusinessEntityBase<PhoneNumberType>
    {
        public string Name { get; set; }

        public PhoneNumberType()
        {

        }
    }
}
