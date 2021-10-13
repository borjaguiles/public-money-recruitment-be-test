using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VacationRental.Domain.Entities;
using VacationRental.Domain.Repositories;

namespace VacationRental.Domain.Commands.RentalCreation
{
    public class RentalCreationCommandHandler : IRequestHandler<RentalCreationCommandRequest, RentalCreationCommandResponse>
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalCreationCommandHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<RentalCreationCommandResponse> Handle(RentalCreationCommandRequest request, CancellationToken cancellationToken)
        {
            var id = _rentalRepository.Save(new Rental(request.Units));
            return new RentalCreationCommandResponse(id);
        }
    }
}