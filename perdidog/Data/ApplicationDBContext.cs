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


            //Seeder
            modelBuilder.Entity<AnimalType>().HasData(animalTypes);
            modelBuilder.Entity<Gender>().HasData(genders);



        }
    }
}