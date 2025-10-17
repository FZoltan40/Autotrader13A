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
    }
}
