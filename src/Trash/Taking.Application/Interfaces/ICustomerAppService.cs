using System;
using System.Collections.Generic;
using Taking.Application.ViewModels;

namespace Taking.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        CustomerViewModel ObterPorId(Guid id);
        CustomerViewModel ObterPorCpf(string cpf);
        CustomerViewModel ObterPorEmail(string email);
        IEnumerable<CustomerViewModel> ObterTodos();
        CustomerViewModel Atualizar(CustomerViewModel customerViewModel);
        void Remover(Guid id);
    }
}
