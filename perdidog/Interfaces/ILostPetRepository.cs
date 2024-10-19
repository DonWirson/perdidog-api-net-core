using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perdidog.Dtos;
using perdidog.Models;

namespace perdidog.Interfaces
{
    public interface ILostPetInterface
    {

        public Task<List<LostPet>> GetAll();
        public Task<LostPet?> GetOne(int Id);
        public Task<LostPet> Create(CreateLostPetDto createLostPetDto);
        public Task<LostPet?> Update(int Id,UpdateLostPetDto updateLostPetDto);
        public Task<LostPet?> Delete(int Id);
    }
}