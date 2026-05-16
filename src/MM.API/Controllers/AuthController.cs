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
        await _mediator.Send(command);
        return NoContent();
    }
}