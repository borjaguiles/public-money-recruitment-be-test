using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Api.Models;
using VacationRental.Domain;
using VacationRental.Domain.Commands.RentalCreation;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IDictionary<int, Rental> _rentals;
        private readonly RentalCreationCommandHandler _rentalCreationCommandHandler;

        public RentalsController(IDictionary<int, Rental> rentals)
        {
            _rentals = rentals;
            _rentalCreationCommandHandler = new RentalCreationCommandHandler(rentals);
        }

        [HttpGet]
        [Route("{rentalId:int}")]
        public RentalViewModel Get(int rentalId)
        {
            if (!_rentals.ContainsKey(rentalId))
                throw new ApplicationException("Rental not found");

            var rental = _rentals[rentalId];

            return new RentalViewModel()
            {
                Id = rental.Id,
                Units = rental.Units
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
