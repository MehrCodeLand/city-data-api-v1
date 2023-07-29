using city_data_api_v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace city_data_api_v1.Controllers
{
    [Route("api/MyCity/{cityId}/[controller]")]
    [ApiController]
    public class CityInfoController : ControllerBase
    {

        #region Get

        [HttpGet(Name = "GetInfoCity")]
        public ActionResult GetInfoCity(int cityId)
        {
            var city = CityDTOs.MyCities.Cities
                .FirstOrDefault(x => x.Id == cityId);
            if (city == null)
                return NotFound();

            return Ok(city.InfoCities);
        }

        [HttpGet("{infoId}")]
        public ActionResult GetInfoCityById(int cityId, int infoId)
        {
            var infoCity = CityDTOs.MyCities.Cities
                .FirstOrDefault(x => x.Id == cityId)
                .InfoCities.FirstOrDefault(x => x.Id == infoId);

            if (infoCity == null) return NotFound();

            return Ok(infoCity);
        }


        #endregion

        #region Post

        [HttpPost]
        public ActionResult<InfoCity> CreateInfoCity( int cityId , CreateInfoCityVm createInfoVm)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var city = CityDTOs.MyCities.Cities
                .FirstOrDefault(x => x.Id == cityId);
            if (city == null)
                return NotFound();
            
            
            var cityMaxId = city.InfoCities.Max(x => x.Id);
            var cityInfo = new InfoCity()
            {
                Id = ++cityMaxId,
                AreaCount = createInfoVm.AreaCount,
                Description = createInfoVm.Description,
            };

            city.InfoCities.Add(cityInfo);

            return CreatedAtAction("GetInfoCity", new { cityId = cityId }, cityInfo) ;
        }

        #endregion

        #region Edit Patch

        [HttpPatch("{cityInfoId}")]
        public ActionResult UpdateCityInfo(
              int cityId 
            , int cityInfoId
            , JsonPatchDocument<UpdateCityInfoVm> patchDoc
            )
        {
            var city = CityDTOs.MyCities.Cities
                .FirstOrDefault (x => x.Id == cityId);
            if(city == null)
                return NotFound();

            var cityInfo = city.InfoCities.FirstOrDefault(x => x.Id == cityInfoId);
            if (cityInfo == null)
                return NotFound();

            // old data
            var cityInfoToPatch = new UpdateCityInfoVm()
            {
                AreaCount = cityInfo.AreaCount,
                Descriptions = cityInfo.Description,
            };

            // apply
            patchDoc.ApplyTo( cityInfoToPatch , ModelState);

            if(!ModelState.IsValid)
                return BadRequest();

            cityInfo.AreaCount = cityInfoToPatch.AreaCount;
            cityInfo.Description = cityInfoToPatch.Descriptions;



            return Ok();

        }

        #endregion
    }


}
