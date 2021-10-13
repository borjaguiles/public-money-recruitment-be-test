using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using VacationRental.Api.Models;
using Xunit;

namespace VacationRental.Api.Tests.Queries
{
    [Collection("Integration")]
    public class RentalControllerShould
    {
        private readonly IntegrationFixture _fixture;
        private HttpClient _client;

        public RentalControllerShould(IntegrationFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.Client;
        }
        [Fact]
        public async Task RetrieveAnExistingRental()
        {
            //Arrange
            var expectedRental = new RentalViewModel()
            {
                Id = 1,
                Units = 2
            };
            _fixture.AddRental(expectedRental.Units);
            //Act
            var result = await _client.GetAsync($"/api/v1/rentals/{expectedRental.Id}");
            var json = await result.Content.ReadAsStringAsync();
            var resultRental = JsonConvert.DeserializeObject<RentalViewModel>(json);
            //Assert
            resultRental.Should().BeEquivalentTo(expectedRental);
        }

        [Fact]
        public async Task SayThatItDidntFindANonExistentRental()
        {
            //Act
            var result = await _client.GetAsync($"/api/v1/rentals/{1}");
            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
