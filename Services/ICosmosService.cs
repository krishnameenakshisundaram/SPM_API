using SPM_API.Models;

namespace SPM_API.Services
{
    public interface ICosmosService
    {
        Task<IEnumerable<WorkStationConfiguration>> RetrieveAllWorkStationConfigAsync();
    }
}
