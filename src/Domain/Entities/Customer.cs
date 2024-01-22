

using Domain.Contracts;

namespace Domain.Entities
{
    public class Customer : AuditableEntity<int>
    {
        public int Id { get; set; }
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
}
