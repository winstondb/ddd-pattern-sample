using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Taking.Domain.Entities;
using Taking.Domain.Interfaces.Repository;
using Taking.Infra.Data.Context;

namespace Taking.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TakingContext context)
            : base(context)
        {

        }

        public Customer ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Customer ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override IEnumerable<Customer> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Customers";

            return cn.Query<Customer>(sql);
        }

        public override Customer ObterPorId(Guid id)
        {
            return Buscar(c => c.CustomerId == id).FirstOrDefault();
        }
    }
}
