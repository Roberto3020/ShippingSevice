using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Tranversal.DTO;

namespace ShippingApi.Controllers
{
    [ApiController]
    [Route("api/control/[controller]")]
    public class TypeDocumentController : ControllerBase
    {
        private readonly ITypeDocuments _tipoPaqueteService;
        private readonly IMapper mapper;

        public TypeDocumentController(ITypeDocuments tipoPaqueteService, IMapper mapper)
        {
            _tipoPaqueteService = tipoPaqueteService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTypePackage()
        {
            var resultService = await _tipoPaqueteService.GetAllTypeDocuments();

            return resultService.State == ResultState.Success
                    ? Ok(resultService)
                    : StatusCode(500, resultService);
        }
    }
}
