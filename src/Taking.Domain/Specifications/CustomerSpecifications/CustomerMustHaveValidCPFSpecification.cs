using DomainValidation.Interfaces.Specification;
using Taking.Domain.Entities;
using Taking.Domain.Validations.Document;

namespace Taking.Domain.Specifications.CustomerSpecifications
{
    public class CustomerMustHaveValidCPFSpecification : ISpecification<Customer>
    {
        public bool IsSatisfiedBy(Customer customer)
        {
            return CPFValidation.Validar(customer.CPF);
        }
    }
}
