using perdidog.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perdidog.Dtos
{
    public class CreateLostPetDto
    {
        public string? Name { get; set; }
        public DateTime ReportDate { get; set; }
        public bool IsActive { get; set; } = false;
        public Guid AnimalTypeId { get; set; }
        public int GenderId { get; set; }
    }
}