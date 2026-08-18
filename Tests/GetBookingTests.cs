using NUnit.Framework;
using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Helpers;
using RestfulBookerApiFramework.Models;
using RestfulBookerApiFramework.Services;

namespace RestfulBookerApiFramework.Tests;

public class GetBookingTests : BaseTest
{
    [Test]
    public async Task Should_Get_A_Booking_By_Id()
    {
        // Arrange
        var booking = TestDataFactory.CreateBooking();

        // Act
        var createdBooking = await BookingService.CreateBooking(booking);

        var retrievedBooking = await BookingService.GetBooking(createdBooking.Bookingid);

        BookingAssertions.AssertBooking(
            retrievedBooking,
            booking);
    }
}