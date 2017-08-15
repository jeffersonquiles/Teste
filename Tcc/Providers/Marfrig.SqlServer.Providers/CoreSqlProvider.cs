using Tcc.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.SQLServer.Providers;
using Tcc.Core.BusinessEntities;

namespace Tcc.SqlServer.Providers
{
    public class CoreSqlProvider : CoreProviderBase
    {

        #region Constructor 

        private TccContext TccContext;

        public CoreSqlProvider(TccContext tccContext)
        {
            TccContext = tccContext;
        }

        #endregion

        #region BodyPart

        public override IList<BodyPart> GetBodyParts()
        {
            return TccContext.Tcc.DB.Sql(@"select * from BodyPart").QueryMany<BodyPart>();
        }

        #endregion

        #region Category

        public override IList<Category> GetCategories()
        {
            return TccContext.Tcc.DB.Sql(@"select * from Category").QueryMany<Category>();
        }

        #endregion

        #region ClassificationType

        public override IList<ClassificationType> GetClassificationTypes()
        {
            return TccContext.Tcc.DB.Sql(@"select * from ClassificationType").QueryMany<ClassificationType>();
        }

        #endregion

        #region Level

        public override IList<Level> GetLevels()
        {
            return TccContext.Tcc.DB.Sql(@"select * from Level").QueryMany<Level>();
        }

        #endregion

        #region PhoneNumberType

        public override IList<PhoneNumberType> GetPhoneNumberTypes()
        {
            return TccContext.Tcc.DB.Sql(@"select * from PhoneNumberType").QueryMany<PhoneNumberType>();
        }

        #endregion

        #region PhoneProvider

        public override IList<PhoneProvider> GetPhoneProviders()
        {
            return TccContext.Tcc.DB.Sql(@"select * from PhoneProvider").QueryMany<PhoneProvider>();
        }

        #endregion

    }
}