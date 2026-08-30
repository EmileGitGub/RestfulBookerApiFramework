using NUnit.Framework;
using RestfulBookerApiFramework.Base;
using RestfulBookerApiFramework.Models;
using RestfulBookerApiFramework.Services;

namespace RestfulBookerApiFramework.Tests;

[TestFixture]
public class AuthTests : BaseTest
{
    [Test]
    [Category("Smoke")]
    [Category("Auth")]
    public async Task Should_Generate_Authentication_Token()
    {
        var authService = new AuthService(Api);

        var token = await authService.GetToken();

        Assert.That(token, Is.Not.Null.And.Not.Empty);
    }
}