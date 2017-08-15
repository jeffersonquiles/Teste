using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Location.BusinessEntities;

namespace Tcc.Core.Providers
{
    public class LocationProviderBase : ProviderBase
    {

        #region StateProvince

        public virtual IList<StateProvince> GetStateProvinces()
        {
            throw new NotImplementedException();

        }

        #endregion

        #region City

        public virtual IList<City> GetCitiesByStateProvinceId(int StateProvinceId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region LocationType

        public virtual IList<LocationType> GetLocationTypes()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Contry

        public virtual IList<Country> GetCountries()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Location 

        public virtual IList<Tcc.Location.BusinessEntities.Location> GetLocations(int PersonId)
        {
            throw new NotImplementedException();
        }

        public virtual bool DeleteLocation(Guid UniqueId)
        {
            throw new NotImplementedException();
        }

        public virtual int InsertLocation(Tcc.Location.BusinessEntities.Location entity)
        {
            throw new NotImplementedException();
        }

        public virtual int UpdateLocation(Tcc.Location.BusinessEntities.Location entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
