using AutoMapper;
using Veterinary.Data.Entities;
using Veterinary.Data.Dtos.Users;
using Veterinary.Data.Dtos.Pets;
using Veterinary.Data.Dtos.Visits;
using Veterinary.Data.Dtos.Services;
using Veterinary.Data.Dtos.Auth;


namespace Veterinary.Data
{
    public class MapProfile : Profile
    {
        // Klasių mepinimas į reikalingas versijas, kaip atvaizdavimui, redagavimui registravimas.
        // Duomenų formatų, pervertimo apibrėžimai (į ka , kas)
        public MapProfile()
        {
            CreateMap<Pet, PetDto>();
            CreateMap<PetPostDto, Pet>();
            CreateMap<PetUpdateDto, Pet>();

            CreateMap<Visit, VisitDto>();
            CreateMap<Visit, VisitServiceDto>();
            CreateMap<VisitPostDto, Visit>();
            CreateMap<VisitUpdateDto, Visit>();

            CreateMap<Service, ServiceDto>();
            CreateMap<ServicePostDto, Service>();
            CreateMap<ServiceUpdateDto, Service>();;

            CreateMap<Visit_Services, Visit_Services>(); 

            CreateMap<RestUsers, UserDto>();
            CreateMap<UserUpdateDto, RestUsers>();

        }
    }
}
