namespace ContactAPI.Business
{
    using AutoMapper;
    using Common;
    using Common.Helper;
    using DAL.Concrete;
    using DAL.Interface;
    using Models.Request;
    using Models.Response;
    using System;
    using System.Collections.Generic;
    using static Common.Constants;

    /// <summary>
    /// Defines the <see cref="ContactServices" />
    /// </summary>
    public class ContactServices : IContactServices
    {
        IContactDAL _contactDAL;
        public ContactServices()
        {
            _contactDAL = new ContactDAL();
        }
        public ResponseWrapper<BaseContactResponse> Add(AddContactRequest request)
        {
            ResponseWrapper<BaseContactResponse> response;
            response = ResponseWrapper<BaseContactResponse>.GetInternalServerErrorResponse();

            try
            {
                object parameters = new
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    Status = request.Status
                };

                string errorCode, errorMessage;
                bool result = false;

                var transaction = _contactDAL.GetByParam(parameters, DBCommands.USP_ContactDetails_Add, out result, out errorMessage, out errorCode);
                if (result == false)
                {
                    response = ResponseWrapper<BaseContactResponse>.GetForbiddenErrorResponse(errorMessage);
                }
                else
                {
                    response = ResponseWrapper<BaseContactResponse>.GetSuccessResponse();
                    response.data = new BaseContactResponse();
                    response.data = Mapper.Map<BaseContactResponse>(transaction);
                }
            }
            catch (Exception ex)
            {
                response = ResponseWrapper<BaseContactResponse>.GetForbiddenErrorResponse(ex.Message);
                LogManager.WriteError("ContactServices:Add" + ex.Message);
            }
            return response;
        }
        public ResponseWrapper<BaseContactResponse> Edit(EditContactRequest request)
        {
            ResponseWrapper<BaseContactResponse> response;
            response = ResponseWrapper<BaseContactResponse>.GetInternalServerErrorResponse();
            try
            {
                object parameters = new
                {
                    ID = request.ID,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email

                };

                string errorCode, errorMessage;
                bool result = false;

                var transaction = _contactDAL.GetByParam(parameters, DBCommands.USP_ContactDetails_Update, out result, out errorMessage, out errorCode);
                if (result == false)
                {
                    response = ResponseWrapper<BaseContactResponse>.GetForbiddenErrorResponse(errorMessage);
                }
                else
                {
                    response = ResponseWrapper<BaseContactResponse>.GetSuccessResponse();
                    response.data = new BaseContactResponse();
                    response.data = Mapper.Map<BaseContactResponse>(transaction);
                }

            }
            catch (Exception ex)
            {
                response = ResponseWrapper<BaseContactResponse>.GetForbiddenErrorResponse(ex.Message);
                LogManager.WriteError("ContactServices:Edit" + ex.Message);
            }
            return response;
        }
        public ResponseWrapper<BaseResponse> Delete(BaseRequest request)
        {
            ResponseWrapper<BaseResponse> response;
            response = ResponseWrapper<BaseResponse>.GetInternalServerErrorResponse();
            try
            {
                object parameters = new
                {
                    ID = request.ID,
                };

                string errorCode, errorMessage;
                bool result = false;

                var transaction = _contactDAL.GetByParam(parameters, DBCommands.USP_ContactDetails_Delete, out result, out errorMessage, out errorCode);
                if (result == false)
                {
                    response = ResponseWrapper<BaseResponse>.GetForbiddenErrorResponse(errorMessage);
                }
                else
                {
                    response = ResponseWrapper<BaseResponse>.GetSuccessResponse();
                }
            }
            catch (Exception ex)
            {
                response = ResponseWrapper<BaseResponse>.GetForbiddenErrorResponse(ex.Message);
                LogManager.WriteError("ContactServices:Delete" + ex.Message);
            }
            return response;
        }


        public ResponseWrapper<GetContactResponse> Get()
        {
            ResponseWrapper<GetContactResponse> response;
            response = ResponseWrapper<GetContactResponse>.GetInternalServerErrorResponse();
            try
            {
                var contacts = _contactDAL.GetAll(null, DBCommands.USP_ContactDetails_GetAll);
                response = ResponseWrapper<GetContactResponse>.GetSuccessResponse();
                response.data = new GetContactResponse();
                response.data.Contacts = new List<ContactDetails>();
                foreach (var contact in contacts)
                {
                    response.data.Contacts.Add(new ContactDetails()
                    {
                        ID = contact.ID,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Email = contact.Email,
                        PhoneNumber = contact.PhoneNumber,
                        Status = contact.Status,
                    });
                }
            }
            catch (Exception ex)
            {
                response = ResponseWrapper<GetContactResponse>.GetForbiddenErrorResponse(ex.Message);
                LogManager.WriteError("ContactServices:Get" + ex.Message);
            }
            return response;
        }
    }
}
