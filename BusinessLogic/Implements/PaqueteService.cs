using BusinessLogic.Model;
using BusinessLogic.Service.Helpers;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model.Request;

namespace BusinessLogic.Implements
{
    public class PaqueteService
    {
        private readonly IRemitenteRepository _repository;

        private readonly IDestinarioRepository _repositoryDestinario;

        private readonly IPaqueteRepository _repositoryPaquete;

        public PaqueteService(IRemitenteRepository repository, IDestinarioRepository repositoryDestinario, IPaqueteRepository repositoryPaquete)
        {
            _repository = repository;
            _repositoryDestinario = repositoryDestinario;
            _repositoryPaquete = repositoryPaquete;
        }

        public async Task<ServiceResponse<string>> CrearPaquete(PaqueteCreateRequest request)
        {
            var createRemitente = _repository.CreateRemitente(request.remitente);
            var createDestinario = _repositoryDestinario.CreateDestinario(request.destinario);
            var createPaquete = _repositoryPaquete.CreatePaquete(request.paquete);

            return BuildResponse.Success(data: "Se creo exitosamente");
        }
    }
}
