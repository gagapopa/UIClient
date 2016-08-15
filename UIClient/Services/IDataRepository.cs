using System.Threading.Tasks;

namespace UIClient.Services
{
    public interface IDataRepository
    {
        Task<string> GetUserLinks(string userGuid);
        Task<string> InsertLinkOrCreateUser(string fullLink, int? userId);
    }
}