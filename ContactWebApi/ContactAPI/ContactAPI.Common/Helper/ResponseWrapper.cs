namespace ContactAPI.Common.Helper
{
    using System;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="ResponseWrapper{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseWrapper<T> where T : ContactAPI.Models.Response.BaseResponse
    {
        /// <summary>
        /// Gets or sets the data
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether result
        /// </summary>
        public bool result { get; set; }

        /// <summary>
        /// Gets or sets the errorCode
        /// </summary>
        public int errorCode { get; set; }

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Gets or sets the responseDateTime
        /// </summary>
        public string responseDateTime { get; set; }

        /// <summary>
        /// The GetSuccessResponse
        /// </summary>
        /// <returns>The <see cref="ResponseWrapper{T}"/></returns>
        public static ResponseWrapper<T> GetSuccessResponse()
        {
            return new ResponseWrapper<T>()
            {
                data = default(T),
                result = true,
                responseDateTime = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss.fff") + "Z",
                errorCode = (int)HttpStatusCode.OK,
                message = "Success"
            };
        }

        /// <summary>
        /// The GetInternalServerErrorResponse
        /// </summary>
        /// <returns>The <see cref="ResponseWrapper{T}"/></returns>
        public static ResponseWrapper<T> GetInternalServerErrorResponse()
        {
            return new ResponseWrapper<T>()
            {
                result = false,
                responseDateTime = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss.fff") + "Z",
                errorCode = (int)HttpStatusCode.InternalServerError,
                message = HttpStatusCode.InternalServerError.ToString()
            };
        }

        /// <summary>
        /// The GetForbiddenErrorResponse
        /// </summary>
        /// <returns>The <see cref="ResponseWrapper{T}"/></returns>
        public static ResponseWrapper<T> GetForbiddenErrorResponse(string message, string errorCode = null)
        {
            return new ResponseWrapper<T>()
            {
                result = false,
                responseDateTime = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss.fff") + "Z",
                errorCode = errorCode == null ? (int)HttpStatusCode.Forbidden : Convert.ToInt32(errorCode),
                message = message
            };
        }

        /// <summary>
        /// The GetBadRequestErrorResponse
        /// </summary>
        /// <returns>The <see cref="ResponseWrapper{T}"/></returns>
        //public static ResponseWrapper<T> GetBadRequestErrorResponse(HttpResponse response)
        public static ResponseWrapper<T> GetBadRequestErrorResponse()
        {

            //response.StatusCode = (int)HttpStatusCode.BadRequest;
            //response.StatusDescription = "Invalid Request";

            return new ResponseWrapper<T>()
            {
                result = false,
                responseDateTime = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss.fff") + "Z",
                errorCode = (int)HttpStatusCode.BadRequest,
                message = "Invalid Request"
            };
        }



    }
}
