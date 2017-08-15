using Tcc.Core.BusinessRulesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Tcc.Exceptions;
using Tcc.Core.Providers;
using System.Runtime.CompilerServices;
using Tcc.Core.BusinessEntities;

namespace Tcc.Core.BusinessRules
{
    public class CoreBusinessRules : ICoreBusinessRules
    {

        #region Constructor 

        public CoreProviderBase SqlCoreProvider { get; set; }


        public CoreBusinessRules(CoreProviderBase sqlCoreProvider)
        {
            SqlCoreProvider = sqlCoreProvider;
        }

        #endregion

        #region BodyPart

        public IList<BodyPart> GetBodyParts()
        {
            return SqlCoreProvider.GetBodyParts();
        }
        #endregion

        #region Category

        public IList<Category> GetCategories()
        {
            return SqlCoreProvider.GetCategories();
        }

        #endregion

        #region ClassificationType

        public IList<ClassificationType> GetClassificationTypes()
        {
            return SqlCoreProvider.GetClassificationTypes();
        }

        #endregion

        #region Level

        public IList<Level> GetLevels()
        {
            return SqlCoreProvider.GetLevels();
        }

        #endregion

        #region PhoneNumberType

        public IList<PhoneNumberType> GetPhoneNumberTypes()
        {
            return SqlCoreProvider.GetPhoneNumberTypes();
        }

        #endregion

        #region PhoneProvider

        public IList<PhoneProvider> GetPhoneProviders()
        {
            return SqlCoreProvider.GetPhoneProviders();
        }

        #endregion

    }
}
