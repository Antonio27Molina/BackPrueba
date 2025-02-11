using Back.Bussiness.Interfaces;
using Back.Bussiness.Repository;
using Back.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Bussiness.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cart;
        public CartService(ICartRepository cart)
        {
            _cart = cart;
        }

        public bool Add(List<CartModel> cart)
        {
            bool insert = true;
            foreach (var item in cart)
            {
                if (!_cart.Add(item))
                {
                    insert = false;
                    break;
                }
            }
            return insert;
        }
        public List<CartModel> GetAll()
        {
            return _cart.GetAll();
        }
        public List<CartModel> GetById(int id)
        {
            return _cart.GetById(id);
        }
        public bool Update(CartModel cart)
        {
            return _cart.Update(cart);
        }
        public bool Remove(int id)
        {
            return _cart.Remove(id);
        }
    }
}
