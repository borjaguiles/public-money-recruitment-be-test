using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
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
        private readonly IMediator _mediator;

        public RentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{rentalId:int}")]
        public async Task<RentalViewModel> Get(int rentalId)
        {
            var response = await _mediator.Send(new GetRentalQueryRequest(rentalId));

            return new RentalViewModel()
            {
                Id = response.Rental.Id,
                Units = response.Rental.Units
            };
        }

        [HttpPost]
        public async Task<ResourceIdViewModel> Post(RentalBindingModel request)
        {
            var key = await _mediator.Send(request.ToDomain());

            return new ResourceIdViewModel()
            {
                Id = key.Id
            };
        }
    }
}
