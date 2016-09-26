using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    public interface IMapServerReader
    {
        Task<T> ReadApiAsync<T>(string url) where T: new();
    }
}