using Tranversal.Model;

namespace DataAccess.Abstract
{
    public interface ITipoPaqueteRepository
    {
        Task<IEnumerable<TipoPaquete>> GetAllTypePackage();
    }
}
