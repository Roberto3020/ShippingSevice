using Dapper;
using DataAccess.Abstract;
using System.Data;
using Tranversal.Model;
using Tranversal.Model.Request;
using Tranversal.ProcedureMaps;

namespace DataAccess.Implements
{
    public class DestinarioRepsository: IDestinarioRepository
    {
        private readonly DapperContext context;

        public DestinarioRepsository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<ResponseCreate> CreateDestinario(DestinarioRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NombreCompleto", request.ContactoNombre);
            parameters.Add("Telefono", request.Telefono);
            parameters.Add("Correo", request.Correo);
            parameters.Add("IdDireccion", request.IdDireccion);
            parameters.Add("TipoIdentificacion", request.TipoIdentificacion);
            parameters.Add("Identificacion", request.Identificacion);
            parameters.Add("Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("Id", dbType: DbType.Guid, direction: ParameterDirection.Output);

            await context.ExecSPAsync(Procedure.CrearDestinario, parameters);
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
