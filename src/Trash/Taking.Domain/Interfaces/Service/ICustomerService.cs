using System;
using System.Collections.Generic;
using Taking.Domain.Entities;

namespace Taking.Domain.Interfaces.Service
{
    public interface ICustomerService : IDisposable
    {
        Customer Adicionar(Customer customer);
        Customer ObterPorId(Guid id);
        Customer ObterPorCpf(string cpf);
        Customer ObterPorEmail(string email);
        IEnumerable<Customer> ObterTodos();
        Customer Atualizar(Customer customer);
        void Remover(Guid id);
    }
}
