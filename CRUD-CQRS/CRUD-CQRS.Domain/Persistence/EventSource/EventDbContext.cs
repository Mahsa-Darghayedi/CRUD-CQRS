using EventStore.ClientAPI;
using System.Net;

namespace CRUD.CQRS.Domain.Persistence.EventSource
{
    public class EventDbContext : IEventDbContext
    {
        public async Task AppendToStreamAsync(params EventData[] events)
        {
            const string appName = nameof(CRUD.CQRS);
            IEventStoreConnection connection = await GetConnection();
            await connection.AppendToStreamAsync(appName, ExpectedVersion.Any, events);
        }

        public async Task<IEventStoreConnection> GetConnection()
        {
            IEventStoreConnection connection = EventStoreConnection.Create(
              new IPEndPoint(IPAddress.Loopback, 1113),
              nameof(CRUD.CQRS));

            await connection.ConnectAsync();
            return connection;
        }
    }
}
