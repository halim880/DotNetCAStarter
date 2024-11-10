
using Application.Common.Interfaces.Persistence;
using Application.Common.Models;
using Application.Features.Products.Commands;
using Application.Features.Products.Results;
using Domain.Entities;
using MediatR;
using System.Data;
using Dapper;

namespace Application.Features.Products.Queries;

public record GetAllProductsQuery : IRequest<Result>;


public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result>
{
    private readonly IDbConnection dbConnection;
    public GetAllProductsQueryHandler(IDbConnection dbConnection)
    {
        this.dbConnection = dbConnection;
    }

    public async Task<Result> Handle(
        GetAllProductsQuery command,
        CancellationToken cancellationToken)
    {
        try
        {
            dbConnection.Open();
            var query = await dbConnection.QueryAsync<ProductResult>("select * from Products");
            var result = await Task.FromResult(Result<List<ProductResult>>.Success(query.ToList()));
            dbConnection.Close();
            return result;
        }
        catch (Exception ex) {
            return (Result)Result.Fail(ex.Message);
        }
    }
}

