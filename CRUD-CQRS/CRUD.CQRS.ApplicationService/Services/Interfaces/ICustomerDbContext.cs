namespace CRUD.CQRS.ApplicationService.Services.Interfaces
{
    public interface ICustomerDbContext
    {
        Task<bool> SaveChangsAsync();
    }
}
