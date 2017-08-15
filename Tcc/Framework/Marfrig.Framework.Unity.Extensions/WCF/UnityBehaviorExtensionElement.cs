using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ServiceModel.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;

namespace Tcc.Framework.Unity.Extensions.WCF
{
    /// <summary>
    /// Classe que representa o Behavior de integração do Unity ao WCF
    /// </summary>
    class UnityBehaviorExtensionElement : BehaviorExtensionElement
    {
        private UnityContainer Container { set; get; }

        public UnityBehaviorExtensionElement()
        {
            this.Container = new UnityContainer();
        }

        public override Type BehaviorType
        {
            get 
            {
                return typeof(UnityServiceBehavior); 
            }
        }

        /// <summary>
        /// Popula o Container do Unity com as configurações de dependencia indicadas no arquivo de configuração
        /// </summary>
        /// <returns></returns>
        protected override object CreateBehavior()
        {
            /*Configura o Unity na Criação do Service Behavior
             * para realizar a operação apenas uma vez */

            UnityConfigurationSection config = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            if (config != null)
                config.Containers.Default.Configure(this.Container);

            return new UnityServiceBehavior(this.Container);
        }
    }
}
