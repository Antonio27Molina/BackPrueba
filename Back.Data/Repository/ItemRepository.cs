using Back.Bussiness.Repository;
using Back.Entity.Models;
using DataAccess.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Data.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ContextoDB _contexto;
        public ItemRepository(ContextoDB contexto)
        {
            _contexto = contexto;
        }
        public bool Add(ItemModel item)
        {
            return _contexto.Database.ExecuteSqlRaw("INSERT INTO Item (Code, Description, Price, Image, Status) " +
                "VALUES(@code, @description, @price, @image, @status)",
                new SqlParameter("code", item.Code),
                new SqlParameter("description", item.Description),
                new SqlParameter("price", item.Price),
                new SqlParameter("status", item.Status),
                new SqlParameter("image", item.Image)
                ) > 0;
        }
        public List<ItemModel> GetAll()
        {
            return _contexto.Database.SqlQueryRaw<ItemModel>("Select * from Item").ToList();
        }
        public bool Update(ItemModel item)
        {
            return _contexto.Database.ExecuteSqlRaw("UPDATE Item  " +
                "SET " +
                " Code = @code," +
                "Description= @description," +
                "Price = @price" +
                "Image = @image," +
                "Status = @status" +
                "WHERE idItem = @item;",
                new SqlParameter("code", item.Code),
                new SqlParameter("description", item.Description),
                new SqlParameter("price", item.Price),
                new SqlParameter("status", item.Status),
                new SqlParameter("image", item.Image),
                new SqlParameter("item", item.idItem)) > 0;
        }
        public bool Remove(int id)
        {
            return _contexto.Database.ExecuteSqlRaw("delete from Item where idItem=@item", new SqlParameter("item", id)) > 0;
        }
       public ItemModel GetById(int id)
        {
            return _contexto.Database.SqlQueryRaw<ItemModel>("Select * from Item where idItem=@item", new SqlParameter("item", id)).FirstOrDefault();
        }
    }
}
