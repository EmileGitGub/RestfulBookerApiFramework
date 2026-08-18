using System.Net;
using NUnit.Framework;
using RestfulBookerApiFramework.Base;

namespace RestfulBookerApiFramework.Tests;

public class GetBookingNegativeTests : BaseTest
{
    [Test]
    public async Task Should_Return_404_When_Booking_Does_Not_Exist()
    {
        var invalidBookingId = 999999;

        var response = await BookingService.GetBookingResponse(
            invalidBookingId
        );

        Assert.That(
            response.StatusCode,
            Is.EqualTo(HttpStatusCode.NotFound)
        );
    }
}