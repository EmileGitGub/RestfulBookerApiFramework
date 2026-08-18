namespace RestfulBookerApiFramework.Models;

public class CreateBookingResponse
{
    public int Bookingid { get; set; }
    public Booking Booking { get; set; } = new();
}