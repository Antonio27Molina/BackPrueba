using Back.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Bussiness.Repository
{
    public interface IStoreRepository
    {
        bool Add(StoreModel store);
        List<StoreModel> GetAll();
        bool Update(StoreModel store);
        bool Remove(int id);
        StoreModel GetById(int id);
    }
}
