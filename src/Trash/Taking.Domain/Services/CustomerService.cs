using System;
using System.Collections.Generic;
using Taking.Domain.Entities;
using Taking.Domain.Interfaces.Repository;
using Taking.Domain.Interfaces.Service;

namespace Taking.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Adicionar(Customer customer)
        {
            if (!customer.IsValid())
            {
                return customer;
            }

            if (!customer.ValidationResult.IsValid)
            {
                return customer;
            }

            customer.ValidationResult.Message = "cliente cadastrado com sucesso :)";
            return _customerRepository.Adicionar(customer);
        }

        public Customer Atualizar(Customer customer)
        {
            return _customerRepository.Atualizar(customer);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Customer ObterPorCpf(string cpf)
        {
            return _customerRepository.ObterPorCpf(cpf);
        }

        public Customer ObterPorEmail(string email)
        {
            return _customerRepository.ObterPorEmail(email);
        }

        public Customer ObterPorId(Guid id)
        {
            return _customerRepository.ObterPorId(id);
        }

        public IEnumerable<Customer> ObterTodos()
        {
            return _customerRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _customerRepository.Remover(id);
        }
    }
}
