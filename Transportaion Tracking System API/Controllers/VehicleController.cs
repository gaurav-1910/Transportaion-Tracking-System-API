

using Microsoft.AspNetCore.Mvc;
using Transportaion_Tracking_System_API.Data;
using Transportaion_Tracking_System_API.Models;
using Transportaion_Tracking_System_API.Validators;

namespace Transportaion_Tracking_System_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly VehicleAndTransportDbContext dbContext;

        public VehicleController(VehicleAndTransportDbContext  dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllVehicles()
        {
           var Vehicles = dbContext.Vehicles.ToList();
           return Ok(Vehicles);
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = dbContext.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] Vehicle newVehicle)
        {
            var validator = new VehicleValidator();
            var validationResult = validator.Validate(newVehicle);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            dbContext.Vehicles.Add(newVehicle);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetVehicleById), new { id = newVehicle.VehicleId }, newVehicle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody] Vehicle updatedVehicle)
        {
            var vehicle = dbContext.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var validator = new VehicleValidator();
            var validationResult = validator.Validate(updatedVehicle);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // Update vehicle properties
            vehicle.VehicleType = updatedVehicle.VehicleType;
            vehicle.LicensePlate = updatedVehicle.LicensePlate;
            vehicle.DriverName = updatedVehicle.DriverName;
            vehicle.CurrentLocation = updatedVehicle.CurrentLocation;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = dbContext.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            dbContext.Vehicles.Remove(vehicle);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
