using Back.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Bussiness.Interfaces
{
    public interface ICustomerService
    {
        bool Add(CustomerModel customer);
        List<CustomerModel> GetAll();
        bool Update(CustomerModel customer);
        bool Remove(int id);
        CustomerModel Login(string userName, string password);
    }
}
