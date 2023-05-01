using ConsoleAppBook.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBook.Core.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        public Task AddAsync(T Model);
        public Task<T> GetAsync(Func<T, bool> expression);

        public Task<List<T>> GetAllAsync();

        public Task RemoveAsync(T model);
    }
}
