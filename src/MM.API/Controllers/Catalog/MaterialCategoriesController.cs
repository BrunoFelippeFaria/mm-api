using System.Threading.Tasks;

using Mediator;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MM.Application.Catalog.MaterialCategories.Commands.Create;
using MM.Application.Catalog.MaterialCategories.Commands.Delete;
using MM.Application.Catalog.MaterialCategories.Commands.Update;
using MM.Application.Catalog.MaterialCategories.Queries.GetAll;
using MM.Application.Catalog.MaterialCategories.Queries.GetById;

namespace MM.API.Controllers.Catalog;

[ApiController]
[Route("api/v1/catalog/materials/categories")]
[Authorize]
public class MaterialsCategoryController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _mediator.Send(new GetAllMaterialCategoriesQuery());
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _mediator.Send(new GetMaterialCategoryByIdQuery(id));
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMaterialCategoryCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateMaterialCategoryCommand command)
    {
        await _mediator.Send(command with { Id = id });
        return NoContent();
    }

    [HttpPatch("{id}/delete")]
    public async Task<IActionResult> Delete(int id, [FromBody] DeleteMaterialCategoryCommand command)
    {
        await _mediator.Send(command with { Id = id });
        return NoContent();
    }
}