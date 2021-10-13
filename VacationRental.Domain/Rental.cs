namespace VacationRental.Domain
{
    public class Rental
    {
        public int Id { get; set; }

        public int Units { get; set; }

        public Rental(int id, int units)
        {
            Id = id;
            Units = units;
        }
    }
}