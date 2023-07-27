namespace Transportaion_Tracking_System_API.Models
{
    public class AddVehicleRequest
    {
        public string VehicleType { get; set; }
        public string LicensePlate { get; set;}
        public string DriverName { get; set; }
        public string CurrentLocation { get; set;}
    }
}
