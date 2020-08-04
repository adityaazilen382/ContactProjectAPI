namespace ContactAPI.DAL.Concrete
{
    using Interface;
    using Models.Entities;
    public class ContactDAL : GenericRepository<ContactDetails>, IContactDAL
    {
    }
}
