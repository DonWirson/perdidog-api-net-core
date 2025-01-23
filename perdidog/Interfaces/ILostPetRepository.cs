using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perdidog.Dtos;
using perdidog.Helpers;
using perdidog.Models.Domain;

namespace perdidog.Interfaces
{
    public interface ILostPetRepository
    {
        public Task<List<LostPet>> GetAllAsync(QueryObjectLostPet queryObject);
        public Task<LostPet?> GetOneAsync(int Id);
        public Task<LostPet> CreateAsync(LostPet lostPet);
        public Task<LostPet?> UpdateAsync(int Id, UpdateLostPetDto updateLostPetDto);
        public Task<LostPet?> DeleteAsync(int Id);
    }
}