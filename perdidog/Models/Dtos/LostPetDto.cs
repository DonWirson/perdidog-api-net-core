using perdidog.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perdidog.Dtos
{
    public class LostPetDto
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime ReportDate { get; set; }
        public bool IsActive { get; set; }
        public Guid AnimalTypeId { get; set; }
        public int GenderId { get; set; }

        //NAV PROPS
        public AnimalType AnimalType { get; set; }
        public Gender Gender { get; set; }
    }
}