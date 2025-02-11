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
    public class ItemStoreService : IItemStoreService
    {
        private readonly IItemStoreRepository _repository;
        public ItemStoreService(IItemStoreRepository repository)
        {
            _repository = repository;
        }
        public bool Add(ItemStoreModel item)
        {
            return _repository.Add(item);
        }
        public bool Update(ItemStoreModel item)
        {
            return _repository.Update(item);
        }
        public List<ItemStoreModel> GetAll()
        {
            return _repository.GetAll();
        }
        public bool Remove(int idItem, int idStore)
        {
            return _repository.Remove(idItem, idStore);
        }
        public List<ItemModel> GetProductsStore(int id)
        {
            return _repository.GetProductsStore(id);
        }
        public List<ItemModel> GetProductsStoreAll(int id)
        {
            return _repository.GetProductsStoreAll(id);
        }
    }
}
