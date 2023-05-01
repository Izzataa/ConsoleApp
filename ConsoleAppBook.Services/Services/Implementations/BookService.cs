using ConsoleAppBook.Core.Enums;
using ConsoleAppBook.Core.Models;
using ConsoleAppBook.Data.Reposiories.BookWriters;
using ConsoleAppBook.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBook.Services.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly static BookWriterRepository _BookWriterServices = new BookWriterRepository();

        public async Task<string> BuyBook(int BookId, int WriterId)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == WriterId);
            if (bookWriter == null) return "Not found BookWriter";
            Book book = bookWriter.Books.FirstOrDefault(b => b.Id == BookId);
            if (book == null) return "Book not found";
            if (book.InStock == false) return "Book Stock not";
            Console.ForegroundColor = ConsoleColor.Green;
            return "Buy successfully";
        }

        public async Task<string> CreateAsync(int id, string name, double price, bool InStock, double DiscountPrice, BookCategory bookCategory)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == id);
            if (bookWriter == null) return "BookWriter Not found";
            if (string.IsNullOrEmpty(name)) return "add valid name";
            if (DiscountPrice > price || DiscountPrice <= 0) return "Add valid discountprice";
            Book book = new Book(name, price, DiscountPrice, InStock, bookCategory);
            bookWriter.Books.Add(book);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Created successfully";
        }

        public async Task<string> DeleteAsync(int BookId, int WriterId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == WriterId);
            if (bookWriter == null) return "Not found BookWriter";


            Book book = bookWriter.Books.FirstOrDefault(b => b.Id == BookId);
            if (book == null) return "Book not found";
            bookWriter.Books.Remove(book);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Deleted succesfully";
        }

        public async Task GetAllAsync()
        {
            foreach (var item in await _BookWriterServices.GetAllAsync())
            {
                foreach (var book in item.Books)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public async Task<Book> GetAsync(int BookId, int WriterId)
        {
            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == WriterId);
            if (bookWriter == null) Console.WriteLine("BookWriter not found");
            Book book = bookWriter.Books.FirstOrDefault(b => b.Id == BookId);
            if (book is null) Console.WriteLine("Book not found");
            return book;
        }



        public async Task<string> UpdateAsync(int BookId, int WriterId, string name, double price, bool InStock, double DiscountPrice)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == WriterId);
            if (bookWriter == null) return "BookWriter Not found";
            Book book = bookWriter.Books.FirstOrDefault(b => b.Id == BookId);
            if (BookId == null) Console.WriteLine("Book not found");
            if (string.IsNullOrEmpty(name)) return "add valid name";
            if (DiscountPrice > price || DiscountPrice <= 0) return "Add valid discountprice";
            book.Price = price;
            book.Name = name;
            book.DiscountPrice = DiscountPrice;
            book.UpdatedDate = DateTime.UtcNow.AddHours(4);
            book.InStock = InStock;
            Console.ForegroundColor = ConsoleColor.Green;
            return "Updated successfully";
        }
    }
}
