using System.Threading.Tasks;

using Mediator;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MM.Application.Sales.Customers.Commands.Create;
using MM.Application.Sales.Customers.Commands.Delete;
using MM.Application.Sales.Customers.Commands.Update;
using MM.Application.Sales.Customers.Queries.GetAll;
using MM.Application.Sales.Customers.Queries.GetById;

namespace MM.API.Controllers.Sales;

[ApiController]
[Route("api/v1/sales/customers")]
[Authorize]
public class CustomersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPatch("{id}/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCustomerCommand(id));
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerCommand command)
    {
        await _mediator.Send(command with { Id = id });
        return NoContent();
    }
}