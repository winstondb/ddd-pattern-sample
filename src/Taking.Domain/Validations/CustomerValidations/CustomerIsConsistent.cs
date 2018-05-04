using DomainValidation.Validation;
using Taking.Domain.Entities;
using Taking.Domain.Specifications.CustomerSpecifications;

namespace Taking.Domain.Validations.CustomerValidations
{
    public class CustomerIsConsistent : Validator<Customer>
    {
        public CustomerIsConsistent()
        {
            var CPFCliente = new CustomerMustHaveValidCPFSpecification();
            base.Add("CPFCliente", new Rule<Customer>(CPFCliente, "Cliente informou um CPF inválido."));
        }
    }
}
