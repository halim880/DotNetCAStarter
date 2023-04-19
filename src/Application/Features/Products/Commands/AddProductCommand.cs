
using Application.Common.Interfaces.Persistence;
using Application.Common.Models;
using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Result<Product>>
    {
        [Required, MinLength(10)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double RegularPrice { get; set; }
        public double SalePrice { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Product>>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork<int> _unitOfWork;
        public CreateProductCommandHandler(IProductRepository repository, IUnitOfWork<int> unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Product>> Handle(
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
            //await _repository.SaveAsync(product);
            await _unitOfWork.Repository<Product>().AddAsync(product);
            await _unitOfWork.Commit(cancellationToken);
            var result  = await Task.FromResult(Result<Product>.Success(product));
            return result;
        }
    }
     
}
