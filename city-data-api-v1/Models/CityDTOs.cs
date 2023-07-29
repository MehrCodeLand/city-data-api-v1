namespace city_data_api_v1.Models
{
    public class CityDTOs
    {
        public List<City> Cities { get; set; }
        public static CityDTOs MyCities { get; set; } = new CityDTOs();

        public CityDTOs()
        {
            Cities = new List<City>()
            {
                new City()
                {
                    Id = 1 ,
                    Name = "Tehran",
                    InfoCities = new List<InfoCity>()
                    {
                        new InfoCity()
                        {
                            Id = 0 ,
                            AreaCount = 22,
                            Description = "tehran ist hauptstadt von iran",
                        },
                        new InfoCity()
                        {
                            Id = 1 ,
                            AreaCount= 22,
                            Description = "das ist zweiten desc fur tehran!"
                        }
                    }
                },
                new City()
                {
                    Id = 2 ,
                    Name = "Berlin",
                    InfoCities = new List<InfoCity>()
                    {
                        new InfoCity()
                        {
                            Id = 0 ,
                            AreaCount = 16 ,
                            Description = "Berlin ist hauptstadt!"
                        },
                        new InfoCity()
                        {
                            Id = 1 ,
                            AreaCount = 2 ,
                            Description = "das ist nochts!"
                        }
                    }
                }

            };
        }
    }
}
