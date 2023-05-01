using ConsoleAppBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBook.Services.Services.Interfaces
{
    public interface IBookWriterService
    {
        public Task<string> CreateAsync(string name, string surname, byte age);
        public Task<string> DeleteAsync(int id);
        public Task<BookWriter> GetAsync(int id);
        public Task GetAllAsync();

        public Task<List<Book>> GetAllBooksAsync(int id);
        public Task<string> UpdateAsync(int id, string name, string surname, byte age);
    }
}
