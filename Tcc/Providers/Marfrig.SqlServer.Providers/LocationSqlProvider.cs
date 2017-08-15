using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.Providers;
using Tcc.Location.BusinessEntities;
using Tcc.SQLServer.Providers;

namespace Tcc.SqlServer.Providers
{
    public class LocationSqlProvider : LocationProviderBase
    {

        #region Constructor 

        private TccContext TccContext;

        public LocationSqlProvider(TccContext tccContext)
        {
            TccContext = tccContext;
        }

        #endregion


        #region StateProvince

        public override IList<StateProvince> GetStateProvinces()
        {
            return TccContext.Tcc.DB.Sql(@"select * from StateProvince").QueryMany<StateProvince>();

        }

        #endregion

        #region City

        public override IList<City> GetCitiesByStateProvinceId(int StateProvinceId)
        {
            return TccContext.Tcc.DB.Sql(@"select * from City where StateProvinceId = @0", StateProvinceId).QueryMany<City>();
        }

        #endregion

        #region LocationType

        public override IList<LocationType> GetLocationTypes()
        {
            return TccContext.Tcc.DB.Sql(@"select * from LocationType").QueryMany<LocationType>();
        }

        #endregion

        #region Contry

        public override IList<Country> GetCountries()
        {
            return TccContext.Tcc.DB.Sql(@"select * from Country").QueryMany<Country>();
        }

        #endregion

        #region Location 

        public override IList<Tcc.Location.BusinessEntities.Location> GetLocations(int PersonId)
        {
            return TccContext.Tcc.DB.Sql(@"select * from Location where PersonId = @0 and IsDeleted = 0", PersonId).QueryMany<Tcc.Location.BusinessEntities.Location>();
        }

        public override bool DeleteLocation(Guid UniqueId)
        {
            TccContext.Tcc.DB.Sql(@"update Location set IsDeleted = 0 and UpdateByPersonId = @1 and UpdateDate = @2").Execute();
            return true;
        }

        public override int InsertLocation(Tcc.Location.BusinessEntities.Location entity)
        {
            return TccContext.Tcc.DB.Insert<Tcc.Location.BusinessEntities.Location>("Location", entity)
                                             .AutoMap(x => x.Id)
                                             .ExecuteReturnLastId<int>();
        }

        public override int UpdateLocation(Tcc.Location.BusinessEntities.Location entity)
        {
            return TccContext.Tcc.DB.Update<Tcc.Location.BusinessEntities.Location>("Location", entity)
                                 .AutoMap(x => x.Id)
                                 .Execute();
        }

        #endregion
    }
}
