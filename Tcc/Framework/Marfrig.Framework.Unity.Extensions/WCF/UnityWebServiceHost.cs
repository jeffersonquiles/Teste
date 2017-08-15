using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.Practices.Unity;
using System.ServiceModel.Web;


namespace Tcc.Framework.Unity.Extensions.WCF
{
    /// <summary>
    /// Host WCF integrado com o Unity App Block
    /// Nesta Classe são criadas os behaviors do Serviço
    /// Se desejavel é possível incluir o Unity App Block como behavior de um serviço, via Web.config
    /// </summary>
    public class UnityWebServiceHost : WebServiceHost
    {
        /// <summary>
        /// Container do Unity App Block
        /// </summary>
        public UnityContainer Container { set; get; }

        public UnityWebServiceHost(): base()
        {
            Container = new UnityContainer();
        }

        public UnityWebServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            Container = new UnityContainer();
        }

        /// <summary>
        /// Método adiciona o Unity App Block como Behavior do serviço
        /// quando configurado no Web.config
        /// </summary>
        protected override void OnOpening()
        {
            if (this.Description.Behaviors.Find<UnityServiceBehavior>() == null)
                this.Description.Behaviors.Add(new UnityServiceBehavior(Container));

            base.OnOpening();
        }
    }
}
