﻿using Back.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Bussiness.Repository
{
    public interface IItemRepository
    {
        bool Add(ItemModel item);
        List<ItemModel> GetAll();
        bool Update(ItemModel item);
        bool Remove(int id);
        ItemModel GetById(int id);
    }
}
