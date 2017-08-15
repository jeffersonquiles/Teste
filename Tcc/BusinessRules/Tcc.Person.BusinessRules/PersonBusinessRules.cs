using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.Providers;
using Tcc.Location.BusinessRules;
using Tcc.Person.BusinessEntities;
using Tcc.Person.BusinessRulesInterfaces;

namespace Tcc.Person.BusinessRules
{
    public class PersonBusinessRules : IPersonBusinessRules
    {

        #region Constructor 

        public PersonProviderBase SqlPersonProvider { get; set; }
        public LocationBusinessRules LocationBusinessRules { get; set; }

        public PersonBusinessRules(PersonProviderBase sqlPersonProvider, LocationBusinessRules locationBusinessRules)
        {
            SqlPersonProvider = sqlPersonProvider;
            LocationBusinessRules = locationBusinessRules;
        }

        #endregion

        #region Person

        public IList<Tcc.Person.BusinessEntities.Person> GetPeoples()
        {
            return SqlPersonProvider.GetPeoples();
        }

        public bool SavePerson(Person.BusinessEntities.Person entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateByPersonId = 1;
            entity.IsDeleted = false;

            if (entity.Id > 0)
            {
                SqlPersonProvider.UpdatePerson(entity);
            }
            else
            {
                entity.CreateDate = entity.UpdateDate;
                entity.CreateByPersonId = entity.UpdateByPersonId;
                entity.UniqueId = Guid.NewGuid();
                SqlPersonProvider.InsertPerson(entity);

            }
            return true;

        }

        public bool DeletePerson(Guid UniqueId)
        {
            return SqlPersonProvider.DeletePerson(UniqueId);
        }


        #endregion

        #region PersonClassification

        public IList<PersonClassification> GetPersonClassifications(int PersonId)
        {
            return SqlPersonProvider.GetPersonClassifications(PersonId);
        }

        public bool SavePersonClassification(PersonClassification entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateByPersonId = 1;
            entity.IsDeleted = false;

            if (entity.Id > 0)
            {
                SqlPersonProvider.UpdatePersonClassification(entity);
            }
            else
            {
                entity.CreateDate = entity.UpdateDate;
                entity.CreateByPersonId = entity.UpdateByPersonId;
                entity.UniqueId = Guid.NewGuid();
                SqlPersonProvider.InsertPersonClassification(entity);

            }
            return true;

        }

        public bool DeletePersonClassification(Guid UniqueId)
        {
            return SqlPersonProvider.DeletePersonClassification(UniqueId);
        }

        #endregion

        #region PersonLocation

        public IList<Tcc.Location.BusinessEntities.Location> GetPersonLocations(int PersonId)
        {
            return LocationBusinessRules.GetLocations(PersonId);
        }

        public bool SavePersonLocation(PersonLocation entity)
        {
           
            if (entity.LocationId > 0 && entity.PersonId > 0)
            {
                LocationBusinessRules.SaveLocation(entity.Location);
            }
            else
            {
                entity.LocationId = LocationBusinessRules.SaveLocation(entity.Location);
                SqlPersonProvider.InsertPersonLocation(entity);

            }
            return true;
        }

        public bool DeletePersonLocation(Guid UniqueId)
        {
            return LocationBusinessRules.DeleteLocations(UniqueId);
        }

        #endregion

        #region PersonPhoneNumber

        public IList<PersonPhoneNumber> GetPersonPhoneNumbers(int PersonId)
        {
            return SqlPersonProvider.GetPersonPhoneNumbers(PersonId);
        }

        public bool SavePersonPhoneNumber(PersonPhoneNumber entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateByPersonId = 1;
            entity.IsDeleted = false;

            if (entity.Id > 0)
            {
                SqlPersonProvider.UpdatePersonPhoneNumber(entity);
            }
            else
            {
                entity.CreateDate = entity.UpdateDate;
                entity.CreateByPersonId = entity.UpdateByPersonId;
                entity.UniqueId = Guid.NewGuid();
                SqlPersonProvider.InsertPersonPhoneNumber(entity);

            }
            return true;
        }

        public bool DeletePersonPhoneNumber(Guid UniqueId)
        {
            return SqlPersonProvider.DeletePersonPhoneNumber(UniqueId);
        }

        #endregion

        #region UserInfo

        public IList<UserInfo> GetUserInfos()
        {
            return SqlPersonProvider.GetUserInfos(PersonId);
        }

        public bool SaveUserInfo(UserInfo entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateByPersonId = 1;
            entity.IsDeleted = false;

            if (entity.Id > 0)
            {
                SqlPersonProvider.UpdateUserInfo(entity);
            }
            else
            {
                entity.CreateDate = entity.UpdateDate;
                entity.CreateByPersonId = entity.UpdateByPersonId;
                entity.UniqueId = Guid.NewGuid();
                SqlPersonProvider.InsertUserInfo(entity);

            }
            return true;
        }

        public bool DeleteUserInfo(Guid UniqueId)
        {
            return SqlPersonProvider.DeleteUserInfo(UniqueId);
        }

        #endregion
    }
}
