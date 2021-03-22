﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> FindAll();
        T FindById(int id);
        T FindByName(string name);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
