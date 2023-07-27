
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transportaion_Tracking_System_API.Data;
using Transportaion_Tracking_System_API.Models;
using Transportaion_Tracking_System_API.Validators;

namespace Transportaion_Tracking_System_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransportController : Controller
    {
        
           private readonly VehicleAndTransportDbContext dbContext;

            public TransportController(VehicleAndTransportDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            [HttpGet]
            public IActionResult GetAllTransports()
            {
                var transports = dbContext.Transports.Include(t => t.AssignedVehicle).ToList();
                return Ok(transports);
            }

            [HttpGet("{id}")]
            public IActionResult GetTransportById(int id)
            {
                var transport = dbContext.Transports.Include(t => t.AssignedVehicle).FirstOrDefault(t => t.TransportId == id);
                if (transport == null)
                {
                    return NotFound();
                }
                return Ok(transport);
            }

        [HttpPost("addOrUpdate")]
        public IActionResult AddOrUpdateTransport([FromBody] Transport transport)
        {
            
            var validator = new TransportValidator();
            var validationResult = validator.Validate(transport);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (transport.TransportId == 0)
            {
                // It's a new transport
                dbContext.Transports.Add(transport);
            }
            else
            {
                var existingTransport = dbContext.Transports.Find(transport.TransportId);
                if (existingTransport == null)
                {
                    return NotFound();
                }

                // It's an existing transport, so update it
                existingTransport.AssignedVehicle = transport.AssignedVehicle;
                existingTransport.DepartureLocation = transport.DepartureLocation;
                existingTransport.Destination = transport.Destination;
                existingTransport.EstimatedArrivalTime = transport.EstimatedArrivalTime;
                existingTransport.Status = transport.Status;
                existingTransport.GoodsType = transport.GoodsType;
            }

            dbContext.SaveChanges();

            return Ok(transport);
        }
    

        [HttpPost("{id}/start")]
            public IActionResult StartTransport(int id)
            {
                var transport = dbContext.Transports.Find(id);
                if (transport == null)
                {
                    return NotFound();
                }


                // Set the status to "In-Transit"
                transport.Status = "In-Transit";

                // Simulate vehicle movement and update EstimatedArrivalTime
                TransportUtils.VehicleMovementSimulation(transport);

               dbContext.SaveChanges();

                return Ok(transport);
            
        }

    }
}
