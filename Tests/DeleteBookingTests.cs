using System.Net;
using NUnit.Framework;
using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Helpers;

namespace RestfulBookerApiFramework.Test;

public class DeleteBookingTest : BaseTest
{
    [Test]
    public async Task Should_Delete_A_Booking()
    {
        var booking = TestDataFactory.CreateBooking();

        var createdBooking = await BookingService.CreateBooking(booking);

        await BookingService.DeleteBooking(
            createdBooking.Bookingid);

        var response = await BookingService.GetBookingResponse(
            createdBooking.Bookingid);

        Assert.That(
            response.StatusCode,
            Is.EqualTo(HttpStatusCode.NotFound));
    }
}
