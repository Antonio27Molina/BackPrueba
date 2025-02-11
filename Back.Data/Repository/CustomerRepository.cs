using Back.Entity.Models;
using DataAccess.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Bussiness.Repository;

namespace Back.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ContextoDB _contexto;
        public CustomerRepository(ContextoDB contexto) 
        {
            _contexto = contexto;
        }

        public CustomerModel Login(string userName, string password)
        {
            return _contexto.Database.SqlQueryRaw<CustomerModel>("Select * from Customers where UserName=@user and Password=@password", new SqlParameter("user", (object)userName), new SqlParameter("password", (object)password)).FirstOrDefault();
        }
        public bool Add(CustomerModel customer)
        {
            return _contexto.Database.ExecuteSqlRaw("INSERT INTO Customers (Name, LastName, UserName, Email, Password, Address) " +
                "VALUES(@name, @lastname, @user, @email, @password, @address)", 
                new SqlParameter("name", customer.Name),
                new SqlParameter("lastname", customer.LastName),
                new SqlParameter("user", customer.UserName),
                new SqlParameter("email", customer.Email),
                new SqlParameter("password", customer.Password),
                new SqlParameter("address", customer.Address)) >0;
        }
        public List<CustomerModel> GetAll()
        {
            return _contexto.Database.SqlQueryRaw<CustomerModel>("Select * from Customers").ToList();
        }
        public bool Update(CustomerModel customer)
        {
            return _contexto.Database.ExecuteSqlRaw("UPDATE Customers" +
                "SET " +
                "Name = @name," +
                "LastName = @lastname," +
                "Password = @password," +
                "Address = @address" +
                "WHERE idCustomer = @customer", 
                new SqlParameter("name", customer.Name),
                new SqlParameter("lastname", customer.LastName),
                new SqlParameter("password", customer.Password),
                new SqlParameter("address", customer.Address),
                new SqlParameter("customer", customer.idCustomer)
                ) >0;
        }
        public bool Remove(int id)
        {
            return _contexto.Database.ExecuteSqlRaw("delete from Customers where idCustomer=@customer", new SqlParameter("customer", id))>0;
        }
    }
}
