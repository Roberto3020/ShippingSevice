﻿using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tranversal.DTO;

namespace ShippingApi.Controllers
{
    [ApiController]
    [Route("api/control/[controller]")]
    public class TipoPaqueteController : ControllerBase
    {
        private readonly ITypeDocuments _tipoPaqueteService;
        private readonly IMapper mapper;

        public TipoPaqueteController(ITypeDocuments tipoPaqueteService, IMapper mapper)
        {
            _tipoPaqueteService = tipoPaqueteService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTypePackage()
        {
            var resultService = await _tipoPaqueteService.GetAllTypeDocuments();
            var mapResult = mapper.Map<ServiceResponse<IEnumerable<TipoPaqueteDTO>>>(resultService);

            return mapResult.State == ResultState.Success
                    ? Ok(mapResult)
                    : StatusCode(500, mapResult);
        }
    }
}
