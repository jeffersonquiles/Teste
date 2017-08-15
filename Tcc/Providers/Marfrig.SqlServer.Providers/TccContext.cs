
using FluentData;
using System.Configuration;
using System.Linq;
using System.Text;
using Tcc.SqlServer.Providers;

namespace Tcc.SQLServer.Providers
{
    public class TccContext
    {

        #region DB Context

        public IDbContext DB;
        public TccContext()
            : base()
        {
            this.DB = new DbContext().ConnectionString(ConfigurationManager.ConnectionStrings["Teste"].ConnectionString, new SqlServerProvider());
            this.DB.IgnoreIfAutoMapFails(true);
            this.DB.CommandTimeout(120);
        }

        private static TccContext _Tcc;

        public static TccContext Tcc
        {
            get
            {
                //if (_GClaims == null)
                //{
                _Tcc = new TccContext();
                //}
                return _Tcc;
            }
        }
    }
}

        #endregion