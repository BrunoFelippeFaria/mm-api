using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MM.API.Controllers.Catalog;

[ApiController]
[Route("api/v1/catalog/materials")]
[Authorize]
public class MaterialsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult Create()
    {
        throw new NotImplementedException();
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