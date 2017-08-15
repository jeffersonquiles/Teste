using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.Providers;
using Tcc.Location.BusinessEntities;
using Tcc.Location.BusinessRulesInterfaces;

namespace Tcc.Location.BusinessRules
{
    public class LocationBusinessRules : ILocationBusinessRules
    {

        #region Constructor 

        public LocationProviderBase SqlLocationProvider { get; set; }


        public LocationBusinessRules(LocationProviderBase sqlLocationProvider)
        {
            SqlLocationProvider = sqlLocationProvider;
        }

        #endregion

        #region StateProvince

        public IList<StateProvince> GetStateProvinces()
        {
            return SqlLocationProvider.GetStateProvinces();
        }

        #endregion

        #region City

        public IList<City> GetCitiesByStateProvinceId(int StateProvinceId)
        {
            return SqlLocationProvider.GetCitiesByStateProvinceId(StateProvinceId);
        }

        #endregion

        #region LocationType

        public IList<LocationType> GetLocationTypes()
        {
            return SqlLocationProvider.GetLocationTypes();
        }

        #endregion

        #region Contry

        public IList<Country> GetCountries()
        {
            return SqlLocationProvider.GetCountries();
        }

        #endregion

        #region Location 

        public IList<Tcc.Location.BusinessEntities.Location> GetLocations(int PersonId)
        {
            return SqlLocationProvider.GetLocations(PersonId);
        }

        public bool DeleteLocations(Guid UniqueId)
        {
            return SqlLocationProvider.DeleteLocation(UniqueId);
        }

        public int SaveLocation(Tcc.Location.BusinessEntities.Location entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateByPersonId = 1;
            entity.IsDeleted = false;

            if (entity.Id > 0)
            {
                SqlLocationProvider.UpdateLocation(entity);
            }
            else
            {
                entity.CreateDate = entity.UpdateDate;
                entity.CreateByPersonId = entity.UpdateByPersonId;
                entity.UniqueId = Guid.NewGuid();
                entity.Id = SqlLocationProvider.InsertLocation(entity);

            }
            return entity.Id;
        }

        #endregion
    }
}