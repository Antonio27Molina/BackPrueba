using Back.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Bussiness.Interfaces
{
    public interface ICartService
    {
        bool Add(List<CartModel> cart);
        List<CartModel> GetAll();
        bool Update(CartModel cart);
        bool Remove(int id);
        List<CartModel> GetById(int id);
    }
}
