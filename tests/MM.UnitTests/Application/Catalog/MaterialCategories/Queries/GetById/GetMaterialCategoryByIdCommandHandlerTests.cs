using FluentAssertions;

using MM.Application.Catalog.MaterialCategories.Dtos;
using MM.Application.Catalog.MaterialCategories.Exceptions;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Application.Catalog.MaterialCategories.Queries.GetById;

using NSubstitute;

namespace MM.UnitTests.Application.Catalog.MaterialCategories.Queries.GetById;

public class GetMaterialCategoryByIdCommandHandlerTests
{
    private readonly IMaterialCategoryDao _dao;
    private readonly GetMaterialCategoryByIdQueryHandler _handler;

    public GetMaterialCategoryByIdCommandHandlerTests()
    {
        _dao = Substitute.For<IMaterialCategoryDao>();
        _handler = new(_dao);
    }

    [Fact]
    public async Task Handle_NotFound_ThrowsMaterialCategoryNotFoundException()
    {
        _dao.GetById(1).Returns((MaterialCategoryDto?)null);

        var act = async () => await _handler.Handle(new GetMaterialCategoryByIdQuery(1), default);

        await act.Should().ThrowAsync<MaterialCategoryNotFoundException>();
    }

    [Fact]
    public async Task Handle_CategoryExists_ReturnsDto()
    {
        var dto = new MaterialCategoryDto() { Description = "test" };
        _dao.GetById(1).Returns(dto);

        var result = await _handler.Handle(new GetMaterialCategoryByIdQuery(1), default);

        result.Should().Be(dto);
    }
}