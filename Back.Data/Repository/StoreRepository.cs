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
    public class StoreRepository : IStoreRepository
    {
        private readonly ContextoDB _contexto;
        public StoreRepository(ContextoDB contexto) 
        {
            _contexto = contexto;
        }
        public bool Add(StoreModel store)
        {
            return _contexto.Database.ExecuteSqlRaw("INSERT INTO Store (Name, Address, Status)" +
                "VALUES(@name, @address, @status)",
                new SqlParameter("name", store.Name),
                new SqlParameter("address", store.Address),
                new SqlParameter("status", store.Status)
                ) > 0;
        }
        public List<StoreModel> GetAll()
        {
            return _contexto.Database.SqlQueryRaw<StoreModel>("Select * from Store").ToList();
        }
        public StoreModel GetById(int id)
        {
            var store= _contexto.Database.SqlQueryRaw<StoreModel>("Select * from Store where idStore=@store", new SqlParameter("store", id)).ToList();
            return store.FirstOrDefault();
        }
        public bool Update(StoreModel store)
        {
            return _contexto.Database.ExecuteSqlRaw("UPDATE Store" +
                "SET" +
                "Name=@name," +
                "Address=@address," +
                "Status=@status" +
                "WHERE idStore=@store",
                new SqlParameter("name", store.Name),
                new SqlParameter("address", store.Address),
                new SqlParameter("status", store.Status),
                new SqlParameter("store", store.idStore)) > 0;
        }
        public bool Remove(int id)
        {
            return _contexto.Database.ExecuteSqlRaw("delete from Store where idStore=@store", new SqlParameter("store", id)) > 0;
        }
    }
}
