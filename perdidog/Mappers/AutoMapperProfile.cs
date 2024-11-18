using AutoMapper;
using perdidog.Dtos;
using perdidog.Models.Domain;
using perdidog.Models.Dtos;

namespace perdidog.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            CreateMap<LostPet, LostPetDto>().ReverseMap();
            CreateMap<UpdateLostPetDto, LostPet>().ReverseMap();
            CreateMap<CreateLostPetDto, LostPet>().ReverseMap();
            
            CreateMap<AnimalType, AnimalTypesDto>().ReverseMap();
            CreateMap<UpdateAnimalTypeDto, AnimalType>().ReverseMap();
            CreateMap<CreateAnimalTypeDto, AnimalType>().ReverseMap();

            CreateMap<Gender, GenderDto>().ReverseMap();
        }
    }
}
