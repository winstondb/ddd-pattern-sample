using DomainValidation.Validation;
using System;
using Taking.Domain.Validations.CustomerValidations;

namespace Taking.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }

        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Status { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new CustomerIsConsistent().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
