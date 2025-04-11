using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perdidog.Dtos;
using perdidog.Models.Domain;

namespace perdidog.Mappers
{
    public static class LostPetMapper
    {
        public static LostPetDto ToLostPetDto(this LostPet lostPet)
        {
            return new LostPetDto
            {
                Id = lostPet.Id,
                Name = lostPet.Name,
                ReportDate = lostPet.ReportDate,
                Description = lostPet.Description,
                ImageUrl = lostPet.ImageUrl,
                DistinctFeature = lostPet.DistinctFeature,
                PhoneNumberInscribed = lostPet.PhoneNumberInscribed,
                IsActive = lostPet.IsActive,
                AnimalTypeId = lostPet.AnimalTypeId,
                GenderId = lostPet.GenderId,
                Gender = lostPet.Gender,
                AnimalType = lostPet.AnimalType,

            };
        }
        public static LostPet ToModel(this CreateLostPetDto lostPetDto)
        {
            return new LostPet
            {
                Name = lostPetDto.Name,
                ReportDate = DateTime.Now,
                Description = lostPetDto.Description,
                ImageUrl= lostPetDto.ImageUrl,
                DistinctFeature= lostPetDto.DistinctFeature,
                PhoneNumberInscribed= lostPetDto.PhoneNumberInscribed,
                IsActive = true,
                AnimalTypeId = lostPetDto.AnimalTypeId,
                GenderId = lostPetDto.GenderId,
            };
        }
    }
}