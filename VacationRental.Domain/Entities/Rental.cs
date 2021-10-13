namespace VacationRental.Domain.Entities
{
    public class Rental
    {
        public int Id { get; set; }

        public int Units { get; }

        public Rental(int units)
        {
            Units = units;
        }
    }
}