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

        [HttpGet("{cityId}" , Name = "getMyCity")]
        public ActionResult GetCityById(int cityId)
        {
            var city = CityDTOs.MyCities.Cities
                .FirstOrDefault(x => x.Id == cityId);

            if (city == null)
                return NotFound();

            return Ok(city);
        }

        #endregion

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
            return CreatedAtAction("getMyCity" , newCity.Id , newCity);
        }
    }
}
