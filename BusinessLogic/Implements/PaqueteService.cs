﻿using BusinessLogic.Abstract;
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
    public class PaqueteService: IPaqueteService
    {
        private readonly IRemitenteRepository _repository;
        private readonly IDestinarioRepository _repositoryDestinario;
        private readonly IPaqueteRepository _repositoryPaquete;
        private readonly IDireccionRepository _direccionRepository;

        public PaqueteService(IRemitenteRepository repository, IDestinarioRepository repositoryDestinario,
            IPaqueteRepository repositoryPaquete, IDireccionRepository direccionRepository)
        {
            _repository = repository;
            _repositoryDestinario = repositoryDestinario;
            _repositoryPaquete = repositoryPaquete;
            _direccionRepository = direccionRepository;
        }

        public async Task<ServiceResponse<string>> CrearPaquete(PaqueteCreateRequest request)
        {
            var createRemitente = await _repository.CreateRemitente(request.remitente);
            var createDestinario = await _repositoryDestinario.CreateDestinario(request.destinario);
            if (createRemitente.Succes > 0 && createDestinario.Succes > 0)
            {

                request.paquete.RemitenteId = createRemitente.Id;
                request.paquete.DestinarioId = createDestinario.Id;
                request.destinario.Direccion.DestinarioId = createDestinario.Id;
                var creacionDireccion = _direccionRepository.CrearDireccion(request.destinario.Direccion);
                var createPaquete = await _repositoryPaquete.CreatePaquete(request.paquete);
            };

            return BuildResponse.Success(data: "Se creo exitosamente");
        }
    }
}
