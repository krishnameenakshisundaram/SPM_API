using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;
using SPM_API.Models;
using SPM_API.Options;

namespace SPM_API.Services
{
    public class CosmosService : ICosmosService
    {
        private readonly CosmosClient _client;

        public CosmosCredentials? Credentials { get; }

        private Container container
        {
            get => _client.GetDatabase("SPMSampleDb").GetContainer("SPMContainer");
        }

        public CosmosService(IOptions<CosmosCredentials> credentialOptions)
        {
            Credentials = credentialOptions.Value;
            _client = new CosmosClient(accountEndpoint: Credentials.Endpoint!, authKeyOrResourceToken: Credentials.Key!);
        }

        public async Task<IEnumerable<WorkStationConfiguration>> RetrieveAllWorkStationConfigAsync()
        {
            var queryable = container.GetItemLinqQueryable<WorkStationConfiguration>();

            using FeedIterator<WorkStationConfiguration> feed = queryable.OrderByDescending(ws => ws.WorkStationCode).ToFeedIterator();
            List<WorkStationConfiguration> results = new();

            while (feed.HasMoreResults)
            {
                var response = await feed.ReadNextAsync();
                foreach (WorkStationConfiguration item in response)
                {
                    results.Add(item);
                }
            }
            return results;
        }
    }
}
