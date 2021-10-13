using System;
using MediatR;

namespace VacationRental.Domain.Queries.GetRental
{
    public class GetRentalQueryRequest : IRequest<GetRentalQueryResponse>
    {
        public int RentalId { get; }

        public GetRentalQueryRequest(int rentalId)
        {
            RentalId = rentalId;
        }
    }
}