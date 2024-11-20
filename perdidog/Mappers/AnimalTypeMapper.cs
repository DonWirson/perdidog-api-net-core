using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perdidog.Models.Domain;
using perdidog.Models.Dtos;

namespace perdidog.Mappers
{
    public static class AnimalTypeMapper
    {
        public static AnimalTypesDto ToAnimalTypeDto(this AnimalType animalType)
        {
            return new AnimalTypesDto
            {
                Id = animalType.Id,
                Name = animalType.Name
            };
        }

        public static AnimalType ToModel(this CreateAnimalTypeDto animalTypeDto)
        {
            return new AnimalType
            {
                Name = animalTypeDto.Name
            };

        }
    }
}