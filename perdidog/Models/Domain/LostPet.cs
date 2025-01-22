using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace perdidog.Models.Domain
{
    public class LostPet
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime ReportDate { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? DistinctFeature { get; set; }
        public int? PhoneNumberInscribed { get; set; }
        public bool IsActive { get; set; } = false;
        public int AnimalTypeId { get; set; }
        public int GenderId { get; set; }

        //Nav props
        public AnimalType AnimalType { get; set; }
        public Gender Gender { get; set; }
    }

}