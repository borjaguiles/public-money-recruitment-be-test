using VacationRental.Domain.Entities;

namespace VacationRental.Domain.Queries.GetRental
{
    public class GetRentalQueryResponse
    {
        public Rental Rental { get; }

        public GetRentalQueryResponse(Rental rental)
        {
            Rental = rental;
        }
    }
}