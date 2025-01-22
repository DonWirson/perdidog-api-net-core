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
                new AnimalType {Id = 1,Name = "Cat" },
                new AnimalType {Id = 2,Name = "Dog"},
                new AnimalType {Id = 3,Name = "Snake"},
            };

            var genders = new List<Gender>() {
                new Gender{Id = 1, Name= "Male"},
                new Gender{Id = 2, Name= "Female"},
            };

            var lostPets = new List<LostPet>() { 
                new LostPet {Id = 1 ,Name = "Cabezon",ReportDate=DateTime.Now,IsActive=true,AnimalTypeId = 2,GenderId = 1},
                new LostPet {Id = 2 ,Name = "Cabezona",ReportDate=DateTime.Now,IsActive=true,AnimalTypeId=1,GenderId = 2},
                new LostPet {Id = 3 ,Name = "Lucky",ReportDate=DateTime.Now,IsActive=true,AnimalTypeId= 1,GenderId = 1},
                new LostPet {Id = 4,Name = "",ReportDate=DateTime.Now,IsActive=true,AnimalTypeId= 2,GenderId = 1},
            };

            //Seeder
            modelBuilder.Entity<AnimalType>().HasData(animalTypes);
            modelBuilder.Entity<Gender>().HasData(genders);
            modelBuilder.Entity<LostPet>().HasData(lostPets);


        }
    }
}