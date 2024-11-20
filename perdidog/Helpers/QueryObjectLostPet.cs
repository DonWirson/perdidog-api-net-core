﻿namespace perdidog.Helpers
{
    public class QueryObjectLostPet
    {
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public Guid? AnimalTypeId { get; set; }
        public int? GenderId { get; set; }

        //Sort
        public string? SortBy { get; set; }
        public bool IsAscending { get; set; } = true;
    }
}
