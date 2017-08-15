using WCF = global::System.ServiceModel;
using System.Runtime.Serialization;

namespace Tcc.Framework.Patterns.RequestResponse
{
    [DataContract]
    public abstract class RequestContractBase
    {
        public RequestContractBase()
        {
            this.Credentials = new Credentials();
            this.Credentials.RequesterSystem = new RequesterSystem();
            this.Credentials.RequesterUser = new RequesterUser();
        }

        [WCF::MessageBodyMember(Name = "MessageVersion")]
        public virtual MessageVersion MessageVersion { get; set; }

        [DataMember]
        [WCF::MessageBodyMember(Name = "Credentials")]        
        public virtual Credentials Credentials { get; set; }
    }


    public class MessageVersion
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }
    }

    [DataContract]
    public class Credentials
    {
        [DataMember]
        [WCF::MessageBodyMember(Name = "RequesterSystem")]
        public RequesterSystem RequesterSystem { get; set; }
        [DataMember]
        [WCF::MessageBodyMember(Name = "RequesterUser")]
        public RequesterUser RequesterUser { get; set; }
        [DataMember]
        [WCF::MessageBodyMember(Name = "RequesterIP")]
        public string RequesterIP { get; set; }
        [DataMember]
        [WCF::MessageBodyMember(Name = "AuthToken")]
        public System.Guid AuthToken { get; set; }
    }

    [DataContract]
    public class RequesterSystem
    {
        [DataMember]
        [WCF::MessageBodyMember(Name = "Id")]
        public virtual string Id { get; set; }
    }

    [DataContract]
    public class RequesterUser
    {
        [DataMember]
        [WCF::MessageBodyMember(Name = "Id")]
        public virtual int Id { get; set; }
    }
}
