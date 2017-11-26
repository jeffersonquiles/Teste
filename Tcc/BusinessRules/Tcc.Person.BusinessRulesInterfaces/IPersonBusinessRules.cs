using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Person.BusinessEntities;

namespace Tcc.Person.BusinessRulesInterfaces
{
    public interface IPersonBusinessRules
    {

        #region Person

        IList<Tcc.Person.BusinessEntities.Person> GetPeople();

        bool SavePerson(Person.BusinessEntities.Person entity);

        bool DeletePerson(Guid UniqueId);


        #endregion

        #region PersonClassification

        IList<PersonClassification> GetPersonClassifications(int PersonId);

        bool SavePersonClassification(PersonClassification entity);

        bool DeletePersonClassification(Guid UniqueId);

        #endregion

        #region PersonLocation

        IList<Tcc.Location.BusinessEntities.Location> GetPersonLocations(int PersonId);

        bool SavePersonLocation(PersonLocation entity);

        bool DeletePersonLocation(Guid UniqueId);

        #endregion

        #region PersonPhoneNumber

        IList<PersonPhoneNumber> GetPersonPhoneNumbers(int PersonId);

        bool SavePersonPhoneNumber(PersonPhoneNumber entity);

        bool DeletePersonPhoneNumber(Guid UniqueId);

        #endregion

        #region UserInfo

        IList<UserInfo> GetUserInfos();

        bool SaveUserInfo(UserInfo entity);

        bool DeleteUserInfo(Guid UniqueId);

        #endregion

        #region Teacher 

        IList<Tcc.Person.BusinessEntities.Person> GetTeachers();


        #endregion

    }
}
