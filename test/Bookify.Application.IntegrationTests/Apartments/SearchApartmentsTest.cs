using Bookify.Application.Apartments.SearchApartments;
using Bookify.Application.IntegrationTests.Infrastructure;
using FluentAssertions;

namespace Bookify.Application.IntegrationTests.Apartments;

public class SearchApartmentsTest : BaseIntegrationTest
{
    public SearchApartmentsTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task SearchApartments_ShouldReturnEmptyList_WhenDateRangeIsInvalid()
    {
        //arrange
        var query = new SearchApartmentsQuery(
            new DateOnly(2024, 1, 10),
            new DateOnly(2024, 1, 1)
        );

        //act
        var result = await Sender.Send(query);

        //assert

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEmpty();
    }

    [Fact]
    public async Task SearchApartments_ShouldReturnApartments_WhenDateRangeIsValid()
    {
        //arrange
        var query = new SearchApartmentsQuery(
            new DateOnly(2024, 1, 1),
            new DateOnly(2024, 1, 10)
        );

        //act
        var result = await Sender.Send(query);

        //assert

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeEmpty();
    }
}
