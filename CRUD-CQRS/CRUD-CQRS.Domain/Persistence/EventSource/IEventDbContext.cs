using EventStore.ClientAPI;

namespace CRUD.CQRS.Domain.Persistence.EventSource
{
    public interface IEventDbContext
    {
        Task<IEventStoreConnection> GetConnection();

        Task AppendToStreamAsync(params EventData[] events);
    }
}
