using System.Collections.Generic;
using VacationRental.Domain;
using VacationRental.Domain.Entities;
using VacationRental.Domain.Exceptions;
using VacationRental.Domain.Repositories;

namespace VacationRental.Infrastructure
{
    public class RentalRepository : IRentalRepository
    {
        private readonly IDictionary<int, Rental> _rentals;

        public RentalRepository()
        {
            _rentals = new Dictionary<int, Rental>();
        }

        public int Save(Rental rental)
        {
            rental.Id = _rentals.Keys.Count + 1;
            _rentals.Add(rental.Id, rental);
            return rental.Id;
        }

        public Rental Get(int rentalId)
        {
            if (!_rentals.ContainsKey(rentalId))
                throw new RentalNotFoundException();

            return _rentals[rentalId];
        }
    }
}