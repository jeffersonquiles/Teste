using Tcc.Person.BusinessRulesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tcc.Common;
using Tcc.Person.BusinessEntities;

namespace Tcc.Web.Host.Controllers
{
    public class PersonController : ApiControllerBase
    {

        #region Constructor 

        private IPersonBusinessRules PersonBusinessRules { get; set; }

        public PersonController(IPersonBusinessRules personBusinessRules)
        {
            PersonBusinessRules = personBusinessRules;
        }

        #endregion

        #region Person

        [HttpPost]
        public IHttpActionResult GetPeople()
        {
            return ApiResult<IList<Person.BusinessEntities.Person>>(() =>
            {
                return PersonBusinessRules.GetPeople();
            });
        }

        [HttpPost]
        public IHttpActionResult SavePerson(Person.BusinessEntities.Person entity)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.SavePerson(entity);
            });
        }

        [HttpPost]
        public IHttpActionResult DeletePerson([FromBody] Guid UniqueId)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.DeletePerson(UniqueId);
            });
        }

        #endregion

        #region PersonClassification

        [HttpPost]
        public IHttpActionResult GetPersonClassifications([FromBody] int PersonId)
        {
            return ApiResult<IList<Person.BusinessEntities.PersonClassification>>(() =>
            {
                return PersonBusinessRules.GetPersonClassifications(PersonId);
            });
        }

        [HttpPost]
        public IHttpActionResult SavePersonClassification(PersonClassification entity)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.SavePersonClassification(entity);
            });
        }

        [HttpPost]
        public IHttpActionResult DeletePersonClassification([FromBody] Guid UniqueId)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.DeletePersonClassification(UniqueId);
            });
        }

        #endregion

        #region PersonLocation

        [HttpPost]
        public IHttpActionResult GetPersonLocations([FromBody] int PersonId)
        {
            return ApiResult<IList<Tcc.Location.BusinessEntities.Location>>(() =>
            {
                return PersonBusinessRules.GetPersonLocations(PersonId);
            });
        }

        [HttpPost]
        public IHttpActionResult SavePersonLocation(PersonLocation entity)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.SavePersonLocation(entity);
            });
        }

        [HttpPost]
        public IHttpActionResult DeletePersonLocation([FromBody] Guid UniqueId)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.DeletePersonLocation(UniqueId);
            });
        }

        #endregion

        #region PersonPhoneNumber

        [HttpPost]
        public IHttpActionResult GetPersonPhoneNumbers([FromBody] int PersonId)
        {
            return ApiResult<IList<PersonPhoneNumber>>(() =>
            {
                return PersonBusinessRules.GetPersonPhoneNumbers(PersonId);
            });
        }

        [HttpPost]
        public IHttpActionResult SavePersonPhoneNumber(PersonPhoneNumber entity)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.SavePersonPhoneNumber(entity);
            });
        }

        [HttpPost]
        public IHttpActionResult DeletePersonPhoneNumber([FromBody] Guid UniqueId)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.DeletePersonPhoneNumber(UniqueId);
            });
        }

        #endregion

        #region UserInfo

        [HttpPost]
        public IHttpActionResult GetUserInfos()
        {
            return ApiResult<IList<UserInfo>>(() =>
            {
                return PersonBusinessRules.GetUserInfos();
            });
        }

        [HttpPost]
        public IHttpActionResult SaveUserInfo(UserInfo entity)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.SaveUserInfo(entity);
            });
        }

        [HttpPost]
        public IHttpActionResult DeleteUserInfo([FromBody] Guid UniqueId)
        {
            return ApiResult<bool>(() =>
            {
                return PersonBusinessRules.DeleteUserInfo(UniqueId);
            });
        }

        #endregion

        #region Teacher 
        [HttpPost]
        public IHttpActionResult GetTeachers()
        {
            return ApiResult<IList<Tcc.Person.BusinessEntities.Person>>(() =>
            {
                return PersonBusinessRules.GetTeachers();
            });
        }

        #endregion
    }
}