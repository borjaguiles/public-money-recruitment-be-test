using VacationRental.Domain.Entities;

namespace VacationRental.Domain.Repositories
{
    public interface IRentalRepository
    {
        int Save(Rental rental);
        Rental Get(int rentalId);
    }
}