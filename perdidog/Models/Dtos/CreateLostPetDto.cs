using perdidog.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace perdidog.Dtos
{
    public class CreateLostPetDto
    {
        [MaxLength(50, ErrorMessage = "Name must be at most 50 characters")]
        public string? Name { get; set; }
        [Required]
        public DateTime ReportDate { get; set; }
        public bool IsActive { get; set; } = false;
        [Required]
        public Guid AnimalTypeId { get; set; }
        [Required]
        public int GenderId { get; set; }
    }
}