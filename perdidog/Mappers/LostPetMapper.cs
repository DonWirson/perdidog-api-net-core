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
                Gender = lostPet.Gender,
                ReportDate = lostPet.ReportDate,
                IsActive = lostPet.IsActive,
                AnimalTypeId = lostPet.AnimalTypeId,
                     AnimalType = lostPet.AnimalType,

            };
        }
        public static LostPet ToModel(this CreateLostPetDto lostPetDto)
        {
            return new LostPet
            {
                Name = lostPetDto.Name,
                AnimalTypeId = lostPetDto.AnimalTypeId,
                ReportDate = DateTime.Now,
                IsActive = true,
            };
        }
    }
}