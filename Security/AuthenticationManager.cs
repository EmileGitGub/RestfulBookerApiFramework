using RestfulBookerApiFramework.Services;

namespace RestfulBookerApiFramework.Security;

public class AuthenticationManager
{
    private readonly AuthService _authService;

    private string? _token;

    public AuthenticationManager(AuthService authService)
    {
        _authService = authService;
    }

    public async Task<string> GetToken()
    {

        if (!string.IsNullOrEmpty(_token))
        {
            return _token;
        }

        _token = await _authService.GetToken();
        return _token;
    }

    public void ClearToken()
    {
        _token = null;
    }
}