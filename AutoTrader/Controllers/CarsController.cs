using AutoTrader.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Car> GetAllRecord()
        {
            using (var context = new CarDbContext())
            {
                var cars = context.Cars.ToList();

                if (cars != null)
                {
                    return Ok(cars);
                }

                return BadRequest(new { message = "Sikertelen lekérdezés." });
            }

        }

        [HttpPost]
        public ActionResult<Car> AddNewRecord(Car car)
        {
            using (var context = new CarDbContext())
            {
                var newCAr = new Car
                {
                    Brand = car.Brand,
                    Type = car.Type,
                    Color = car.Color,
                    Year = car.Year
                };

                if (newCAr != null)
                {
                    context.Cars.Add(newCAr);
                    context.SaveChanges();
                    return StatusCode(201, newCAr);
                }

                return BadRequest(new { message = "Sikertelen feltöltés." });
            }


        }
    }
}
