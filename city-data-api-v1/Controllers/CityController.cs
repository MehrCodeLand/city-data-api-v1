using city_data_api_v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace city_data_api_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        #region Get

        [HttpGet]
        public ActionResult GetCity()
        {
            var cities = CityDTOs.MyCities.Cities;
            if (cities == null)
                return NotFound();

            return Ok(cities);
        }

        [HttpGet("{id}" , Name = "GetCityById")]
        public ActionResult GetCityById(int id)
        {
            var city = CityDTOs.MyCities.Cities
                .FirstOrDefault(x => x.Id == id);

            if (city == null)
                return NotFound();

            return Ok(city);
        }

        #endregion

        #region Post

        // create city
        [HttpPost]
        public ActionResult<City> CreateCity(CreateCityVm createCity)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var cityId = CityDTOs.MyCities.Cities
                .Max(x => x.Id );

            if (cityId == null)
                return NotFound();

            var newCity = new City()
            {
                Id = ++cityId,
                Name = createCity.Name,
            };

            CityDTOs.MyCities.Cities.Add(newCity);

            return CreatedAtAction("GetCityById", new { id = newCity.Id } , newCity);
        }

        #endregion
    }
}
