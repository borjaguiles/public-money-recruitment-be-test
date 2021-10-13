using MediatR;

namespace VacationRental.Domain.Commands.RentalCreation
{
    public class RentalCreationCommandRequest : IRequest<RentalCreationCommandResponse>
    {
        public int Units { get; }

        public RentalCreationCommandRequest(int units)
        {
            Units = units;
        }
    }
}