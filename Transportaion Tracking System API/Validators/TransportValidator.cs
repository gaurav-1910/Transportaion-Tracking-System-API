using FluentValidation;
using Transportaion_Tracking_System_API.Models;

namespace Transportaion_Tracking_System_API.Validators
{
    public class TransportValidator : AbstractValidator<Transport>
    {
        public TransportValidator()
        {
            RuleFor(x => x.AssignedVehicle).NotNull();
            RuleFor(x => x.DepartureLocation).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Destination).NotEmpty().MaximumLength(100);
            RuleFor(x => x.EstimatedArrivalTime).NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(x => x.Status).NotEmpty().MaximumLength(50);
            RuleFor(x => x.GoodsType).MaximumLength(100);
        }
    }
}
