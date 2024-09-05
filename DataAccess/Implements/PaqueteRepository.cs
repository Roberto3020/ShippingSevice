using Dapper;
using DataAccess.Abstract;
using System.Data;
using Tranversal.Model;
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
        public async Task<ResponseCreate> CreatePaquete(PaqueteRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Descripcion", request.Descripcion);
            parameters.Add("RemitenteId", request.RemitenteId);
            parameters.Add("DestinarioId", request.DestinarioId);
            parameters.Add("TipoPaqueteId", request.TipoPaqueteId);
            parameters.Add("Peso", request.Peso);
            parameters.Add("Cantidad", request.Cantidad);
            parameters.Add("Valor", request.Valor);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("Id", dbType: DbType.Guid, direction: ParameterDirection.Output);


            await context.ExecSPAsync(Procedure.CrearPaquete, parameters);
            var succes = parameters.Get<int>("Success");
            var Id = parameters.Get<Guid>("Id");
            var response = new ResponseCreate
            {
                Succes = succes,
                Id = Id
            };
            return response;

        }
    }
}
