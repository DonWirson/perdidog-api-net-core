using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using perdidog.Data;
using perdidog.Dtos;
using perdidog.Helpers;
using perdidog.Interfaces;
using perdidog.Mappers;
using perdidog.Models.Domain;

namespace perdidog.Repository
{
    public class LostPetRepository : ILostPetRepository
    {
        private readonly ApplicationDBContext _context;

        public LostPetRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<LostPet>> GetAllAsync(QueryObjectLostPet queryObject)
        {
            var lostPets = _context.LostPet.Include("AnimalType").Include("Gender").AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryObject.Name))
            {
                lostPets = lostPets.Where(x => x.Name.Contains(queryObject.Name));
            }

            return await lostPets.ToListAsync();
        }

        public async Task<LostPet?> GetOneAsync(Guid id)
        {
            return await _context.LostPet.Include("AnimalType").Include("Gender").FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<LostPet> CreateAsync(LostPet lostPet)
        {
            await _context.AddAsync(lostPet);
            await _context.SaveChangesAsync();
            return lostPet;

        }
        public async Task<LostPet?> UpdateAsync(Guid id, UpdateLostPetDto updateLostPetDto)
        {
            var lostPetModel = _context.LostPet.FirstOrDefault(x => x.Id == id);
            if (lostPetModel == null)
            {
                return null;
            }

            lostPetModel.Name = updateLostPetDto.Name;
            lostPetModel.IsActive = updateLostPetDto.IsActive;
            lostPetModel.GenderId = updateLostPetDto.GenderId;
            lostPetModel.AnimalTypeId = updateLostPetDto.AnimalTypeId;

            await _context.SaveChangesAsync();

            return lostPetModel;

        }
        public async Task<LostPet?> DeleteAsync(Guid id)
        {
            var lostPet = _context.LostPet.FirstOrDefault(x => x.Id == id);
            if (lostPet == null)
            {
                return null;
            }
            _context.LostPet.Remove(lostPet);
            await _context.SaveChangesAsync();
            return lostPet;

        }


    }
}