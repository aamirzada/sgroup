using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Contracts;

namespace WebApplication1.Interfaces
{
    public interface IMapServerService
    {
        Task<MapServer> GetMapServerInfoAsync();
        Task<List<Layer>> GetLayersListAsync();
        Task<List<Layer>> GetQueryLayersListAsync();
        Task<string> GetMapImageAsync(BoundingBox bbox);


    }
}