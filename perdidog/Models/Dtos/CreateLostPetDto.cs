using perdidog.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static perdidog.enums.Enums;

namespace perdidog.Dtos
{
    public class CreateLostPetDto
    {

        public AnimalType AnimalType { get; set; }
        public string? Name { get; set; }
        //Didn't add report date on user side, backend adds date of report on the mapper.
        public Gender Gender { get; set; }
    }
}