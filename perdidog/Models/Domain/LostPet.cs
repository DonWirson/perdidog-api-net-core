using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static perdidog.enums.Enums;


namespace perdidog.Models.Domain
{
    public class LostPet
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime ReportDate { get; set; }
        public bool IsActive { get; set; } = false;
        public Guid AnimalTypeId { get; set; }

        //Nav props
        public AnimalType AnimalType { get; set; }


    }

}