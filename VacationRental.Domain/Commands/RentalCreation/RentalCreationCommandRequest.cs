namespace VacationRental.Domain.Commands.RentalCreation
{
    public class RentalCreationCommandRequest
    {
        public int Units { get; }

        public RentalCreationCommandRequest(int units)
        {
            Units = units;
        }
    }
}