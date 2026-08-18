using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Models;
using RestfulBookerApiFramework.Security;

namespace RestfulBookerApiFramework.Services;

public class BookingService
{
    private readonly ApiClient _api;

    private readonly AuthenticationManager _authManager;

    private async Task<Dictionary<string, string>> GetAuthHeaders()
    {
        var token = await _authManager.GetToken();

        return new Dictionary<string, string>
        {
            {"Cookie", $"token={token}"}
        };
    }

    public BookingService(ApiClient api, AuthenticationManager authManager)
    {
        _api = api;
        _authManager = authManager;
    }

    public async Task<CreateBookingResponse> CreateBooking(Booking booking)
    {
        return await _api.PostAsync<Booking, CreateBookingResponse>(
            "/booking",
            booking);
    }

    public async Task<Booking> GetBooking(int bookingId)
    {
        return await _api.GetAsync<Booking>(
            $"/booking/{bookingId}");
    }

    public async Task<Booking> UpdateBooking(
        int bookingId,
        Booking booking)
    {
        var headers = await GetAuthHeaders();

        return await _api.PutAsync<Booking, Booking>(
            $"/booking/{bookingId}",
            booking,
            headers);
    }

    public async Task<Booking> PatchBooking(
        int bookingId,
        PatchBookingRequest booking
    )
    {
        var headers = await GetAuthHeaders();

        return await _api.PatchAsync<PatchBookingRequest, Booking>(
            $"/booking/{bookingId}",
            booking,
            headers
        );
    }

    public async Task<HttpResponseMessage> GetBookingResponse(
        int bookingId)
    {
        return await _api.GetResponseAsync(
            $"/booking/{bookingId}");
    }

    public async Task DeleteBooking(int bookingId)
    {
        var headers = await GetAuthHeaders();

        await _api.DeleteAsync(
            $"/booking/{bookingId}",
            headers);
    }

    public async Task<HttpResponseMessage> UpdateBookingResponse(
        int bookingId,
        Booking booking,
        string token
    )
    {
        var headers = new Dictionary<string, string>
        {
            {"Cookie", $"token={token}"}
        };

        return await _api.SendRequestAsync(
            HttpMethod.Put,
            $"/booking/{bookingId}",
            booking,
            headers
        );
    }
}