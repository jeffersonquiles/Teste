using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Framework.Patterns.Providers.Factory;

namespace Tcc.Common {

    public class RccProviderBase<T> : ProviderBase
    {

        public virtual Int32 GenericInsert<U>(U entity) { throw new NotImplementedException(); }
        public virtual Int32 GenericUpdate<U>(U entity) { throw new NotImplementedException(); }
        public virtual Int32 GenericDelete<U>(U entity) { throw new NotImplementedException(); }

        public delegate object cacheDelegate();

        //public virtual C CacheResponse<C>(string cacheKey, cacheDelegate txCode, ExpirationType expirationType = ExpirationType.Absolute, double expirationTimeInMinutes = 2)
        //{
        //    if (!CachingContext.Current.Contains(cacheKey))
        //    {
        //        var result = (C)txCode();

        //        CachingContext.Current.Add(cacheKey, result, ExpirationType.Absolute, expirationTimeInMinutes);
        //        return result;
        //    }
        //    else
        //    {
        //        C result = (C)CachingContext.Current.GetData(cacheKey);
        //        return result;
        //    }
        //}
        //#endregion

        /// <summary>
        /// Nome do provider
        /// </summary>
        /// 
        private string ProviderName { get; set; }

        public RccProviderBase(String providerName) { ProviderName = providerName; }

        #region Providers

        public enum ProvidersNames
        {
            SqlServer
        }

        public FactoryBase<T> Providers
        {
            get { return FactoryBase<T>.GetInstance(ProviderName); }
        }

        #endregion
    }
}
