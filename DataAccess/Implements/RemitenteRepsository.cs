﻿using Dapper;
using DataAccess.Abstract;
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
        public async Task<int> CreateRemitente(RemitenteRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NombreCompleto", request.NombreCompleto);
            parameters.Add("Telefono", request.Telefono);
            parameters.Add("Departamento", request.Departamento);
            parameters.Add("Ciudad", request.Ciudad);

            await context.ExecSPAsync(Procedure.InsertRemitente, parameters);
            return parameters.Get<int>("Success");

        }
    }

}
