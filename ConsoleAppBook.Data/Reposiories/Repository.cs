﻿using ConsoleAppBook.Core.Models.Base;
using ConsoleAppBook.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBook.Data.Reposiories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly static List<T> _items = new List<T>();
        public async Task AddAsync(T model)
        {
            _items.Add(model);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return _items;
        }

        public async Task<T> GetAsync(Func<T, bool> expression)
        {
            return _items.FirstOrDefault(expression);
        }

        public async Task RemoveAsync(T model)
        {
            _items.Remove(model);
        }
    }
}
