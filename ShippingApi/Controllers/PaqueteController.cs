using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Implements;
using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Tranversal.DTO.Request;
using Tranversal.Model.Request;

namespace ShippingApi.Controllers
{
    [ApiController]
    [Route("api/control/[controller]")]
    public class PaqueteController : ControllerBase
    {
        private readonly IPaqueteService _paqueteService;
        private readonly IMapper mapper;

        public PaqueteController(IPaqueteService paqueteService, IMapper mapper)
        {
            _paqueteService = paqueteService;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRemitente(CreacionPaqueteDTO request)
        {
            var mapRequets = mapper.Map<PaqueteCreateRequest>(request);
            var resultService = await _paqueteService.CrearPaquete(mapRequets);
            var mapResult = mapper.Map<ServiceResponse<string>>(resultService);

            return mapResult.State == ResultState.Success
                    ? Ok(mapResult)
                    : StatusCode(500, mapResult);
        }
    }
}
