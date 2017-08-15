using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tcc.Framework.Patterns.RequestResponse
{
    public abstract class FaultBase
    {   
        public virtual string Message { get; set; }
        
        public virtual string Source { get; set; }
    }
}
