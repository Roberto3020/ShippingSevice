using Dapper;
using DataAccess.Abstract;
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
        public async Task<int> CreateDestinario(DestinarioRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NombreCompleto", request.ContactoNombre);
            parameters.Add("Telefono", request.Telefono);
            parameters.Add("Correo", request.Correo);
            parameters.Add("IdDireccion", request.IdDireccion);

            await context.ExecSPAsync(Procedure.CrearDestinario, parameters);
            return parameters.Get<int>("Success");

        }
    }

}
