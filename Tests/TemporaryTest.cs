using NUnit.Framework;
using RestfulBookerApiFramework.Config;
using RestfulBookerApiFramework.Services;
using RestfulBookerApiFramework.Security;
using RestfulBookerApiFramework.Base;


namespace RestfulBookerApiFramework.Tests;

public class SettingsTest : BaseTest
{

    [Test]
    [Category("Smoke")]
    [Category("Auth")]
    public async Task Should_Reuse_Token()
    {

        var token1 = await AuthManager.GetToken();
        var token2 = await AuthManager.GetToken();

        Assert.That(token1, Is.EqualTo(token2));
    }
};