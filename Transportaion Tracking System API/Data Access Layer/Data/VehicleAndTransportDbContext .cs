using Microsoft.EntityFrameworkCore;
using Transportaion_Tracking_System_API.Models;

namespace Transportaion_Tracking_System_API.Data
{
    public class VehicleAndTransportDbContext : DbContext
    {
        public VehicleAndTransportDbContext(DbContextOptions options) : base(options) 
        {
        
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Transport> Transports { get; set; }
    }
}
