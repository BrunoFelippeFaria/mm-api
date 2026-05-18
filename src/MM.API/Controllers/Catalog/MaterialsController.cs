using System.Threading.Tasks;

using Mediator;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MM.Application.Catalog.Materials.Commands.Create;
using MM.Application.Catalog.Materials.Queries.GetAll;
using MM.Application.Catalog.Materials.Queries.GetById;

namespace MM.API.Controllers.Catalog;

[ApiController]
[Route("api/v1/catalog/materials")]
[Authorize]
public class MaterialsController (IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materials = await _mediator.Send(new GetAllMaterialsQuery());
        return Ok(materials);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var material = await _mediator.Send(new GetMaterialByIdQuery(id));
        return Ok(material);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMaterialCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{id}/delete")]
    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}