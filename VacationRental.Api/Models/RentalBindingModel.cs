using VacationRental.Api.Controllers;
using VacationRental.Domain.Commands.RentalCreation;

namespace VacationRental.Api.Models
{
    public class RentalBindingModel
    {
        public int Units { get; set; }

        public RentalCreationCommandRequest ToDomain()
        {
            return new RentalCreationCommandRequest(Units);
        }
    }
}
