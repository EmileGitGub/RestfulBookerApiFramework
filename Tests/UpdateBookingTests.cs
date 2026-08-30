using NUnit.Framework;
using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Helpers;

namespace RestfulBookerApiFramework.Tests;

public class UpdateBookingTests : BaseTest
{
    [Test]
    [Category("Booking")]
    public async Task Should_Update_A_Booking()
    {
        // Arrange
        var booking = TestDataFactory.CreateBooking();

        var createdBooking = await BookingService.CreateBooking(booking);

        booking.Firstname = "Updated";
        booking.Lastname = "Customer";
        booking.Totalprice = 2000;
        booking.Additionalneeds = "Lunch";

        // Act
        await BookingService.UpdateBooking(
            createdBooking.Bookingid,
            booking);

        var retrievedBooking = await BookingService.GetBooking(
            createdBooking.Bookingid);

        // Assert
        BookingAssertions.AssertBooking(
            retrievedBooking,
            booking);
    }

}