using System.Collections.Generic;

namespace ContactAPI.Models.Response
{
    public class GetContactResponse : BaseResponse
    {
        public List<ContactDetails> Contacts { get; set; }
    }

    public class ContactDetails
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
