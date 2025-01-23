using Microsoft.EntityFrameworkCore;
using perdidog.Data;
using perdidog.Dtos;
using perdidog.Helpers;
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

        public async Task<List<AnimalType>> GetAllAsync(QueryObjectAnimalType queryObject)
        {
            var animalTypes = this.dbContext.AnimalTypes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryObject.Name))
            {
                animalTypes = animalTypes.Where(x => x.Name.Contains(queryObject.Name));
            }

            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.Equals("Name"))
                {
                    animalTypes = queryObject.IsAscending ?
                        animalTypes.OrderBy(x => x.Name) :
                        animalTypes.OrderByDescending(x => x.Name);
                }
            }
            //Pagination
            var skipResults = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return await animalTypes.Skip(skipResults).Take(queryObject.PageSize).ToListAsync();
        }
        public async Task<AnimalType?> GetOneAsync(int Id)
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

        public async Task<AnimalType?> DeleteAsync(int Id)
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

        public async Task<AnimalType?> UpdateAsync(int Id, UpdateAnimalTypeDto updateAnimalTypeDto)
        {
            var animalType = this.dbContext.AnimalTypes.FirstOrDefault(x => x.Id == Id);
            if (animalType == null)
            {
                return null;
            }
            animalType.Name = updateAnimalTypeDto.Name;

            await this.dbContext.SaveChangesAsync();
            return animalType;
        }
    }
}
