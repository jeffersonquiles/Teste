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


        public override int Teste()
        {
            return TccContext.DB.Sql(@"insert into teste values ('Person')").Execute();
        }
    }
}
