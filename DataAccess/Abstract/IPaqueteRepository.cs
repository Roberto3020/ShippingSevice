using Tranversal.Model.Request;

namespace DataAccess.Abstract
{
    public interface IPaqueteRepository
    {
        Task<int> GetAllTypePackage(PaqueteRequest request);
    }
}
