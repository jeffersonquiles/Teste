using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.BusinessEntities;

namespace Tcc.Core.BusinessRulesInterfaces
{
    public interface ICoreBusinessRules
    {

        #region BodyPart

        IList<BodyPart> GetBodyParts();

        #endregion

        #region Category

        IList<Category> GetCategories();

        #endregion

        #region ClassificationType

        IList<ClassificationType> GetClassificationTypes();

        #endregion

        #region Level

        IList<Level> GetLevels();

        #endregion

        #region PhoneNumberType

        IList<PhoneNumberType> GetPhoneNumberTypes();

        #endregion

        #region PhoneProvider

        IList<PhoneProvider> GetPhoneProviders();

        #endregion

    }
}
