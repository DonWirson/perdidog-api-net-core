using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perdidog.Helpers;
using perdidog.Models.Domain;
using perdidog.Models.Dtos;

namespace perdidog.Interfaces
{
    public interface IAnimalTypeRepository
    {
        public Task<List<AnimalType>> GetAllAsync(QueryObjectAnimalType queryObject);
        public Task<AnimalType?> GetOneAsync(int Id);
        public Task<AnimalType> CreateAsync(AnimalType animalType);
        public Task<AnimalType?> UpdateAsync(int Id, UpdateAnimalTypeDto updateAnimalTypeDto);
        public Task<AnimalType?> DeleteAsync(int Id);
    }
}