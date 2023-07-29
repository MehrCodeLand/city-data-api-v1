using System.ComponentModel.DataAnnotations;

namespace city_data_api_v1.Models
{
    public class CreateCityVm
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
