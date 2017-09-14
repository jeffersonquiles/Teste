using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Common;

namespace Tcc.Core.BusinessEntities
{
    public class Category: BusinessEntityBase<Category>
    {
        public string Name { get; set; }
        public int TY { get; set; }

        public Category()
        {

        }
    }
}
