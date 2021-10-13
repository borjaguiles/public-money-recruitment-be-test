using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using VacationRental.Domain.Commands.RentalCreation;
using VacationRental.Domain.Entities;
using VacationRental.Domain.Repositories;
using Xunit;

namespace VacationRental.Domain.Tests
{
    public class RentalCreationCommandHandlerShould
    {
        private IRentalRepository _rentalRepository;
        private RentalCreationCommandHandler _handler;

        public RentalCreationCommandHandlerShould()
        {
            _rentalRepository = Substitute.For<IRentalRepository>();
            _handler = new RentalCreationCommandHandler(_rentalRepository);
        }

        [Fact]
        public async Task CreateANewRentalAndReturnItsIdentifier()
        {
            var expectedRental = new Rental(5);
            expectedRental.Id = 1;
            _rentalRepository.Save(Arg.Any<Rental>()).Returns(1);
            //Act
            var result = await _handler.Handle(new RentalCreationCommandRequest(expectedRental.Units), CancellationToken.None);
            //Assert
            _rentalRepository.Received(1).Save(Arg.Is<Rental>(rental => rental.Units == expectedRental.Units));
            result.Id.Should().Be(expectedRental.Id);
        }
    }
}
