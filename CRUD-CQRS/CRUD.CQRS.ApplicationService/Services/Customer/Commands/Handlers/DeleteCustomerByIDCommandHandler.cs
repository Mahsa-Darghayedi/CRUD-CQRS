using CRUD.CQRS.ApplicationService.Commands;
using CRUD.CQRS.ApplicationService.Common;
using CRUD.CQRS.Domain.Interfaces;
using MediatR;

namespace CRUD.CQRS.ApplicationService.Services.Customer.Commands.Handlers
{
    public class DeleteCustomerByIDCommandHandler : IRequestHandler<DeleteCustomerByIDCommand, string>
    {
        private readonly ICustomerDbContext _context;
        public DeleteCustomerByIDCommandHandler(ICustomerDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteCustomerByIDCommand request, CancellationToken cancellationToken)
        {
            if (request?.Id == 0)
                throw new ArgumentNullException(nameof(request.Id), Statics.InvalidRequest);

            var model = await _context.Customers.FindAsync(request.Id);
            if (model == null)
                throw new Exception(Statics.CustomerNotFound);

            _context.Customers.Remove(model);
            await _context.SaveChangsAsync();
            return Statics.OpersationSuccessful;
        }
    }
}
