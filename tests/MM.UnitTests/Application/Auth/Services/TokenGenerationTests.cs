using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using FluentAssertions;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using MM.Application.Auth.Dtos;
using MM.Application.Auth.Services;

namespace MM.UnitTests.Application.Auth.Services;

public class TokenGenerationTests
{
    private readonly IConfiguration _configuration;
    private readonly TokenGenerator _tokenGenerator;

    private static UserAuthDto MakeUser() => new()
    {
        Id = 1,
        Name = "user",
        Email = "teste@email.com",
        Hash = "hash",
    };

    public TokenGenerationTests()
    {
        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "Jwt:Key", "fake-secret-key-for-unit-tests-only" },
                { "Jwt:Issuer", "test-issuer" },
                { "Jwt:audience", "test-audience" }
            })
            .Build();

        _tokenGenerator = new(_configuration);
    }

    [Fact]
    public void GenerateJwtToken_ShouldReturnNonEmptyString()
    {
        var token = _tokenGenerator.GenerateJwtToken(MakeUser());
        token.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GenerateJwtToken_ShouldReturnValidJwtFormat()
    {
        var token = _tokenGenerator.GenerateJwtToken(MakeUser());
        var parts = token.Split('.');
        parts.Should().HaveCount(3);
    }

    [Fact]
    public void GenerateJwtToken_ShouldContainCorrectClaims()
    {
        var user = MakeUser();
        var token = _tokenGenerator.GenerateJwtToken(user);

        var handler = new JwtSecurityTokenHandler();
        var parsed = handler.ReadJwtToken(token);

        parsed.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)
            .Value.Should().Be(user.Id.ToString());

        parsed.Claims.First(c => c.Type == ClaimTypes.Name)
            .Value.Should().Be(user.Name);

        parsed.Claims.First(c => c.Type == ClaimTypes.Email)
            .Value.Should().Be(user.Email);
    }

    [Fact]
    public void GenerateJwtToken_ShouldUseConfiguredIssuerAndAudience()
    {
        var token = _tokenGenerator.GenerateJwtToken(MakeUser());
        var parsed = new JwtSecurityTokenHandler().ReadJwtToken(token);

        parsed.Issuer.Should().Be("test-issuer");
        parsed.Audiences.Should().Contain("test-audience");
    }

    [Fact]
    public void GenerateJwtToken_ShouldExpireInSevenDays()
    {
        var before = DateTime.UtcNow.AddDays(7);
        var token = _tokenGenerator.GenerateJwtToken(MakeUser());
        var after = DateTime.UtcNow.AddDays(7);

        var parsed = new JwtSecurityTokenHandler().ReadJwtToken(token);

        parsed.ValidTo.Should().BeCloseTo(DateTime.UtcNow.AddDays(7), TimeSpan.FromSeconds(10));
    }

    [Fact]
    public void GenerateJwtToken_ShouldBeValidWithCorrectKey()
    {
        var token = _tokenGenerator.GenerateJwtToken(MakeUser());

        var validationParams = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fake-secret-key-for-unit-tests-only")),
            ValidateIssuer = true,
            ValidIssuer = "test-issuer",
            ValidateAudience = true,
            ValidAudience = "test-audience",
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        var handler = new JwtSecurityTokenHandler();

        var ex = Record.Exception(() => handler.ValidateToken(token, validationParams, out _));

        ex.Should().BeNull();
    }

    [Fact]
    public void GenerateJwtToken_ShouldBeInvalidWithWrongKey()
    {
        var token = _tokenGenerator.GenerateJwtToken(MakeUser());

        var validationParams = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("wrong-secret-key-for-this-test-only")),
            ValidateIssuer = true,
            ValidIssuer = "test-issuer",
            ValidateAudience = true,
            ValidAudience = "test-audience",
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        var handler = new JwtSecurityTokenHandler();

        var act = () => handler.ValidateToken(token, validationParams, out _);

        act.Should().Throw<SecurityTokenSignatureKeyNotFoundException>();
    }

    [Fact]
    public void GenerateJwtToken_ShouldThrow_WhenJwtKeyIsMissing()
    {
        var configWithoutKey = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "Jwt:Issuer", "test-issuer" },
                { "Jwt:audience", "test-audience" }
            })
            .Build();

        var sut = new TokenGenerator(configWithoutKey);

        var act = () => sut.GenerateJwtToken(MakeUser());

        act.Should().Throw<ArgumentNullException>();
    }
}