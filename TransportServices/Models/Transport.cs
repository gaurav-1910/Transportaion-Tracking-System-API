using System.ComponentModel.DataAnnotations;

namespace Transportaion_Tracking_System_API.Models
{
    public class Transport
    {
        [Key]
        public int TransportId { get; set; }
        [Required]
        public Vehicle AssignedVehicle { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartureLocation { get; set; }

        [Required]
        [StringLength(100)]
        public string Destination { get; set; }

        [Required]
        public DateTime EstimatedArrivalTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(100)]
        public string GoodsType { get; set; }
    }
}
