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

            //Filter
            if (!string.IsNullOrWhiteSpace(queryObject.Name))
            {
                lostPets = lostPets.Where(x => x.Name.Contains(queryObject.Name));
            }
            if (!string.IsNullOrWhiteSpace(queryObject.AnimalTypeId.ToString()))
            {
                lostPets = lostPets.Where(x => x.IsActive == queryObject.IsActive);
            }
            //Sort
            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.Equals("Name"))
                {
                    lostPets = queryObject.IsAscending ?
                        lostPets.OrderBy(x => x.Name) :
                        lostPets.OrderByDescending(x => x.Name);
                }
                if (queryObject.SortBy.Equals("IsActive"))
                {
                    lostPets = queryObject.IsAscending ?
                        lostPets.OrderBy(x => x.IsActive) :
                        lostPets.OrderByDescending(x => x.IsActive);
                }
            }

            //Pagination
            var skipResults = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return await lostPets.Skip(skipResults).Take(queryObject.PageSize).ToListAsync();
        }

        public async Task<LostPet?> GetOneAsync(int id)
        {
            return await _context.LostPet.Include("AnimalType").Include("Gender").FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<LostPet> CreateAsync(LostPet lostPet)
        {
            await _context.AddAsync(lostPet);
            await _context.SaveChangesAsync();
            return lostPet;

        }
        public async Task<LostPet?> UpdateAsync(int id, UpdateLostPetDto updateLostPetDto)
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
            lostPetModel.Description = updateLostPetDto.Description;
            lostPetModel.DistinctFeature = updateLostPetDto?.DistinctFeature;


            await _context.SaveChangesAsync();

            return lostPetModel;

        }
        public async Task<LostPet?> DeleteAsync(int id)
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