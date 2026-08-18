using RestfulBookerApiFramework.Models;

namespace RestfulBookerApiFramework.Helpers;

public static class TestDataFactory
{
    public static Booking CreateBooking()
    {
        return new Booking
        {
            Firstname = "Emile",
            Lastname = "Koopman",
            Totalprice = 1500,
            Depositpaid = true,
            BookingDates = new BookingDates
            {
                Checkin = "2026-09-01",
                Checkout = "2026-09-05"
            },
            Additionalneeds = "Breakfast"

        };
    }
}