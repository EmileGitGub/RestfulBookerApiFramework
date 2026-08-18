using NUnit.Framework;
using RestfulBookerApiFramework.Models;

namespace RestfulBookerApiFramework.Helpers;

public static class BookingAssertions
{
    public static void AssertBooking(
        Booking actual,
        Booking expected)
    {
        Assert.Multiple(() =>
        {
            Assert.That(
                actual.Firstname,
                Is.EqualTo(expected.Firstname));

            Assert.That(
                actual.Lastname,
                Is.EqualTo(expected.Lastname));

            Assert.That(
                actual.Totalprice,
                Is.EqualTo(expected.Totalprice));

            Assert.That(
                actual.Depositpaid,
                Is.EqualTo(expected.Depositpaid));

            Assert.That(
                actual.Additionalneeds,
                Is.EqualTo(expected.Additionalneeds));

            Assert.That(
                actual.BookingDates.Checkin,
                Is.EqualTo(expected.BookingDates.Checkin));

            Assert.That(
                actual.BookingDates.Checkout,
                Is.EqualTo(expected.BookingDates.Checkout));
        });
    }
}