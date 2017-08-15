using Tcc.Framework.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Core.BusinessEntities
{
    public class BodyPart: BusinessEntityBase<BodyPart>
    {
        public string Name { get; set; }

        public BodyPart()
        {

        }
    }
}
