using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VacationRental.Domain.Repositories;

namespace VacationRental.Domain.Queries.GetRental
{
    public class GetRentalQueryHandler : IRequestHandler<GetRentalQueryRequest, GetRentalQueryResponse>
    {
        private readonly IRentalRepository _rentalRepository;

        public GetRentalQueryHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<GetRentalQueryResponse> Handle(GetRentalQueryRequest request, CancellationToken cancellationToken)
        {
            var rental = _rentalRepository.Get(request.RentalId);
            return new GetRentalQueryResponse(rental);
        }
    }
}