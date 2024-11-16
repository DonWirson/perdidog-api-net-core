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
                AnimalType = lostPet.AnimalType,
                Name = lostPet.Name,
                Gender = lostPet.Gender,
                ReportDate = lostPet.ReportDate,
                IsActive = lostPet.IsActive,

            };
        }
        public static LostPet ToModel(this CreateLostPetDto lostPetDto)
        {
            return new LostPet
            {
                AnimalType = lostPetDto.AnimalType,
                Name = lostPetDto.Name,
                Gender = lostPetDto.Gender,
                ReportDate = DateTime.Now,
            };
        }
    }
}