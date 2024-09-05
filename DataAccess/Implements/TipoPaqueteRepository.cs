using DataAccess.Abstract;
using Tranversal.Model;
using Tranversal.ProcedureMaps;

namespace DataAccess.Implements
{
    public class TipoPaqueteRepository:ITipoPaqueteRepository
    {
        private readonly DapperContext context;

        public TipoPaqueteRepository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<TipoPaquete>> GetAllTypePackage()
        {

            var result = await context.QuerySPAsync<TipoPaquete>(Procedure.GetAllTypePackage);
            return result;
        }
    }
}
