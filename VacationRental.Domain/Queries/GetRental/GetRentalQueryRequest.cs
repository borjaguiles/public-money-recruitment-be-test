using System;

namespace VacationRental.Domain.Queries.GetRental
{
    public class GetRentalQueryRequest
    {
        public int RentalId { get; }

        public GetRentalQueryRequest(int rentalId)
        {
            RentalId = rentalId;
        }
    }
}