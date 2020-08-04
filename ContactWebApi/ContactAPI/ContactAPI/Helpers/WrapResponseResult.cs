namespace ContactAPI.Helpers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="WrapResponseResult{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WrapResponseResult<T> : IHttpActionResult
    {
        /// <summary>
        /// Defines the _func
        /// </summary>
        private readonly Func<T> _func;

        /// <summary>
        /// Defines the _request
        /// </summary>
        private readonly HttpRequestMessage _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="WrapResponseResult{T}"/> class.
        /// </summary>
        /// <param name="func">The func<see cref="Func{T}"/></param>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        public WrapResponseResult(Func<T> func, HttpRequestMessage request)
        {
            _func = func;
            _request = request;
        }

        /// <summary>
        /// The ExecuteAsync
        /// </summary>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/></param>
        /// <returns>The <see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(CreateResponse(_func, _request));
        }

        /// <summary>
        /// The CreateResponse
        /// </summary>
        /// <param name="func">The func<see cref="Func{T}"/></param>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        /// <returns>The <see cref="HttpResponseMessage"/></returns>
        public HttpResponseMessage CreateResponse(Func<T> func, HttpRequestMessage request)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK, func());
            }
            catch (HttpResponseException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
