using System.Threading.Tasks;

using FluentAssertions;

using MM.Application.Catalog.MaterialCategories.Commands.Create;
using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Catalog.Materials.Entities;

using NSubstitute;

namespace MM.UnitTests.Application.Catalog.MaterialCategories.Commands.Create;

public class CreateMaterialCategoryCommandHandlerTests
{
    private readonly IMaterialCategoryRepository _repository;
    private readonly IMaterialCategoryDao _dao;
    private readonly CreateMaterialCategoryCommandHandler _handler;

    public CreateMaterialCategoryCommandHandlerTests()
    {
        _repository = Substitute.For<IMaterialCategoryRepository>();
        _dao = Substitute.For<IMaterialCategoryDao>();
        _handler = new(_repository, _dao);
    }

    [Fact]
    public async Task Handle_DescriptionAlreadyExists_ThrowsMaterialCategoryAlreadyExistsException()
    {
        _dao.DescriptionExists(Arg.Any<string>()).Returns(true);

        var act = async () => await _handler.Handle(new CreateMaterialCategoryCommand { Description = "test" }, default);

        await act.Should().ThrowAsync<MaterialCategoryAlreadyExistsException>();
    }

    [Fact]
    public async Task Handle_ValidDescription_NormalizesAndCreatesCategory()
    {
        _dao.DescriptionExists(Arg.Any<string>()).Returns(false);

        string description = "  test  ";
        var command = new CreateMaterialCategoryCommand { Description = description };

        await _handler.Handle(command, default);

        await _dao.Received(1).DescriptionExists("test");
        _repository.Received(1).Create(
            Arg.Is<MaterialCategory>(x => x.Description == "test")
        );
    }
}