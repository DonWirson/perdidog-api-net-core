using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using perdidog.Data;
using perdidog.Dtos;
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

        public async Task<List<LostPet>> GetAll()
        {
            return await _context.LostPet.ToListAsync();
        }

        public async Task<LostPet?> GetOne(Guid id)
        {
            return await _context.LostPet.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<LostPet> Create(LostPet lostPet)
        {
            await _context.AddAsync(lostPet);
            await _context.SaveChangesAsync();
            return lostPet;

        }
        public async Task<LostPet?> Update(Guid id, UpdateLostPetDto updateLostPetDto)
        {
            var lostPetModel = _context.LostPet.FirstOrDefault(x => x.Id == id);
            if (lostPetModel == null)
            {
                return null;
            }


            lostPetModel.AnimalType = updateLostPetDto.AnimalType;
            lostPetModel.Name = updateLostPetDto.Name;
            lostPetModel.Gender = updateLostPetDto.Gender;
            lostPetModel.ReportDate = updateLostPetDto.ReportDate;

            await _context.SaveChangesAsync();

            return lostPetModel;

        }
        public async Task<LostPet?> Delete(Guid id)
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