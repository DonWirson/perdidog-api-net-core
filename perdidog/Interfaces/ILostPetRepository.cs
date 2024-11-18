using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perdidog.Dtos;
using perdidog.Models.Domain;

namespace perdidog.Interfaces
{
    public interface ILostPetRepository
    {
        public Task<List<LostPet>> GetAllAsync();
        public Task<LostPet?> GetOneAsync(Guid Id);
        public Task<LostPet> CreateAsync(LostPet lostPet);
        public Task<LostPet?> UpdateAsync(Guid Id, UpdateLostPetDto updateLostPetDto);
        public Task<LostPet?> DeleteAsync(Guid Id);
    }
}