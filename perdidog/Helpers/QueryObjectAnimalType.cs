namespace perdidog.Helpers
{
    public class QueryObjectAnimalType
    {
       //Filter
        public string? Name{ get; set; }

        //Sort
        public string? SortBy { get; set; }
        public bool IsAscending { get; set; } = true;
    }
}
