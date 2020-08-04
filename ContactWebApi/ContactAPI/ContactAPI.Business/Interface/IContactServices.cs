namespace ContactAPI.Business
{
    using Common.Helper;
    using Models.Request;
    using Models.Response;
    /// <summary>
    /// Defines the <see cref="IContactServices" />
    /// </summary>
    public interface IContactServices
    {
        /// <summary>
        /// Get Contact Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseWrapper<GetContactResponse> Get();
        /// <summary>
        /// Add New Contact
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ResponseWrapper<BaseContactResponse> Add(AddContactRequest request);
        /// <summary>
        /// Update Existing Contact
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ResponseWrapper<BaseContactResponse> Edit(EditContactRequest request);
        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ResponseWrapper<BaseResponse> Delete(BaseRequest request);
    }
}
