using MediatR;

namespace RentACar.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarIdCommand :IRequest
    {
        public bool Available { get; set; }
        public int CarID { get; set; }
        public int FeatureID { get; set; }
    }
}
