using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Tcc.Common
{
    internal class ApiResponseResult<T> : IHttpActionResult
    {
        private T response;

        public ApiResponseResult(T response)
        {
            this.response = response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var result = new HttpResponseMessage()
            {
                Content = new ObjectContent(typeof(T), response, new JsonMediaTypeFormatter())
            };
            return Task.FromResult(result);
        }
    }
}