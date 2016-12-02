using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManagementSystem.Service
{
    public interface IService <T>
    {

        T Find(int primaryKey);
        IList<T> FindAll();
        bool Insert(T obj);
        bool Update(T obj);
        bool Delete(int primaryKey);

    }
}
