using AutoMapper;
using System;
using System.Collections.Generic;
using Taking.Application.Interfaces;
using Taking.Application.ViewModels;
using Taking.Domain.Entities;
using Taking.Domain.Interfaces.Service;
using Taking.Infra.Data.Interfaces;

namespace Taking.Application.Service
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly ICustomerService _customerService;

        public CustomerAppService(ICustomerService customerService, IUnitOfWork uow)
            : base(uow)
        {
            _customerService = customerService;
        }

        public CustomerViewModel Adicionar(CustomerViewModel customerViewModel)
        {
            var customer = Mapper.Map<CustomerViewModel, Customer>(customerViewModel);

            BeginTransaction();

            var customerReturn = _customerService.Adicionar(customer);
            customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customerReturn);
            if (!customerReturn.ValidationResult.IsValid)
            {
                // Não faz o commit
                return customerViewModel;
            }

            Commit();

            return customerViewModel;
        }

        public CustomerViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Customer, CustomerViewModel>(_customerService.ObterPorId(id));
        }

        public CustomerViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<Customer, CustomerViewModel>(_customerService.ObterPorCpf(cpf));
        }

        public CustomerViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Customer, CustomerViewModel>(_customerService.ObterPorEmail(email));
        }

        public IEnumerable<CustomerViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(_customerService.ObterTodos());
        }

        public CustomerViewModel Atualizar(CustomerViewModel customerViewModel)
        {
            BeginTransaction();
            _customerService.Atualizar(Mapper.Map<CustomerViewModel, Customer>(customerViewModel));
            Commit();
            return customerViewModel;
        }

        public void Remover(Guid id)
        {
            BeginTransaction();
            _customerService.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _customerService.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
