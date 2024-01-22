

using Application.Common.Interfaces.Persistence;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands
{
    public class CreateCategoryCommand : IRequest<Result<Category>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Category>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Result<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            //var product = new Category
            //{
            //    Name = command,
            //    RegularPrice = command.RegularPrice,
            //    SalePrice = command.SalePrice,
            //    Description = command.Description,
            //    CreatedBy = "Halim",
            //    CreatedOn = DateTime.Now,
            //    LastModifiedBy = "Halim",
            //    LastModifiedOn = DateTime.Now,
            //    IsDeleted = false
            //};

            //await _unitOfWork.Repository<Product>().AddAsync(product);
            //await _unitOfWork.Commit(cancellationToken);
            //var result = await Task.FromResult(Result<Product>.Success(product));
            //return result;
            return null;
        }
    }
}
