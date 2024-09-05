using AutoMapper;
using BusinessLogic.Model;
using Tranversal.DTO;
using Tranversal.Model;

namespace ShippingApi.Infrastructure.AutoMapper.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<TipoPaquete, TipoPaqueteDTO>();
            CreateMap(typeof(ServiceResponse<>), typeof(ServiceResponse<>));
        }
    }
}
