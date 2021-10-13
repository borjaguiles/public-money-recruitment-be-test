using System.Collections.Generic;
using VacationRental.Domain.Entities;
using VacationRental.Domain.Repositories;

namespace VacationRental.Domain.Commands.RentalCreation
{
    public class RentalCreationCommandHandler
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalCreationCommandHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public RentalCreationCommandResponse CreateRental(RentalCreationCommandRequest request)
        {
            var id = _rentalRepository.Save(new Rental(request.Units));
            return new RentalCreationCommandResponse(id);
        }
    }
}