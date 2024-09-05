using Dapper;
using DataAccess.Abstract;
using System.Data;
using Tranversal.Model;
using Tranversal.Model.Request;
using Tranversal.ProcedureMaps;

namespace DataAccess.Implements
{
    public class RemitenteRepsository:IRemitenteRepository
    {
        private readonly DapperContext context;

        public RemitenteRepsository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<ResponseCreate> CreateRemitente(RemitenteRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NombreCompleto", request.NombreCompleto);
            parameters.Add("Telefono", request.Telefono);
            parameters.Add("Departamento", request.Departamento);
            parameters.Add("Ciudad", request.Ciudad);
            parameters.Add("Identificacion", request.Identificacion);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("Id", dbType: DbType.Guid, direction: ParameterDirection.Output);

            await context.ExecSPAsync(Procedure.InsertRemitente, parameters);
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
