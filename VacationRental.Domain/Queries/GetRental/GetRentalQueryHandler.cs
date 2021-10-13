using VacationRental.Domain.Repositories;

namespace VacationRental.Domain.Queries.GetRental
{
    public class GetRentalQueryHandler
    {
        private readonly IRentalRepository _rentalRepository;

        public GetRentalQueryHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public GetRentalQueryResponse GetRental(GetRentalQueryRequest request)
        {
            var rental = _rentalRepository.Get(request.RentalId);
            return new GetRentalQueryResponse(rental);
        }
    }
}