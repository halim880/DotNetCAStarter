

using Application.Common.Interfaces.Persistence;
using Application.Common.Models;
using Application.Features.Products.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Result<Customer>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DOB { get; set; } = DateTime.Now;
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public long NID { get; set; }
        public long BCNo { get; set; }
        public string PassportNo { get; set; } = string.Empty;
        public string IdentityType { get; set; } = string.Empty;
        public string IdProofOne { get; set; } = string.Empty;
        public string IdProofTwo { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateCustomerCommand, Result<Customer>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        public CreateProductCommandHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Customer>> Handle(
            CreateCustomerCommand command,
            CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Gender = command.Gender,
                DOB = command.DOB,
                PhoneNumber = command.PhoneNumber,
                NID = command.NID,
                BCNo = command.BCNo,
                PassportNo = command.PassportNo,
                IdentityType = command.IdentityType,
                IdProofOne = command.IdProofOne,
                IdProofTwo = command.IdProofTwo,
                Photo = command.Photo,
                City = command.City,
                Nationality = command.Nationality,


                //AuditInfo
                CreatedBy = "Halim",
                CreatedOn = DateTime.Now,
                LastModifiedBy = "Halim",
                LastModifiedOn = DateTime.Now,
                IsDeleted = false
            };

            await _unitOfWork.Repository<Customer>().AddAsync(customer);
            await _unitOfWork.Commit(cancellationToken);
            var result = await Task.FromResult(Result<Customer>.Success(customer));
            return result;
        }
    }
}
