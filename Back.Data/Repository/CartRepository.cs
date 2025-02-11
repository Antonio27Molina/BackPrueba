using Back.Bussiness.Repository;
using Back.Entity.Models;
using DataAccess.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Data.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ContextoDB _contexto;
        public CartRepository(ContextoDB contexto) 
        { 
            _contexto = contexto;
        }

        public bool Add(CartModel cart)
        {
            return _contexto.Database.ExecuteSqlRaw("INSERT INTO Cart (idItem, idCustomer, quantity, createDate, Status)  VALUES(@item, @customer, @quantity, @createdate, @status);",
                new SqlParameter("customer", cart.IdCustomer), 
                new SqlParameter("quantity", cart.Quantity),
                new SqlParameter("createdate", DateTime.Now),
                new SqlParameter("item", cart.IdItem),
                new SqlParameter("status", 1)) > 0;
        }
        public List<CartModel> GetAll()
        {
            return _contexto.Database.SqlQueryRaw<CartModel>("Select * from Cart").ToList();
        }
        public List<CartModel> GetById(int id)
        {
            return _contexto.Database.SqlQueryRaw<CartModel>("Select * from Cart where idCustomer = @customer", new SqlParameter("customer", id)).ToList();
        }
        public bool Update(CartModel cart)
        {
            return _contexto.Database.ExecuteSqlRaw("UPDATE Cart " +
                "SET " +
                "quantity = @quantity, " +
                "WHERE idCart = @cart;",
                new SqlParameter("quantity", cart.Quantity),
                new SqlParameter("cart", cart.IdCart)
                ) > 0;
        }
        public bool Remove(int id)
        {
            return _contexto.Database.ExecuteSqlRaw("delete from Cart where idCart=@cart", new SqlParameter("cart", id)) > 0;
        }
    }
}
