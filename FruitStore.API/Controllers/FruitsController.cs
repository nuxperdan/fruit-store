using FruitStore.API.Models;
using FruitStore.API.Store;
using FruitStore.Domain.Items;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore.API.Controllers
{
    [ApiController]
    [Route("api/fruits")]
    public class FruitsController : ControllerBase
    {
        [HttpGet, Route("{datePicked:DateTime?}")]
        public IActionResult GetFruits([FromQuery(Name = "datePicked")] DateTime? datePicked = null)
        {
            IActionResult retval = null;

            try
            {
                var fruits = FruitsStore.Instance.GetFruits();
                
                if (datePicked.HasValue) {
                    fruits = fruits.Where(f => f.DatePicked > datePicked);
                }

                var content = ConvertFruits(fruits.OrderBy(f => f.DatePicked));

                retval = Ok(content);
            }
            catch 
            {
                // Add logging here
            }

            return retval ?? StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        private IEnumerable<FruitDto> ConvertFruits(IEnumerable<Fruit> fruits)
        {
            return fruits.Select(f => new FruitDto()
            {
                Name = f.Name,
                Color = f.Color,
                HasSeeds = f.HasSeeds,
                Price = f.Price,
                Weight = f.Weight,
                DatePicked = f.DatePicked,
            });
        }
    }
}
