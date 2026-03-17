using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPIDeepDive.Models;

// SUMMARY: IActionResult vs. ActionResult vs. ActionResult<T>
// -----------------------------------------------------------------------------------------
// 1. IActionResult (Interface):
//    - The most flexible return type.
//    - Defines a contract for any HTTP result (Views, JSON, Redirects, Status Codes).
//    - Best for traditional MVC Controllers returning Views.
//    - Limitation: Swagger/OpenAPI cannot "see" the return model type without extra attributes.
//
// 2. ActionResult (Abstract Class):
//    - The base implementation of IActionResult.
//    - All specific results (OkObjectResult, NotFoundResult, etc.) inherit from this.
//
// 3. ActionResult<TValue> (The "Hybrid" Wrapper):
//    - A specialized wrapper class designed specifically for Web APIs.
//    - Uses "Implicit Casting" (Implicit Operators) to allow returning two different things:
//        a) A specific data type (e.g., UserDto).
//        b) Any class inheriting from ActionResult (e.g., ValidationProblem(), NotFound()).
//
// 4. How ActionResult<TValue> Works Internally:
//    - It contains two constructors:
//        - public ActionResult(TValue value);  => Sets the .Value property (Success path).
//        - public ActionResult(ActionResult result); => Sets the .Result property (Status/Error path).
//    - It uses Implicit Operators so you don't have to call 'new' manually. 
//      Example: 'return userDto;' automatically calls the TValue constructor.
//
// 5. Why use ActionResult<TValue> over IActionResult?
//    - Type Safety: Ensures the success path always returns the expected DTO.
//    - Documentation: Swagger automatically detects the return schema for the 200 OK response.
//    - Unit Testing: Easier to inspect the .Value or .Result properties directly.
// -----------------------------------------------------------------------------------------

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
        private List<Shirt> shirts =
        [
            new Shirt { ShirtId = 1, Brand = "Nike", Color = "Blue", Size = 10, Gender = "Men", price = 25.99 },
            new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Black", Size = 8, Gender = "Women", price = 30.00 },
            new Shirt { ShirtId = 3, Brand = "Puma", Color = "White", Size = 12, Gender = "Men", price = 19.50 },
            new Shirt { ShirtId = 4, Brand = "Reebok", Color = "Red", Size = 6, Gender = "Women", price = 22.00 }
        ];

        [HttpGet]
        //[Route("/shirts")] // Explicit routing not convention based
        // Action Method
        public IActionResult GetShirts()
        {
            return Ok("Reading all shirts");
        }

        [HttpGet("{id}")]
        //[HttpGet("{id}/{color}")]
        //[Route("/shirts/{id}")]

        ////// Use IActionResult when action method returns different types of data
        public IActionResult GetShirtById(int id) 

        //public string GetShirtById(int id,[FromHeader(Name="Color")] string color) // explicit with header
        //public string GetShirtById(int id,[FromQuery] string color) // explicit with query
        //public string GetShirtById(int id, string color) [FromRoute] [FromQuery]
        {
            if (id <= 0) return BadRequest();

            var shirt = shirts.FirstOrDefault(x => x.ShirtId == id);
            if (shirt == null)
            {
                return NotFound();
            }
            return Ok(shirt);
        }

        [HttpPost]
        //[Route("/shirts")]
        public IActionResult CreateShirt([FromBody]Shirt shirt) // This binds the complex type
                                                         // using it's class definition
        //public string CreateShirt([FromForm] Shirt shirt)
        {
            return Ok($"Creating a shirt");
        }

        [HttpPut("{id}")]
        //[Route("/shirts/{id}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Updating shirt: {id}");
        }


        [HttpDelete("{id}")]
        //[Route("/shirts/{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleting shirt: {id}");
        }
    }
}
