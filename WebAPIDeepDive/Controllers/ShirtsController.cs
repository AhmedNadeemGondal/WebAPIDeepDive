using Microsoft.AspNetCore.Mvc;
using WebAPIDeepDive.Models;

namespace WebAPIDeepDive.Controllers
{
    // This class is automatically discovered as a controller because its name 
    // ends in "Controller". The attribute and inheritance add API-specific 
    // behaviors and helper methods.
    [ApiController]
    //Using route template
    [Route("api/[controller]")] // Attribute routing at class level
    // this results in /api/[whatever is in the verd attribute]
    public class ShirtsController : ControllerBase
    {
        
        [HttpGet]
        //[Route("/shirts")] // Explicit routing not convention based
        // Action Method
        public string GetShirts()
        {
            return "Reading all shirts";
        }

        [HttpGet("{id}")]
        //[HttpGet("{id}/{color}")]
        //[Route("/shirts/{id}")]
        public string GetShirtById(int id,[FromHeader(Name="Color")] string color) // explicit with header
        //public string GetShirtById(int id,[FromQuery] string color) // explicit with query
        //public string GetShirtById(int id, string color) [FromRoute] [FromQuery]
        {
            return $"Reading shirt by id: {id} with color: {color}";
        }

        [HttpPost]
        //[Route("/shirts")]
        public string CreateShirt([FromBody]Shirt shirt) // This binds the complex type
                                                         // using it's class definition
        //public string CreateShirt([FromForm] Shirt shirt)
        {
            return $"Creating a shirt";
        }

        [HttpPut("{id}")]
        //[Route("/shirts/{id}")]
        public string UpdateShirt(int id)
        {
            return $"Updating shirt: {id}";
        }


        [HttpDelete("{id}")]
        //[Route("/shirts/{id}")]
        public string DeleteShirt(int id)
        {
            return $"Deleting shirt: {id}";
        }
    }
}
