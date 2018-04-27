using Taking.Domain.Entities;

namespace Taking.Domain.Interfaces.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer ObterPorCpf(string cpf);
        Customer ObterPorEmail(string email);
    }
}
