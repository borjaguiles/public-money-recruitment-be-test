namespace VacationRental.Domain.Commands.RentalCreation
{
    public class RentalCreationCommandResponse
    {
        public int Id { get; set; }

        public RentalCreationCommandResponse(int id)
        {
            Id = id;
        }
    }
}