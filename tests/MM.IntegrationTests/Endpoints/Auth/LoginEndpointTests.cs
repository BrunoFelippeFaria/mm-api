using System.Net;
using System.Net.Http.Json;

using FluentAssertions;

using MM.IntegrationTests.Infrastructure;

namespace MM.IntegrationTests.Endpoints.Auth;

public class LoginEndpointTests(ApiFactory factory) : IClassFixture<ApiFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Theory]
    [InlineData("teste@email.com")]
    [InlineData("admin")]
    public async Task Login_ShouldReturn401_WithInvalidCredentials(string email)
    {
        var payload = new { Email = email, Password = "Wrong" };

        var response = await _client.PostAsJsonAsync("api/auth/login", payload);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Login_ShouldReturn204_WithValidCredentials()
    {
        var payload = new { Email = "admin", Password = "admin" };

        var response = await _client.PostAsJsonAsync("api/auth/login", payload);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Theory]
    [InlineData("", "password")]
    [InlineData("notAnEmail", "1234")]
    [InlineData("test@email.com", "")]
    [InlineData("test@email.com", "123")]
    public async Task Login_ShouldReturn400_WithInvalidPayload(string email, string password)
    {
        var payload = new { Email = email, Password = password };

        var response = await _client.PostAsJsonAsync("api/auth/login", payload);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

}