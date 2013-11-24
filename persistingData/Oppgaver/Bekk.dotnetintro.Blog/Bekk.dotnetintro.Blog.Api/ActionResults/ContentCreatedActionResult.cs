using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Bekk.dotnetintro.Blog.ActionResults
{
    public class ContentCreatedActionResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly string _location;

        public ContentCreatedActionResult(HttpRequestMessage request, string location)
        {
            _request = request;
            _location = location;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(_location);
            return Task.FromResult(response);
        }
    }
}