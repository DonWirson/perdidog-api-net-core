using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perdidog.Dtos;
using perdidog.Models.Domain;

namespace perdidog.Interfaces
{
    public interface ILostPetInterface
    {

        public Task<List<LostPet>> GetAll();
        public Task<LostPet?> GetOne(Guid Id);
        public Task<LostPet> Create(CreateLostPetDto createLostPetDto);
        public Task<LostPet?> Update(Guid Id,UpdateLostPetDto updateLostPetDto);
        public Task<LostPet?> Delete(Guid Id);
    }
}