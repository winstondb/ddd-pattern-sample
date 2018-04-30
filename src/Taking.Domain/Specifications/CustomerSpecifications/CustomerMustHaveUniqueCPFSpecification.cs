using DomainValidation.Interfaces.Specification;
using Taking.Domain.Entities;
using Taking.Domain.Interfaces.Repository;

namespace Taking.Domain.Specifications.CustomerSpecifications
{
    public class CustomerMustHaveUniqueCPFSpecification : ISpecification<Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerMustHaveUniqueCPFSpecification(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool IsSatisfiedBy(Customer customer)
        {
            return _customerRepository.ObterPorCpf(customer.CPF) == null;
        }
    }
}
