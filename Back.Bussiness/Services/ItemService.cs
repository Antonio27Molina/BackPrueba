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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _item;
        public ItemService(IItemRepository item)
        {
            _item = item;
        }
        public bool Add(ItemModel item)
        {
            return _item.Add(item);
        }

        public List<ItemModel> GetAll()
        {
            return _item.GetAll();
        }

        public bool Remove(int id)
        {
            return _item.Remove(id);
        }

        public bool Update(ItemModel item)
        {
            return _item.Update(item);
        }
        public ItemModel GetById(int id)
        {
            return _item.GetById(id);
        }
    }
}
