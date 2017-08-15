using Tcc.Location.BusinessRulesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tcc.Common;
using Tcc.Location.BusinessEntities;

namespace Tcc.Web.Host.Controllers
{
    public class LocationController : ApiControllerBase
    {
        #region Constructor 

        private ILocationBusinessRules LocationBusinessRules { get; set; }

        public LocationController(ILocationBusinessRules locationBusinessRules)
        {
            LocationBusinessRules = locationBusinessRules;
        }

        #endregion

        #region StateProvince

        [HttpPost]
        public IHttpActionResult GetStateProvinces()
        {
            return ApiResult<IList<StateProvince>>(() =>
            {
                return LocationBusinessRules.GetStateProvinces();
            });
        }

        #endregion

        #region City

        [HttpPost]
        public IHttpActionResult GetCitiesByStateProvinceId([FromBody] int StateProvinceId)
        {
            return ApiResult<IList<City>>(() =>
            {
                return LocationBusinessRules.GetCitiesByStateProvinceId(StateProvinceId);
            });
        }

        #endregion

        #region LocationType

        [HttpPost]
        public IHttpActionResult GetLocationTypes()
        {
            return ApiResult<IList<LocationType>>(() =>
            {
                return LocationBusinessRules.GetLocationTypes();
            });
        }

        #endregion

        #region Contry

        [HttpPost]
        public IHttpActionResult GetCountries()
        {
            return ApiResult<IList<Country>>(() =>
            {
                return LocationBusinessRules.GetCountries();
            });
        }

        #endregion

    }
}