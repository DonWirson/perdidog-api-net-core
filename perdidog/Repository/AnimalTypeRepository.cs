using Microsoft.EntityFrameworkCore;
using perdidog.Data;
using perdidog.Dtos;
using perdidog.Interfaces;
using perdidog.Models.Domain;
using perdidog.Models.Dtos;

namespace perdidog.Repository
{
    public class AnimalTypeRepository : IAnimalTypeRepository
    {

        private readonly ApplicationDBContext dbContext;

        public AnimalTypeRepository(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<AnimalType>> GetAllAsync()
        {
            var animalTypes = await this.dbContext.AnimalTypes.ToListAsync();

            return animalTypes;
        }

        public async Task<AnimalType?> GetOneAsync(Guid Id)
        {
            var animalType = await this.dbContext.AnimalTypes.FirstOrDefaultAsync(x => x.Id == Id);
            return animalType;
        }

        public async Task<AnimalType> CreateAsync(AnimalType animalType)
        {
            await dbContext.AnimalTypes.AddAsync(animalType);
            await dbContext.SaveChangesAsync();
            return animalType;
        }

        public async Task<AnimalType?> DeleteAsync(Guid Id)
        {
            var animalType = this.dbContext.AnimalTypes.FirstOrDefault(x => x.Id == Id);
            if (animalType == null)
            {
                return null;
            }
            dbContext.AnimalTypes.Remove(animalType);
            await dbContext.SaveChangesAsync();

            return animalType;
        }

        public async Task<AnimalType?> UpdateAsync(Guid Id, UpdateAnimalTypeDto updateAnimalTypeDto)
        {
            var animalType = this.dbContext.AnimalTypes.FirstOrDefault(x => x.Id == Id);
            if (animalType == null)
            {
                return null;
            }
            animalType.AnimalName = updateAnimalTypeDto.AnimalName;

            await this.dbContext.SaveChangesAsync();
            return animalType;
        }
    }
}
