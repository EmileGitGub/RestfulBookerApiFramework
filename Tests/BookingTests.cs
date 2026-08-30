using NUnit.Framework;
using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Services;
using RestfulBookerApiFramework.Helpers;

namespace RestfulBookerApiFramework.Tests;

[TestFixture]
public class BookingTests : BaseTest
{
    [Test]
    [Category("Smoke")]
    [Category("Auth")]
    public async Task Should_Create_A_Booking()
    {
        var booking = TestDataFactory.CreateBooking();

        var result = await BookingService.CreateBooking(booking);

        Assert.Multiple(() =>
        {
            Assert.That(result.Bookingid, Is.GreaterThan(0));
            Assert.That(result.Booking.Firstname, Is.EqualTo("Emile"));
            Assert.That(result.Booking.Lastname, Is.EqualTo("Koopman"));
            Assert.That(result.Booking.Totalprice, Is.EqualTo(1500));
        });
    }

    [Test]
    [Category("Booking")]
    public async Task Should_Get_A_Booking()
    {
        var booking = TestDataFactory.CreateBooking();

        var created = await BookingService.CreateBooking(booking);

        var retrieved = await BookingService.GetBooking(created.Bookingid);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(retrieved.Firstname, Is.EqualTo(booking.Firstname));
            Assert.That(retrieved.Lastname, Is.EqualTo(booking.Lastname));
            Assert.That(retrieved.Totalprice, Is.EqualTo(booking.Totalprice));
            Assert.That(retrieved.Depositpaid, Is.EqualTo(booking.Depositpaid));
        }
    }
}