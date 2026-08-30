using System.Net;
using NUnit.Framework;
using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Helpers;

namespace RestfulBookerApiFramework.Tests;

public class AuthenticationNegativeTests : BaseTest
{
    [Test]
    [Category("Auth")]
    public async Task Should_Return_403_When_Token_Is_Invalid()
    {
        var booking = TestDataFactory.CreateBooking();

        var createdBooking = await BookingService.CreateBooking(booking);

        var invalidToken = "Invalid-token";

        booking.Firstname = "Unauthorized";

        var response  = await BookingService.UpdateBookingResponse(
            createdBooking.Bookingid,
            booking,
            invalidToken
        );

        Assert.That(
            response.StatusCode,
            Is.EqualTo(HttpStatusCode.Forbidden)
        );
    } 
}
