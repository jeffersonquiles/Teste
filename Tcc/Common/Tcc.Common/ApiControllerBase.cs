using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Tcc.Common
{
    public class ApiControllerBase : ApiController
    {
        protected virtual IHttpActionResult ApiResult<T>(Func<T> fn)
        {
            var response = fn();

            return new ApiResponseResult<T>(response);
        }
    }
}
