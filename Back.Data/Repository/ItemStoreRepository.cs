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
    public class ItemStoreRepository : IItemStoreRepository
    {
        private readonly ContextoDB _contexto;
        public ItemStoreRepository(ContextoDB contexto) 
        {
            _contexto = contexto;
        }
        public bool Add(ItemStoreModel item)
        {
            return _contexto.Database.ExecuteSqlRaw("INSERT INTO ItemsStore (idItem, idStore, stock)" +
                "VALUES(@item, @store, @stock)",
                new SqlParameter("item", item.idItem),
                new SqlParameter("store", item.idStore), 
                new SqlParameter("stock", item.stock)) > 0;
        }
        public List<ItemStoreModel> GetAll()
        {
            return _contexto.Database.SqlQueryRaw<ItemStoreModel>("Select * ItemsStore").ToList();
        }
        public bool Update(ItemStoreModel item)
        {
            return _contexto.Database.ExecuteSqlRaw("UPDATE ItemsStore  " +
                "SET  " +
                "stock = @stock " +
                "WHERE idItem = @item AND idStore = @store;",
                new SqlParameter("item", item.idItem),
                new SqlParameter("store", item.idStore),
                new SqlParameter("stock", item.stock)) > 0;
        }
        public bool Remove(int idItem, int idStore)
        {
            return _contexto.Database.ExecuteSqlRaw("delete from ItemsStore WHERE idItem = @item AND idStore = @store;",
                new SqlParameter("item", idItem),
                new SqlParameter("store", idStore)) > 0;
        }
        public List<ItemModel> GetProductsStore(int id)
        {
            return _contexto.Database.SqlQueryRaw<ItemModel>("Exec GetProducts @id", new SqlParameter("id", id)).ToList();
        }
        public List<ItemModel> GetProductsStoreAll(int id)
        {
            return _contexto.Database.SqlQueryRaw<ItemModel>("Exec GetProductsAll @id", new SqlParameter("id", id)).ToList();
        }
    }
}
