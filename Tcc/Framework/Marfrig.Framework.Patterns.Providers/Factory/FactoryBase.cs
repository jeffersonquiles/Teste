using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Configuration.Provider;
using Tcc.Framework.Patterns.Providers.SectionHandler;

namespace Tcc.Framework.Patterns.Providers.Factory
{
    public class FactoryBase<T>
    {
        private readonly T provider;
        private readonly ProviderCollection providers;
        private System.Collections.Specialized.StringCollection providersNames;
        private static System.Collections.Generic.Dictionary<string, FactoryBase<T>> factoryDic = new System.Collections.Generic.Dictionary<string, FactoryBase<T>>();
        private static System.Collections.Specialized.StringCollection sectionNames = new System.Collections.Specialized.StringCollection();
        

        private FactoryBase(string sectionName)
        {
            ProviderSectionHandler section = (ProviderSectionHandler)System.Configuration.ConfigurationManager.GetSection(sectionName);

            providers = new ProviderCollection();
            ProvidersHelper.InstantiateProviders(
                section.Providers,
                providers,
                typeof(T));

            string defaultProvider = section.DefaultProvider.Trim();

            if (!string.IsNullOrEmpty(defaultProvider))
                provider = ((T)(object)providers[defaultProvider]);
            else
                throw new Exception("Provider padrão não definido.");
        }

        public static FactoryBase<T> GetInstance( string sectionName )
        {
            //if (factoryDic.Count == 0 || !factoryDic.Keys.Contains(sectionName))
            //{
            //    factoryDic.Add(sectionName, new FactoryBase<T>(sectionName));
            //}

            //return factoryDic[sectionName]; 

            return new FactoryBase<T>(sectionName);
        }
     

        public T DefaultProvider
        {
            get
            {
                return provider;
            }
        }

        public ProviderCollection AvailableProviders
        {
            get
            {
                return providers;
            }
        }

        public T GetProvider(string providerName)
        {
            foreach (ProviderBase p in AvailableProviders)
            {
                if (p.Name == providerName)
                    return ((T)(object)p);
            }

            return default(T);
        }

        public  System.Collections.Specialized.StringCollection ProvidersNames
        {
            get
            {
                if (providersNames == null)
                {
                    providersNames = new System.Collections.Specialized.StringCollection();

                    foreach (ProviderBase p in AvailableProviders)
                        providersNames.Add(p.Name);
                }

                return providersNames;
            }
        }
    }
}
