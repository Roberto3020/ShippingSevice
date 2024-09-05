using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Tranversal.DTO;
using Tranversal.DTO.Request;
using Tranversal.Model.Request;

namespace ShippingApi.Controllers
{
    [ApiController]
    [Route("api/control/[controller]")]
    public class RemitenteController : ControllerBase
    {
        private readonly IRemitenteService _remitenteService;
        private readonly IMapper mapper;

        public RemitenteController(IRemitenteService remitenteService, IMapper mapper)
        {
            _remitenteService = remitenteService;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRemitente(RemitenteRequestDTO request)
        {
            var mapRequets = mapper.Map<RemitenteRequest>(request);
            var resultService = await _remitenteService.CreateRemitente(mapRequets);
            var mapResult = mapper.Map<ServiceResponse<string>>(resultService);

            return mapResult.State == ResultState.Success
                    ? Ok(mapResult)
                    : StatusCode(500, mapResult);
        }
    }
}
