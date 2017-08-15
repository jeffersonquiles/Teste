using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;

namespace Tcc.Framework.Unity.Extensions.WCF
{
    /// <summary>
    /// Behavior que vincula o Unity App Block a um Serviço
    /// </summary>
    public class UnityServiceBehavior : IServiceBehavior
    {
        /// <summary>
        /// Propriedade que expõe a classe que instancia o Serviço via Unity App Block
        /// </summary>
        public UnityInstanceProvider InstanceProvider
        { get; set; }

        //private ServiceHost serviceHost = null;

        public UnityServiceBehavior()
        {
            InstanceProvider = new UnityInstanceProvider();
        }

        public UnityServiceBehavior(UnityContainer unity)
        {
            InstanceProvider = new UnityInstanceProvider();

            InstanceProvider.Container = unity;
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher cd = cdb as ChannelDispatcher;
                
                if (cd != null)
                {
                    foreach (EndpointDispatcher ed in cd.Endpoints)
                    {
                        InstanceProvider.ServiceType = serviceDescription.ServiceType;

                        ed.DispatchRuntime.InstanceProvider = InstanceProvider;
                    }
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
    }
}
