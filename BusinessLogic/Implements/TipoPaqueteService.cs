using BusinessLogic.Abstract;
using BusinessLogic.Model;
using BusinessLogic.Service.Helpers;
using DataAccess.Abstract;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model;

namespace BusinessLogic.Implements
{
    public class TipoPaqueteService: ITipoPaqueteService
    {
        private readonly ITipoPaqueteRepository repository;

        public TipoPaqueteService(ITipoPaqueteRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ServiceResponse<IEnumerable<TipoPaquete>?>> GetAllTypePackage()
        {
            try
            {
                var result = await repository.GetAllTypePackage();
                return BuildResponse.List(result);

            }
            catch (Exception e)
            {
                return BuildResponse.Error<IEnumerable<TipoPaquete>>(message: e.Message);
            }
        }
    }
}
