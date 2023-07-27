using System.ComponentModel.DataAnnotations;

namespace Transportaion_Tracking_System_API.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        [StringLength(50)]
        public string VehicleType { get; set; }

        [Required]
        [StringLength(20)]
        public string LicensePlate { get; set; }

        [Required]
        [StringLength(100)]
        public string DriverName { get; set; }

        [StringLength(200)]
        public string CurrentLocation { get; set; }
    }
}
