using Tranversal.Model;
using Tranversal.Model.Request;

namespace DataAccess.Abstract
{
    public interface IPaqueteRepository
    {
        Task<ResponseCreate> CreatePaquete(PaqueteRequest request);
    }
}
