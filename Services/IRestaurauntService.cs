using System.Threading.Tasks;

namespace dotnetVsNode.Services
{
    public interface IRestaurauntService
    {
        Task<string> GetById(string id);
    }
}