using Mediator;

using Microsoft.AspNetCore.Mvc;

using MM.Application.Auth.Commands.Login;

namespace MM.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController (IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        string token = await _mediator.Send(command);

        Response.Cookies.Append("access_token", token, new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Lax,
            Expires = DateTimeOffset.UtcNow.AddDays(7),
            Path = "/",
        });

        return NoContent();
    }
}