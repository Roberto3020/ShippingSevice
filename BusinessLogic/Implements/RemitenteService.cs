using BusinessLogic.Abstract;
using BusinessLogic.Model;
using BusinessLogic.Service.Helpers;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model;
using Tranversal.Model.Request;

namespace BusinessLogic.Implements
{
    public class RemitenteService: IRemitenteService
    {
        private readonly IRemitenteRepository repository;

        public RemitenteService(IRemitenteRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ServiceResponse<string>> CreateRemitente(RemitenteRequest request)
        {
            try
            {
                var result = await repository.CreateRemitente(request);
                if(result > 0)
                {

                    return BuildResponse.Success(data:"Se creo exitosamente");
                }
                return BuildResponse.Success(data: "No se logro crear");
            }
            catch (Exception e)
            {
                return BuildResponse.Error<string>(message: e.Message);
            }
        }
    }
}
