using System.Threading.Tasks;

using FluentAssertions;

using MM.Application.Catalog.Materials.Commands.Update;
using MM.Application.Catalog.Materials.Exceptions;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Domain.Catalog.Materials.Entities;
using MM.Domain.Catalog.Shared.Enums;

using NSubstitute;

namespace MM.UnitTests.Application.Catalog.Materials.Commands.Update;

public class UpdateMaterialCommandHandlerTests
{
    private readonly IMaterialRepository _repository;
    private readonly IMaterialsDao _dao;
    private readonly UpdateMaterialCommandHandler _handler;

    public UpdateMaterialCommandHandlerTests()
    {
        _repository = Substitute.For<IMaterialRepository>();
        _dao = Substitute.For<IMaterialsDao>();

        _handler = new(_repository, _dao);
    }

    [Fact]
    public void Handle_NotFound_ThrowsMaterialNotFoundException()
    {
        _repository.GetById(1).Returns((Material?)null);

        var act = async () => await _handler.Handle(new UpdateMaterialCommand(1)
        {
            Description = "test",
            Unit = UnitOfMeasure.Centimeter
        }, default);

        act.Should().ThrowAsync<MaterialNotFoundException>();
    }

    [Fact]
    public void Handle_DescriptionExists_ThrowsMaterialAlredyExistsException()
    {
        _repository.GetById(1).Returns(new Material { Description = "test", Unit = UnitOfMeasure.Centimeter });
        _dao.DescriptionExists(Arg.Any<string>(), 1).Returns(true);

        var act = async () => await _handler.Handle(new UpdateMaterialCommand(1)
        {
            Description = "test",
            Unit = UnitOfMeasure.Centimeter
        }, default);

        act.Should().ThrowAsync<MaterialAlredyExistsException>();
    }

    [Fact]
    public async Task Handle_ValidDescription_NormalizeAndUpdate()
    {
        var material = new Material { Description = "test", Unit = UnitOfMeasure.Centimeter };

        _repository.GetById(1).Returns(material);
        _dao.DescriptionExists(Arg.Any<string>(), 1).Returns(false);

        await _handler.Handle(new UpdateMaterialCommand(1)
        {
            Description = "   updated   ",
            Unit = UnitOfMeasure.Centimeter
        }, default);

        await _dao.Received(1).DescriptionExists("updated", 1);
        material.Description.Should().Be("updated");
    }

}