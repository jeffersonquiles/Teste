using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Tcc.Framework.Unity.Extensions.WCF
{
    /// <summary>
    /// Classe que cria a instancia do serviço integrada com o Unity App Block
    /// </summary>
    public class UnityInstanceProvider : IInstanceProvider
    {
        /// <summary>
        /// Container de configuração do Unity App Block
        /// </summary>
        public UnityContainer Container { set; get; }

        public Type ServiceType { set; get; }

        public UnityInstanceProvider(): this(null)
        {
        }

        public UnityInstanceProvider(Type type)
        {
            ServiceType = type;

            Container = new UnityContainer();
        }

        #region IInstanceProvider Members

        /// <summary>
        /// Método que realiza a "Dependency Injection" do Unity na criação do serviço
        /// </summary>
        /// <param name="instanceContext"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            if (this.Container != null)
                return this.Container.Resolve(ServiceType);
            else
                return instanceContext;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            
        }

        #endregion
    }
}
