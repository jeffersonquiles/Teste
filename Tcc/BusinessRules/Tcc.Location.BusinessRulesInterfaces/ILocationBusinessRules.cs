using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Location.BusinessEntities;

namespace Tcc.Location.BusinessRulesInterfaces
{
    public interface ILocationBusinessRules
    {

        #region StateProvince

        IList<StateProvince> GetStateProvinces();

        #endregion

        #region City

        IList<City> GetCitiesByStateProvinceId(int StateProvinceId);

        #endregion

        #region LocationType

        IList<LocationType> GetLocationTypes();

        #endregion

        #region Contry

        IList<Country> GetCountries();

        #endregion

        #region Location

        IList<Tcc.Location.BusinessEntities.Location> GetLocations(int PersonId);

        bool DeleteLocations(Guid UniqueId);

        int SaveLocation(Tcc.Location.BusinessEntities.Location entity);

        #endregion
    }
}
