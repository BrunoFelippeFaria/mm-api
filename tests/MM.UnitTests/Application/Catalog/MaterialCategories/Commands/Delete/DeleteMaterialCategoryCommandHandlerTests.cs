using FluentAssertions;

using MM.Application.Catalog.MaterialCategories.Commands.Delete;
using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Domain.Catalog.Materials.Entities;

using NSubstitute;

namespace MM.UnitTests.Application.Catalog.MaterialCategories.Commands.Delete;

public class DeleteMaterialCategoryCommandHandlerTests
{
    private readonly IMaterialCategoryRepository _repository;
    private readonly IMaterialCategoryDao _dao;
    private readonly DeleteMaterialCategoryCommandHandler _handler;

    public DeleteMaterialCategoryCommandHandlerTests()
    {
        _repository = Substitute.For<IMaterialCategoryRepository>();
        _dao = Substitute.For<IMaterialCategoryDao>();
        _handler = new DeleteMaterialCategoryCommandHandler(_repository, _dao);
    }

    [Fact]
    public async Task Handle_CategoryNotFound_ThrowsNotFoundException()
    {
        _repository.GetById(1).Returns((MaterialCategory?)null);

        var act = async () => await _handler.Handle(new DeleteMaterialCategoryCommand(1), default);

        await act.Should().ThrowAsync<MaterialCategoryNotFoundException>();
    }

    [Fact]
    public async Task Handle_HasMaterials_ForceIsFalse_ThrowsHasMaterialsException()
    {
        _repository.GetById(1).Returns(new MaterialCategory { Description = "test" });
        _dao.HasMaterials(1).Returns(true);

        var act = async () => await _handler.Handle(new DeleteMaterialCategoryCommand(1)
        {
            Force = false
        }, default);

        await act.Should().ThrowAsync<MaterialCategoryHasMaterialsException>();
    }

    [Fact]
    public async Task Handle_HasMaterials_ForceIsTrue_RemovesCategoryFromMaterials()
    {
        var category = new MaterialCategory { Description = "test" };

        _repository.GetById(1).Returns(category);
        _dao.HasMaterials(1).Returns(true);

        await _handler.Handle(new DeleteMaterialCategoryCommand(1)
        {
            Force = true
        }, default);

        await _dao.Received(1).RemoveCategoryFromMaterials(1);
        category.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_NoMaterials_DeletesWithoutRemovingFromMaterials()
    {
        var category = new MaterialCategory { Description = "test" };

        _repository.GetById(1).Returns(category);
        _dao.HasMaterials(1).Returns(false);

        await _handler.Handle(new DeleteMaterialCategoryCommand(1)
        {
            Force = false
        }, default);

        await _dao.DidNotReceive().RemoveCategoryFromMaterials(Arg.Any<int>());
        category.IsDeleted.Should().BeTrue();
    }
}