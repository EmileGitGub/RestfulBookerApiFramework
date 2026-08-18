using System.Text.Json.Serialization;

namespace RestfulBookerApiFramework.Models;

public class Booking
{
    [JsonPropertyName("firstname")]
    public string Firstname { get; set; } = string.Empty;

    [JsonPropertyName("lastname")]
    public string Lastname { get; set; } = string.Empty;

    [JsonPropertyName("totalprice")]
    public int Totalprice { get; set; }

    [JsonPropertyName("depositpaid")]
    public bool Depositpaid { get; set; }

    [JsonPropertyName("bookingdates")]
    public BookingDates BookingDates { get; set; } = new();

    [JsonPropertyName("additionalneeds")]
    public string Additionalneeds { get; set; } = string.Empty;
}