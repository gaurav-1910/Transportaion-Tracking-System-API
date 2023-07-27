namespace Transportaion_Tracking_System_API.Models
{
    public static class TransportUtils
    {
        // A constant speed assumed for the simulation (in km/h)
        private const double ConstantSpeed = 60.0;

        // Method to simulate vehicle movement and update EstimatedArrivalTime
        public static void VehicleMovementSimulation(Transport transport)
        {
            // Calculate distance between DepartureLocation and Destination (you can use real distance APIs in a real-world scenario)
            // For simplicity, let's assume the distance is 100 km
            double distanceInKm = 100.0;

            // Calculate estimated travel time in hours
            double estimatedTravelTimeInHours = distanceInKm / ConstantSpeed;

            // Set the EstimatedArrivalTime
            transport.EstimatedArrivalTime = DateTime.Now.AddHours(estimatedTravelTimeInHours);
        }
    }

}
