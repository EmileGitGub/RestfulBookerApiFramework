using System.Net;
using NUnit.Framework;
using RestfulBookerApiFramework.Base;

namespace RestfulBookerApiFramework.Tests;

[TestFixture]
public class PingTest : BaseTest
{
    [Test]
    [Category("Smoke")]
    public async Task Ping_Should_Return_201()
    {   
        // Act
        var response = await Api.GetResponseAsync("/ping");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }
}