using FluentAssertions;

using MM.Application.Catalog.Materials.Commands.Create;
using MM.Application.Catalog.Materials.Exceptions;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Domain.Catalog.Materials.Entities;
using MM.Domain.Catalog.Shared.Enums;

using NSubstitute;

namespace MM.UnitTests.Application.Catalog.Materials.Commands.Create;

public class CreateMaterialCommandHandlerTests
{
    private readonly IMaterialRepository _repository;
    private readonly IMaterialsDao _dao;
    private readonly CreateMaterialCommandHandler _handler;

    public CreateMaterialCommandHandlerTests()
    {
        _repository = Substitute.For<IMaterialRepository>();
        _dao = Substitute.For<IMaterialsDao>();

        _handler = new(_repository, _dao);
    }

    [Fact]
    public async Task Handle_DescriptionAlredyExists_ThrowsMaterialAlredyExistsException()
    {
        _dao.DescriptionExistis(Arg.Any<string>()).Returns(true);

        var act = async () => await _handler.Handle(new CreateMaterialCommand
        {
            Description = "test",
            Unit = UnitOfMeasure.Centimeter
        }, default);

        await act.Should().ThrowAsync<MaterialAlredyExistsException>();
    }

    [Fact]
    public async Task Handle_ValidDescription_NormalizeAndCreate()
    {
        _dao.DescriptionExistis(Arg.Any<string>()).Returns(false);

        await _handler.Handle(new CreateMaterialCommand
        {
            Description = "    test    ",
            Unit = UnitOfMeasure.Centimeter
        }, default);

        _repository.Received().Create(Arg.Is<Material>(x =>
            x.Description == "test"
        ));
    }
}