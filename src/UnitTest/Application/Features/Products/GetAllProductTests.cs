
using Application.Features.Products.Queries;
using Application.Features.Products.Results;
using System.Data;

using Application.Features.Products.Queries;
using Application.Common.Models;
using Application.Features.Products.Results;
using Domain.Entities;
using Dapper;
using System.Data;
using System.Linq;
using System.Threading;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UnitTest.Application.Features.Products;

public class GetAllProductsQueryHandlerTests
{
    private readonly IDbConnection _dbConnection;

    public GetAllProductsQueryHandlerTests()
    {
        _dbConnection = new SqlConnection("Data Source=Halim; Initial Catalog=StarterDb;Trusted_Connection=True; multipleactiveresultsets=true;Encrypt=True;TrustServerCertificate=True;");
    }


    [Fact]
    public async Task Handle_ShouldReturnSuccessResult_WhenProductsAreFound()
    {
        // Arrange
        var handler = new GetAllProductsQueryHandler(_dbConnection);

        // Act
        Result r = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

        var result = (Result<List<ProductResult>>)r;
        // Assert
        Assert.True(result.Succeeded);
        Assert.NotNull(result.Data);
        var products = result.Data;
    }

    public void Dispose()
    {
        _dbConnection.Dispose();
    }
}
