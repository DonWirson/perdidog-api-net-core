using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using perdidog.Data;
using perdidog.Dtos;
using perdidog.Interfaces;
using perdidog.Mappers;
using perdidog.Models;

namespace perdidog.Repository
{
    public class LostPetRepository : ILostPetInterface
    {
        private readonly ApplicationDBContext _context;

        public LostPetRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<LostPet>> GetAll()
        {
            return await _context.Dog.ToListAsync();
        }

        public async Task<LostPet?> GetOne(int id)
        {
            return await _context.Dog.FindAsync(id);
        }


        public async Task<LostPet> Create(CreateLostPetDto createLostPetDto)
        {
            var newLostPet = createLostPetDto.ToModel();
            await _context.AddAsync(newLostPet);
            await _context.SaveChangesAsync();
            return newLostPet;

        }
        public async Task<LostPet?> Update(int id, UpdateLostPetDto updateLostPetDto)
        {
            var lostPetModel = _context.Dog.FirstOrDefault(x => x.Id == id);
            if (lostPetModel == null)
            {
                return null;
            }

            // lostPetModel.Id = updateLostPetDto.Id;
            // lostPetModel.IsActive = updateLostPetDto.IsActive;

            lostPetModel.AnimalType = updateLostPetDto.AnimalType;
            lostPetModel.Name = updateLostPetDto.Name;
            lostPetModel.Gender = updateLostPetDto.Gender;
            lostPetModel.ReportDate = updateLostPetDto.ReportDate;
            
            await _context.SaveChangesAsync();

            return lostPetModel;

        }
        public async Task<LostPet?> Delete(int id)
        {
            var lostPet = _context.Dog.FirstOrDefault(x => x.Id == id);
            if (lostPet == null)
            {
                return null;
            }
            _context.Dog.Remove(lostPet);
            await _context.SaveChangesAsync();
            return lostPet;

        }


    }
}