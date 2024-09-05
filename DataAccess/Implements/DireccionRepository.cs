using Dapper;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model.Request;
using Tranversal.Model;
using Tranversal.ProcedureMaps;

namespace DataAccess.Implements
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly DapperContext context;

        public DireccionRepository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<ResponseCreate> CrearDireccion(DireccionRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Departamento", request.Departamento);
            parameters.Add("Ciudad", request.Ciudad);
            parameters.Add("Pais", request.Pais);
            parameters.Add("Calle", request.Calle);
            parameters.Add("DestinarioId", request.DestinarioId);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("Id", dbType: DbType.Guid, direction: ParameterDirection.Output);

            await context.ExecSPAsync(Procedure.CrearDireccion, parameters);
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
