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
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<LostPet> LostPet { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Gender> Gender { get; set; }

    }
}