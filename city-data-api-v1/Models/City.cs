namespace city_data_api_v1.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<InfoCity>? InfoCities { get; set; } = new List<InfoCity>();
    }
}
