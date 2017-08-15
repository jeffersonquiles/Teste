using Tcc.Framework.Patterns.Providers.Factory;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Common;
using Tcc.Core.BusinessEntities;

namespace Tcc.Core.Providers
{
    public class CoreProviderBase : ProviderBase 
    {

        #region BodyPart

        public virtual IList<BodyPart> GetBodyParts()
        {
            throw new NotImplementedException(); 
        }

        #endregion

        #region Category

        public virtual IList<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ClassificationType

        public virtual IList<ClassificationType> GetClassificationTypes()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Level

        public virtual IList<Level> GetLevels()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PhoneNumberType

        public virtual IList<PhoneNumberType> GetPhoneNumberTypes()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PhoneProvider

        public virtual IList<PhoneProvider> GetPhoneProviders()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
