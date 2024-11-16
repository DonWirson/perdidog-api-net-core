using perdidog.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static perdidog.enums.Enums;

namespace perdidog.Dtos
{
    public class UpdateLostPetDto
    {
        public AnimalType AnimalType { get; set; }
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime ReportDate { get; set; }
    }
}