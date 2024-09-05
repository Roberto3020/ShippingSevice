using AutoMapper;
using BusinessLogic.Model;
using Tranversal.DTO;
using Tranversal.DTO.Request;
using Tranversal.Model;
using Tranversal.Model.Request;

namespace ShippingApi.Infrastructure.AutoMapper.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<TipoPaquete, TipoPaqueteDTO>();
            CreateMap(typeof(ServiceResponse<>), typeof(ServiceResponse<>));

            CreateMap<RemitenteRequestDTO,RemitenteRequest>();

            CreateMap<DestinarioRequestDTO, DestinarioRequest>();

            CreateMap<PaqueteRequestDTO, PaqueteRequest>();
            CreateMap<CreacionPaqueteDTO, PaqueteCreateRequest>();

            CreateMap<DireccionRequestDTO, DireccionRequest>();


            CreateMap<TypeDocumentDTO, TypeDocuments>();
        }
    }
}
