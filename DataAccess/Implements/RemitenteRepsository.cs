using Dapper;
using Tranversal.Model.Request;
using Tranversal.ProcedureMaps;

namespace DataAccess.Implements
{
    public class RemitenteRepsository
    {
        private readonly DapperContext context;

        public RemitenteRepsository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateRemitente(RemitenteRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ContactoNombre", request.ContactoNombre);
            parameters.Add("IdDireccion", request.IdDireccion);
            parameters.Add("Telefono", request.Telefono);
            parameters.Add("Correo", request.Correo);

            await context.ExecSPAsync(Procedure.CrearRemitente, parameters);
            return parameters.Get<int>("Success");

        }
    }

}
