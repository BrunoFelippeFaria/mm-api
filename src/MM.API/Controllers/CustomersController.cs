using Mediator;

using Microsoft.AspNetCore.Mvc;

using MM.Application.Sales.Customers.Queries.GetAll;

namespace MM.API.Controllers;

[ApiController]
[Route("api/v1/sales/customers")]
public class CustomersController (IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(customers);
    }
}