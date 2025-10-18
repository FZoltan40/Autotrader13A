using AutoTrader.Models;
using AutoTrader.Models.Dtos;
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

        [HttpGet("byId")]
        public ActionResult<Car> GetRecordById(int id) 
        {
            using (var context = new CarDbContext()) 
            {
                var car = context.Cars.FirstOrDefault(car => car.Id == id);

                if (car != null)
                {
                    return Ok(new { message = "Sikeres lekérdezés", result = car });
                }

                return NotFound(new { meassage = "Nincs ilyen id!"});
            }
            
        }

        [HttpDelete]
        public ActionResult DeleteRecord(int id) 
        {
            using (var context = new CarDbContext()) 
            {
                var car = context.Cars.FirstOrDefault(car => car.Id == id);

                if (car != null) 
                { 
                    context.Cars.Remove(car);
                    context.SaveChanges();
                    return Ok(new { message = "Sikeres törlés." });
                }

                return NotFound(new { meassage = "Nincs mit törölni!" });
            }
        }

        [HttpPut]
        public ActionResult PutRecord(int id, UpdateCarDto updateCarDto) 
        {
            using (var context = new CarDbContext()) 
            {
                var exitstingCar  = context.Cars.FirstOrDefault(car => car.Id==id);

                if (exitstingCar != null)
                {
                    exitstingCar.Brand = updateCarDto.Brand;
                    exitstingCar.Type = updateCarDto.Type;
                    exitstingCar.Color = updateCarDto.Color;
                    exitstingCar.Year = updateCarDto.Year;

                    context.Cars.Update(exitstingCar);
                    context.SaveChanges();

                    return Ok(new { message = "Sikeres frisítés." });
                }

                return NotFound(new { meassage = "Nincs mit frissíteni!" });
            }
        }
    }
}
