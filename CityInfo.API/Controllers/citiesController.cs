using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class citiesController : ControllerBase
    {
        public JsonResult GetCities()
        {
            return new JsonResult(
                new List<object>
                {
                    new {id =1, Name = "New york city"},
                    new {id =2, Name = "Kisumu"}
                }); 
            
        }
    }
}
