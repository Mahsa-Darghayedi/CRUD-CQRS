namespace CRUD.CQRS.ApplicationService.Services
{
    public interface ICustomerService
    {
        bool IsEmailUniqe(string email);
    }
}
