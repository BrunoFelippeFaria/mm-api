using System.Threading.Tasks;

using FluentAssertions;

using MM.Application.Catalog.Materials.Dtos;
using MM.Application.Catalog.Materials.Exceptions;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Application.Catalog.Materials.Queries.GetById;
using MM.Domain.Catalog.Shared.Enums;

using NSubstitute;

namespace MM.UnitTests.Application.Catalog.Materials.Queries.GetById;

public class GetMaterialByIdCommandHandlerTests
{
    private readonly IMaterialsDao _dao;
    private readonly GetMaterialByIdQueryHandler _handler;

    public GetMaterialByIdCommandHandlerTests()
    {
        _dao = Substitute.For<IMaterialsDao>();
        _handler = new(_dao);
    }

    [Fact]
    public void Handle_NotFound_ThrowsMaterialNotFoundException()
    {
        _dao.GetById(1).Returns((MaterialDto?)null);

        var act = async () => await _handler.Handle(new GetMaterialByIdQuery(1), default);

        act.Should().ThrowAsync<MaterialNotFoundException>();
    }

    [Fact]
    public async Task Handle_MaterialExistis_ReturnsDto()
    {
        var dto = new MaterialDto
        {
            Id = 1,
            Unit = UnitOfMeasure.Unit,
            Description = "test"
        };

        _dao.GetById(1).Returns(dto);

        var result = await _handler.Handle(new GetMaterialByIdQuery(1), default);

        result.Should().Be(dto);
    }
}