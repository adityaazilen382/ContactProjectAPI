using ContactAPI.Business;
using ContactAPI.Common.Helper;
using ContactAPI.Helpers;
using ContactAPI.Models.Request;
using ContactAPI.Models.Response;
using System.Web.Http;

namespace ContactAPI.Controllers
{
    [RoutePrefix("contact")]

    public class ContactController : ApiController
    {
        #region Variable Declaration
        #endregion

        private IContactServices _contactService;
        public ContactController(IContactServices contactService)
        {
            _contactService = contactService;
        }

        [Route("hello")]
        [HttpGet]
        public string hello()
        {
            return "API is working.";
        }

        [Route("Add")]
        [HttpPost]
        public WrapResponseResult<ResponseWrapper<BaseContactResponse>> Add(AddContactRequest request)
        {
            return new WrapResponseResult<ResponseWrapper<BaseContactResponse>>(() =>
            {
                if (request != null && ModelState.IsValid)
                {
                    ResponseWrapper<BaseContactResponse> response = null;
                    response = _contactService.Add(request);
                    return response;
                }
                else
                {
                    ResponseWrapper<BaseContactResponse> response = null;
                    response = ResponseWrapper<BaseContactResponse>.GetBadRequestErrorResponse();
                    return response;
                }
            }, this.Request);
        }

        [Route("Edit")]
        [HttpPost]
        public WrapResponseResult<ResponseWrapper<BaseContactResponse>> Edit(EditContactRequest request)
        {
            return new WrapResponseResult<ResponseWrapper<BaseContactResponse>>(() =>
              {
                  if (request != null && ModelState.IsValid)
                  {
                      ResponseWrapper<BaseContactResponse> response = null;
                      response = _contactService.Edit(request);
                      return response;
                  }
                  else
                  {
                      ResponseWrapper<BaseContactResponse> response = null;
                      response = ResponseWrapper<BaseContactResponse>.GetBadRequestErrorResponse();
                      return response;
                  }
              }, this.Request);
        }

        [Route("Delete")]
        [HttpPost]
        public WrapResponseResult<ResponseWrapper<BaseResponse>> Delete(BaseRequest request)
        {

            return new WrapResponseResult<ResponseWrapper<BaseResponse>>(() =>
            {
                if (request != null && ModelState.IsValid)
                {
                    ResponseWrapper<BaseResponse> response = null;
                    response = _contactService.Delete(request);
                    return response;
                }
                else
                {
                    ResponseWrapper<BaseResponse> response = null;
                    response = ResponseWrapper<BaseResponse>.GetBadRequestErrorResponse();
                    return response;
                }
            }, this.Request);
        }
        [Route("Get")]
        [HttpGet]
        public WrapResponseResult<ResponseWrapper<GetContactResponse>> Get()
        {
            return new WrapResponseResult<ResponseWrapper<GetContactResponse>>(() =>
            {

                ResponseWrapper<GetContactResponse> response = null;
                response = _contactService.Get();
                return response;

            }, this.Request);
        }
    }
}
