using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.Providers;
using Tcc.SQLServer.Providers;

namespace Tcc.SqlServer.Providers
{
    public class PersonSqlProvider : PersonProviderBase
    {
        private TccContext TccContext;

        public PersonSqlProvider(TccContext tccContext)
        {
            TccContext = tccContext;
        }

        #region Person 


        public override IList<Tcc.Person.BusinessEntities.Person> GetPeople()
        {
            return TccContext.Tcc.DB.Sql(@"select * from Person").QueryMany<Tcc.Person.BusinessEntities.Person>();
        }

        public override int UpdatePerson(Person.BusinessEntities.Person entity)
        {
            TccContext.Tcc.DB.Update<Person.BusinessEntities.Person>("Person", entity)
                                                  .AutoMap(x => x.Id)
                                                  .Where(x => x.Id)
                                                  .Execute();
            return entity.Id;
        }

        public override int InsertPerson(Person.BusinessEntities.Person entity)
        {
            return TccContext.Tcc.DB.Insert<Person.BusinessEntities.Person>("Person", entity)
                                            .AutoMap(x => x.Id)
                                            .ExecuteReturnLastId<int>();
        }

        public override int DeletePerson(Guid UniqueId)
        {
            return TccContext.Tcc.DB.Sql(@"update Person set IsDeleted = 0  where UniqueId = @0",UniqueId).Execute();
        }

        #endregion
    }
}
