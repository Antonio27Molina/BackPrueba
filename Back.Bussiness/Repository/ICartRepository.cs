using Back.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Bussiness.Repository
{
    public interface ICartRepository
    {
        bool Add(CartModel cart);
        List<CartModel> GetAll();
        bool Update(CartModel cart);
        bool Remove(int id);
        List<CartModel> GetById(int id);
    }
}
