using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCF = global::System.ServiceModel;
using System.Runtime.Serialization;

namespace Tcc.Framework.Patterns.RequestResponse
{
    [DataContract]
    public abstract class ResponseContractBase
    {
        public ResponseContractBase() { }
    }
}
