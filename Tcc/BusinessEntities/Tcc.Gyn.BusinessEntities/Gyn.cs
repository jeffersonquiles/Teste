using Tcc.Framework.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Gyn.BusinessEntities
{
    public class Gyn: BusinessEntityBase<Gyn>
    {
        public string Name { get; set; }

        public Gyn()
        {

        }
    }
}
