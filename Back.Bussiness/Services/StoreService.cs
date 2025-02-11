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
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _store;
        public StoreService(IStoreRepository store)
        {
            _store = store;
        }
        public bool Add(StoreModel store)
        {
            return _store.Add(store);
        }

        public List<StoreModel> GetAll()
        {
            return _store.GetAll();
        }

        public bool Remove(int id)
        {
            return _store.Remove(id);
        }

        public bool Update(StoreModel store)
        {
            return _store.Update(store);
        }
        public StoreModel GetById(int id)
        {
            return _store.GetById(id);
        }
    }
}
