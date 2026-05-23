using FluentAssertions;

using MM.Application.Catalog.Materials.Commands.Delete;
using MM.Application.Catalog.Materials.Exceptions;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Domain.Catalog.Materials.Entities;
using MM.Domain.Catalog.Shared.Enums;

using NSubstitute;

namespace MM.UnitTests.Application.Catalog.Materials.Commands.Delete;

public class DeleteMaterialCommandHandlerTests
{
    private readonly IMaterialRepository _repository;
    private readonly DeleteMaterialCommandHandler _handler;

    public DeleteMaterialCommandHandlerTests()
    {
        _repository = Substitute.For<IMaterialRepository>();

        _handler = new(_repository);
    }

    [Fact]
    public void Handle_NotFound_ThrowsMaterialNotFoundException()
    {
        _repository.GetById(1).Returns((Material?)null);

        var act = async () => await _handler.Handle(new DeleteMaterialCommand(1), default);

        act.Should().ThrowAsync<MaterialNotFoundException>();
    }

    [Fact]
    public async Task Handle_DeleteMaterial()
    {
        var material = new Material { Description = "test", Unit = UnitOfMeasure.Centimeter };
        _repository.GetById(1).Returns(material);

        await _handler.Handle(new DeleteMaterialCommand(1), default);

        material.IsDeleted.Should().Be(true);
    }
}