using Back.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Bussiness.Interfaces
{
    public interface IItemStoreService
    {
        bool Add(ItemStoreModel item);
        bool Update(ItemStoreModel item);
        List<ItemStoreModel> GetAll();
        bool Remove(int idItem, int idStore);
        List<ItemModel> GetProductsStore(int id);
        List<ItemModel> GetProductsStoreAll(int id);
    }
}
