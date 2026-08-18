using NUnit.Framework;
using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Security;
using RestfulBookerApiFramework.Services;

namespace RestfulBookerApiFramework.Base;

public class BaseTest
{
    protected ApiClient Api = null!;
    protected AuthService AuthService = null!;

    protected AuthenticationManager AuthManager = null!;

    protected BookingService BookingService = null!;

    [SetUp]
    public void SetUp()
    {
        Api = new ApiClient();
        AuthService = new AuthService(Api);
        AuthManager = new AuthenticationManager(AuthService);
        BookingService = new BookingService(Api, AuthManager);
    }
}