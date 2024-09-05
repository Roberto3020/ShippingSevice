using Dapper;
using DataAccess.Abstract;
using Tranversal.Model.Request;
using Tranversal.ProcedureMaps;

namespace DataAccess.Implements
{
    public class PaqueteRepository:IPaqueteRepository
    {
        private readonly DapperContext context;

        public PaqueteRepository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<int> CreatePaquete(PaqueteRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Descripcion", request.Descripcion);
            parameters.Add("RemitenteId", request.RemitenteId);
            parameters.Add("DestinarioId", request.DestinarioId);
            parameters.Add("TipoPaqueteId", request.TipoPaqueteId);
            parameters.Add("Peso", request.Peso);
            parameters.Add("Cantidad", request.Cantidad);

            await context.ExecSPAsync(Procedure.CrearPaquete, parameters);
            return parameters.Get<int>("Success");

        }
    }
}
