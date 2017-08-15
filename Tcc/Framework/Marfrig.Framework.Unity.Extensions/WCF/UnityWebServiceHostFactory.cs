using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Configuration;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Tcc.Framework.Unity.Extensions.WCF
{
    /// <summary>
    /// Classe responsável por criar Hosts WCF integrados com o Unity App Block
    /// </summary>
    public class UnityWebServiceHostFactory : WebServiceHostFactory
    {
        /// <summary>
        /// Método responsável por instanciar os Hosts
        /// Para utiliza-la a tag Factory no .svc do serviço deve possuir o FullTypeName desta classe
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="baseAddresses"></param>
        /// <returns></returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            //Instancia o Host 
            UnityWebServiceHost serviceHost = new UnityWebServiceHost(serviceType, baseAddresses);

            //Carrega o Container do Unity
            UnityContainer container = new UnityContainer();

            //Indica no Host o container do Unity
            serviceHost.Container = container;

            //Busca seção de configução do Unity
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            //Configura o Container
            section.Containers.Default.Configure(serviceHost.Container);

            return serviceHost;
        }
    }
}
