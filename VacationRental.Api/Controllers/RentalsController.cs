using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Api.Models;
using VacationRental.Domain;
using VacationRental.Domain.Commands.RentalCreation;
using VacationRental.Domain.Entities;
using VacationRental.Domain.Repositories;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalCreationCommandHandler _rentalCreationCommandHandler;

        public RentalsController(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
            _rentalCreationCommandHandler = new RentalCreationCommandHandler(rentalRepository);
        }

        [HttpGet]
        [Route("{rentalId:int}")]
        public RentalViewModel Get(int rentalId)
        {
            var rental = _rentalRepository.Get(rentalId);

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
