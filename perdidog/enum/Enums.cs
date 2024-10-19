using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perdidog.enums
{
    public class Enums
    {

        public enum AnimalType
        {
            Dog,
            Cat
        }
        public enum Gender : int
        {
            NoIdea = 0,
            Male = 1,
            Female = 2,
        }
    }
}