using System.Text.Json.Serialization;

namespace RestfulBookerApiFramework.Models;

public class BookingDates
{
    [JsonPropertyName("checkin")]
    public string Checkin { get; set; } = string.Empty;

    [JsonPropertyName("checkout")]
    public string Checkout { get; set; } = string.Empty;
}