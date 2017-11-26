using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Common;

namespace Tcc.Gyn.BusinessEntities
{
    public class Gyn: BusinessEntityBase<Gyn>
    {
        public string Name { get; set; }

        public Tcc.Person.BusinessEntities.Person Person { get; set; }

        public Gyn()
        {

        }
    }
}
