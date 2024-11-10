
using Application.Common.Interfaces.Persistence;
using Application.Common.Models;
using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Application.Features.Products.Commands;

public class CreateProductCommand : IRequest<Result<int>>
{
    [Required, MinLength(10)]
    public string ProductName { get; set; }
    public string Description { get; set; }
    public double RegularPrice { get; set; }
    public double SalePrice { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;
    public CreateProductCommandHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
        CreateProductCommand command, 
        CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.ProductName,
            RegularPrice = command.RegularPrice,
            SalePrice = command.SalePrice,
            Description = command.Description,
            CreatedBy = "Halim",
            CreatedOn = DateTime.Now,
            LastModifiedBy = "Halim",
            LastModifiedOn = DateTime.Now,
            IsDeleted = false
        };

        await _unitOfWork.Repository<Product>().AddAsync(product);
        await _unitOfWork.Commit(cancellationToken);
        var result  = await Task.FromResult(Result<int>.Success(product.Id));
        return result;
    }
}
 
