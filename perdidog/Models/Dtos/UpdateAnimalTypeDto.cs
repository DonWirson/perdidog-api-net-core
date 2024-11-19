using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace perdidog.Models.Dtos
{
    public class UpdateAnimalTypeDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "AnimalName must be at least 3 characters")]
        [MaxLength(15, ErrorMessage = "AnimalName must be up to 15 characters")]
        public string AnimalName { get; set; }
    }
}