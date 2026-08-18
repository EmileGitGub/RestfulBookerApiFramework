using System.Text.Json;
using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Models;
using RestfulBookerApiFramework.Config;

namespace RestfulBookerApiFramework.Services;

public class AuthService
{
    private readonly ApiClient _api;

    public AuthService(ApiClient api)
    {
        _api = api;
    }

    public async Task<string> GetToken()
    {
        var request = new AuthRequest
        {
            Username = SettingsManager.Settings.Authentication.Username,
            Password = SettingsManager.Settings.Authentication.Password
        };

        var response = await _api.PostAsync<AuthRequest, AuthResponse>("/auth", request);

        Console.WriteLine("Calling /auth endpoint...");
        return response.Token;
    }
}