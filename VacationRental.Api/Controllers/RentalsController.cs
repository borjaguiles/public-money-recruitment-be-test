using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Api.Models;
using VacationRental.Domain;
using VacationRental.Domain.Commands.RentalCreation;
using VacationRental.Domain.Queries.GetRental;
using VacationRental.Domain.Repositories;
using VacationRental.Infrastructure;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly RentalCreationCommandHandler _rentalCreationCommandHandler;
        private readonly GetRentalQueryHandler _getRentalQueryHandler;

        public RentalsController(IRentalRepository rentalRepository)
        {
            _rentalCreationCommandHandler = new RentalCreationCommandHandler(rentalRepository);
            _getRentalQueryHandler = new GetRentalQueryHandler(rentalRepository);
        }

        [HttpGet]
        [Route("{rentalId:int}")]
        public RentalViewModel Get(int rentalId)
        {
            var response = _getRentalQueryHandler.GetRental(new GetRentalQueryRequest(rentalId));

            return new RentalViewModel()
            {
                Id = response.Rental.Id,
                Units = response.Rental.Units
            };
        }

        [HttpPost]
        public ResourceIdViewModel Post(RentalBindingModel request)
        {
            var key = _rentalCreationCommandHandler.CreateRental(request.ToDomain());

            return new ResourceIdViewModel()
            {
                Id = key.Id
            };
        }
    }
}
