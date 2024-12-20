using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using perdidog.Models.Domain;

namespace perdidog.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<LostPet> LostPet { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            //Dummy Data    
            var animalTypes = new List<AnimalType>(){
                new AnimalType {Id = Guid.Parse("e1f95dcb-0103-47f6-9ddb-dad7dae65365"),Name = "Cat" },
                new AnimalType {Id = Guid.Parse("64d6b2f4-77a3-46d8-91be-fc36ab0103b9"),Name = "Dog"},
                new AnimalType {Id = Guid.Parse("b8851d86-8193-48a5-9561-458b82b16f1e"),Name = "Snake"},
            };

            var genders = new List<Gender>() {
                new Gender{Id = 1, Name= "Male"},
                new Gender{Id = 2, Name= "Female"},
            };

            var lostPets = new List<LostPet>() { 
                new LostPet {Id = Guid.Parse("8b5849f8-554b-4057-bb90-9ba29aba9a1a") ,Name = "Cabezon",ReportDate=DateTime.Now,IsActive=true,AnimalTypeId = Guid.Parse("64D6B2F4-77A3-46D8-91BE-FC36AB0103B9"),GenderId = 1},
                new LostPet {Id = Guid.Parse("dfae5930-af55-4aa3-8c11-f141fd75ce69") ,Name = "Cabezona",ReportDate=DateTime.Now,IsActive=true,AnimalTypeId= Guid.Parse("64D6B2F4-77A3-46D8-91BE-FC36AB0103B9"),GenderId = 2},
                new LostPet {Id = Guid.Parse("22e71034-37e2-44ad-b31e-928b1f431d45") ,Name = "Lucky",ReportDate=DateTime.Now,IsActive=true,AnimalTypeId= Guid.Parse("64D6B2F4-77A3-46D8-91BE-FC36AB0103B9"),GenderId = 1},
                new LostPet {Id = Guid.Parse("8b06fc47-666f-4685-8ec0-d5793b9be883") ,Name = "",ReportDate=DateTime.Now,IsActive=true,AnimalTypeId= Guid.Parse("E1F95DCB-0103-47F6-9DDB-DAD7DAE65365"),GenderId = 1},
            };

            //Seeder
            modelBuilder.Entity<AnimalType>().HasData(animalTypes);
            modelBuilder.Entity<Gender>().HasData(genders);
            modelBuilder.Entity<LostPet>().HasData(lostPets);


        }
    }
}