using NUnit.Framework;
using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Helpers;
using RestfulBookerApiFramework.Models;


namespace RestfulBookerApiFramework.Tests;

public class PatchBookingTests : BaseTest
{
    [Test]
    public async Task Should_Partially_Update_A_Booking()
    {
        var booking = TestDataFactory.CreateBooking();
        var createdBooking = await BookingService.CreateBooking(booking);

        var patchRequest = new PatchBookingRequest
        {
            Firstname = "Updated"
        };

        var patchedBooking = await BookingService.PatchBooking(
            createdBooking.Bookingid,
            patchRequest
        );

        Assert.Multiple(() =>
        {
            Assert.That(
                patchedBooking.Firstname,
                Is.EqualTo(patchRequest.Firstname)
            );

            Assert.That(
                patchedBooking.Lastname,
                Is.EqualTo(booking.Lastname)
            );

            Assert.That(
                patchedBooking.Totalprice,
                Is.EqualTo(booking.Totalprice)
            );

            Assert.That(
                patchedBooking.Depositpaid,
                Is.EqualTo(booking.Depositpaid)
            );

            Assert.That(
                patchedBooking.Additionalneeds,
                Is.EqualTo(booking.Additionalneeds)
            );

            Assert.That(
                patchedBooking.BookingDates.Checkin,
                Is.EqualTo(booking.BookingDates.Checkin)
            );

            Assert.That(
                patchedBooking.BookingDates.Checkout,
                Is.EqualTo(booking.BookingDates.Checkout)
            );
        });
    }
}