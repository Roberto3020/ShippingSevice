using BusinessLogic.Model;
using Tranversal.Model;

namespace BusinessLogic.Abstract
{
    public interface ITipoPaqueteService
    {
        Task<ServiceResponse<IEnumerable<TipoPaquete>?>> GetAllTypePackage();
    }
}
