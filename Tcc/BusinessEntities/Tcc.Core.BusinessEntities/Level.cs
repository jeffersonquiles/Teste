using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Common;

namespace Tcc.Core.BusinessEntities
{
    public class Level : BusinessEntityBase<Level>
    {
        public string Name { get; set; }

        public Level()
        {

        }
    }
}
