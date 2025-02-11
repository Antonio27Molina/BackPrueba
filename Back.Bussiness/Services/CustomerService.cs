using Back.Bussiness.Interfaces;
using Back.Bussiness.Repository;
using Back.Comun.Encrypt;
using Back.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Bussiness.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customer;
        public CustomerService(ICustomerRepository customerRepository) 
        {
            _customer = customerRepository;
        }
        public bool Add(CustomerModel customer)
        {
            customer.Password=Encrypt.EncryptString(customer.Password);
            return _customer.Add(customer);
        }

        public List<CustomerModel> GetAll()
        {
            return _customer.GetAll();
        }

        public CustomerModel Login(string userName, string password)
        {
            string passwordEncrypt=Encrypt.EncryptString(password);
            return _customer.Login(userName, passwordEncrypt);
        }

        public bool Remove(int id)
        {
            return _customer.Remove(id);
        }

        public bool Update(CustomerModel customer)
        {
            customer.Password = Encrypt.EncryptString(customer.Password);
            return _customer.Update(customer);
        }
    }
}
