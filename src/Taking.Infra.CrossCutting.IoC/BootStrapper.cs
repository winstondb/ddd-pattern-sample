using SimpleInjector;
using Taking.Application;
using Taking.Application.Interfaces;
using Taking.Domain.Interfaces.Repository;
using Taking.Domain.Interfaces.Service;
using Taking.Domain.Services;
using Taking.Infra.Data.Context;
using Taking.Infra.Data.Interfaces;
using Taking.Infra.Data.Repository;
using Taking.Infra.Data.UoW;

namespace Taking.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.Register<ICustomerAppService, CustomerAppService>();

            // Domain
            container.Register<ICustomerService, CustomerService>();

            // Infra Dados
            container.Register<ICustomerRepository, CustomerRepository>();
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<TakingContext>();

        }
    }
}
