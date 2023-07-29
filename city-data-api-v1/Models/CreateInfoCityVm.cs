using System.ComponentModel.DataAnnotations;

namespace city_data_api_v1.Models
{
    public class CreateInfoCityVm
    {
        [Required]
        public int AreaCount { get; set; }
        public string? Description { get; set; }
    }
}
