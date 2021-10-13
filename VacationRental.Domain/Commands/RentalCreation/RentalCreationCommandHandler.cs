using System.Collections.Generic;

namespace VacationRental.Domain.Commands.RentalCreation
{
    public class RentalCreationCommandHandler
    {
        private readonly IDictionary<int, Rental> _rentals;

        public RentalCreationCommandHandler(IDictionary<int, Rental> rentals)
        {
            _rentals = rentals;
        }

        public RentalCreationCommandResponse CreateRental(RentalCreationCommandRequest request)
        {
            var id = _rentals.Keys.Count + 1;

            _rentals.Add(id, new Rental(id, request.Units));
            return new RentalCreationCommandResponse(id);
        }
    }
}