﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
        T Get(int id);
        T Add(T obj);
        T Update(T obj);
        void SaveChanges();
    }
}