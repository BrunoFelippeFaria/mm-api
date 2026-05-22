using FluentAssertions;

using MM.Application.Catalog.MaterialCategories.Commands.Update;
using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Catalog.Materials.Entities;

using NSubstitute;

namespace MM.UnitTests.Application.Catalog.MaterialCategories.Commands.Update;

public class UpdateMaterialCategoryCommandHandlerTests
{
    private readonly IMaterialCategoryRepository _repository;
    private readonly IMaterialCategoryDao _dao;
    private readonly UpdateMaterialCategoryCommandHandler _handler;

    public UpdateMaterialCategoryCommandHandlerTests()
    {
        _repository = Substitute.For<IMaterialCategoryRepository>();
        _dao = Substitute.For<IMaterialCategoryDao>();

        _handler = new(_repository, _dao);
    }

    [Fact]
    public async Task Handle_DescriptionAlreadyExists_ThrowsMaterialCategoryAlreadyExistsException()
    {
        _repository.GetById(1).Returns(new MaterialCategory { Description = "test" });
        _dao.DescriptionExists(Arg.Any<string>(), 1).Returns(true);

        var act = async () => await _handler.Handle(new UpdateMaterialCategoryCommand(1) { Description = "test" }, default);

        await act.Should().ThrowAsync<MaterialCategoryAlreadyExistsException>();
    }

    [Fact]
    public async Task Handle_NotFound_ThrowsMaterialCategoryNotFoundException()
    {
        _repository.GetById(1).Returns((MaterialCategory?)null);

        var act = async () => await _handler.Handle(new UpdateMaterialCategoryCommand(1) { Description = "test" }, default);

        await act.Should().ThrowAsync<MaterialCategoryNotFoundException>();
    }

    [Fact]
    public async Task Handle_ValidDescription_NormalizeAndUpdatesCategory()
    {
        var category = new MaterialCategory { Description = " test " };
        _repository.GetById(1).Returns(category);

        await _handler.Handle(new UpdateMaterialCategoryCommand(1) { Description = " updated " }, default);

        await _dao.Received(1).DescriptionExists("updated", 1);
        category.Description.Should().Be("updated");
    }
}