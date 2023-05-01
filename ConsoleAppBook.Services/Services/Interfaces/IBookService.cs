using ConsoleAppBook.Core.Enums;
using ConsoleAppBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBook.Services.Services.Interfaces
{
    public interface IBookService
    {
        public Task<string> CreateAsync(int id, string name, double price, bool InStock, double DiscountPrice, BookCategory bookCategory);
        public Task<string> DeleteAsync(int BookId, int WriterId);
        public Task<Book> GetAsync(int BookId, int WriterId);
        public Task GetAllAsync();
        public Task<string> UpdateAsync(int BookId, int WriterId, string name, double price, bool InStock, double DiscountPrice);
        public Task<string> BuyBook(int BookId, int WriterId);
    }
}
