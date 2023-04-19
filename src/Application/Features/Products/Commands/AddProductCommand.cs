
using Application.Common.Models;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Result<int>>
    {
        public int ProductId { get; set; } = 0;
        [Required, MinLength(10)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double RegularPrice { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        //private readonly MyDbContext _dbContext;

        //public CreateProductCommandHandler(MyDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public async Task<Result<int>> Handle(
            CreateProductCommand command, 
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.ProductName,
                RegularPrice = command.RegularPrice,
                Description = command.Description
            };
            var result  = await Task.FromResult(Result<int>.Success(1));
            return result;
        }
    }

}
