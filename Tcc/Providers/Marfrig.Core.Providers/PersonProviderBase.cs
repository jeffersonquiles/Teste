using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Person.BusinessEntities;

namespace Tcc.Core.Providers
{
    public class PersonProviderBase : ProviderBase
    {

        #region Person

        public virtual IList<Tcc.Person.BusinessEntities.Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public virtual int UpdatePerson(Person.BusinessEntities.Person entity)
        {
            throw new NotImplementedException();
        }

        public virtual int InsertPerson(Person.BusinessEntities.Person entity)
        {
            throw new NotImplementedException();
        }

        public virtual int DeletePerson(Guid UniqueId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PersonClassification

        public virtual IList<PersonClassification> GetPersonClassifications(Int32 PersonId)
        {
            throw new NotImplementedException();
        }

        public virtual int UpdatePersonClassification(PersonClassification entity)
        {
            throw new NotImplementedException();
        }

        public virtual int InsertPersonClassification(PersonClassification entity)
        {
            throw new NotImplementedException();
        }

        public virtual int DeletePersonClassification(Guid UniqueId)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region PersonLocation

        public virtual int InsertPersonLocation(PersonLocation entity)
        {
            throw new NotImplementedException();
        }



        #endregion

        #region PersonPhoneNumber

        public virtual IList<PersonPhoneNumber> GetPersonPhoneNumbers(Int32 PersonId)
        {
            throw new NotImplementedException();
        }

        public virtual int UpdatePersonPhoneNumber(PersonPhoneNumber entity)
        {
            throw new NotImplementedException();
        }

        public virtual int InsertPersonPhoneNumber(PersonPhoneNumber entity)
        {
            throw new NotImplementedException();
        }

        public virtual int DeletePersonPhoneNumber(Guid UniqueId)
        {
            throw new NotImplementedException();
        }




        #endregion

        #region UserInfo

        public virtual IList<UserInfo> GetUserInfos()
        {
            throw new NotImplementedException();
        }

        public virtual int UpdateUserInfo(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public virtual int InsertUserInfo(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public virtual int DeleteUserInfo(Guid UniqueId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Teacher 

        public virtual IList<Tcc.Person.BusinessEntities.Person> GetTeachers()
        {
            throw new NotImplementedException();
        }



        #endregion

    }
}
