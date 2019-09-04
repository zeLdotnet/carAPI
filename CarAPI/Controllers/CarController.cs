using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarDbContext _context;

        public CarController(CarDbContext context)
        {
            _context = context;
        }

        
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var carList = await _context.Car.ToListAsync();
            return carList;
        }



        // make method API method to search a car by make
        [HttpGet("{Make}")]
        public ActionResult<List<Car>> GetCarByMake(string make)
        {
            var found = _context.Car.Where(c => c.Make == make).ToList();
            if (found == null)
            {
                return NotFound();
            }
            return found;
        }

        //[HttpPost("{Make}")]
        //public async Task<ActionResult<Car>> PutMake(string make, Car car)
        //{
        //    var found = await _context.Car.FindAsync(make);
        //    if (found.Make != make)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(car).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}