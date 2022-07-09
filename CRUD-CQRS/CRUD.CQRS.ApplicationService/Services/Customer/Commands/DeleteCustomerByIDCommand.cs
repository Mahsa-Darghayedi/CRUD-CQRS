
using MediatR;
namespace CRUD.CQRS.ApplicationService.Commands

{
    public class DeleteCustomerByIDCommand : IRequest<string>
    {
        public int Id { get;  }
        public DeleteCustomerByIDCommand(int id)
        {
            Id = id;    
        }
    }
}
