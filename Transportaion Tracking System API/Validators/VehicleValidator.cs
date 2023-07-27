using FluentValidation;
using Transportaion_Tracking_System_API.Models;

namespace Transportaion_Tracking_System_API.Validators
{
    public class VehicleValidator :AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(x => x.VehicleType).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LicensePlate).NotEmpty().MaximumLength(20);
            RuleFor(x => x.DriverName).NotEmpty().MaximumLength(100);  
            RuleFor(x => x.CurrentLocation).NotEmpty().MaximumLength(200); 
        }
    }
}
