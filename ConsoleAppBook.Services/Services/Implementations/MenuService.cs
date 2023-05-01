using ConsoleAppBook.Core.Enums;
using ConsoleAppBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBook.Services.Services.Implementations
{
    public class MenuService
    {
        public bool IsAdmin = false;

        private User[] Users = { new User { UserName = "Code", Password = "Code123" }, new User { UserName = "Izzat", Password = "Izzat123" } };
        private BookWriterService _bookWriterService = new BookWriterService();
        private BookService _bookService = new BookService();
        public async Task<bool> Login()
        {
            Console.WriteLine("Add username");
            string username = Console.ReadLine();
            Console.WriteLine("Add password");
            string password = Console.ReadLine();

            if (Users.Any(x => x.UserName == username && x.Password == password))
            {
                IsAdmin = true;
            }
            else
            {
                Console.WriteLine("Username or password incorrect");
                IsAdmin = false;
            }

            return IsAdmin;
        }
        public async Task ShowMenuAdmin()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string sentence = "Welcome to my App";

            foreach (var item in sentence)
            {
                Thread.Sleep(100);
                Console.Write(item);
            }
            Console.WriteLine("0.Close App");
            Console.WriteLine("1.Create BookWrite");
            Console.WriteLine("2.Show BookWrite");
            Console.WriteLine("3.Show BookWrite by id");
            Console.WriteLine("4.Show BookWrite's Book");
            Console.WriteLine("5.Update BookWrite");
            Console.WriteLine("6.Remove BookWrite");
            Console.WriteLine("7.Create Book");
            Console.WriteLine("8.Update Book");
            Console.WriteLine("9.Get Book by BookWrite");
            Console.WriteLine("10.Remove Book");
            Console.WriteLine("11.Show All Books");
            Console.WriteLine("12.Buy Book");

            string Request = Console.ReadLine();

            while (Request != "0")
            {
                switch (Request)
                {
                    case "1":
                        Console.Clear();
                        await CreateBookWriter();

                        break;
                    case "2":
                        Console.Clear();

                        await ShowBookWriters();
                        break;

                    case "3":
                        Console.Clear();

                        await ShowBookWriterById();
                        break;

                    case "4":
                        Console.Clear();

                        await ShowBookWriterBooks();
                        break;

                    case "5":
                        Console.Clear();

                        await UpdateBookWriter();
                        break;

                    case "6":
                        Console.Clear();

                        await RemoveBookWriter();
                        break;

                    case "7":
                        Console.Clear();

                        await CreateBook();
                        break;

                    case "8":
                        Console.Clear();

                        await UpdateBook();
                        break;

                    case "9":
                        Console.Clear();

                        await GetBookByWriter();
                        break;

                    case "10":
                        Console.Clear();

                        await RemoveBook();
                        break;

                    case "11":
                        Console.Clear();

                        await ShowAllBooks();
                        break;
                    case "12":
                        Console.Clear();

                        await BuyBook();
                        break;

                    default:
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Select valid option");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine("0.Close App");
                Console.WriteLine("1.Create BookWrite");
                Console.WriteLine("2.Show BookWrite");
                Console.WriteLine("3.Show BookWrite by id");
                Console.WriteLine("4.Show BookWrite's Book");
                Console.WriteLine("5.Update BookWrite");
                Console.WriteLine("6.Remove BookWrite");
                Console.WriteLine("7.Create Book");
                Console.WriteLine("8.Update Book");
                Console.WriteLine("9.Get Book by BookWrite");
                Console.WriteLine("10.Remove Book");
                Console.WriteLine("11.Show All Books");
                Console.WriteLine("12.Buy Book");

                Request = Console.ReadLine();
            }
        }
        public async Task ShowMenuUser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string sentence = "Welcome to my App";

            foreach (var item in sentence)
            {
                Thread.Sleep(100);
                Console.Write(item);
            }

            Console.WriteLine("0.Close App");
            Console.WriteLine("1.Show BookWriter");
            Console.WriteLine("2.Show BookWriter by id");
            Console.WriteLine("3.Show BookWriter's Books");
            Console.WriteLine("4.Get Book by BookWriter");
            Console.WriteLine("5.Show All Books");

            string Request = Console.ReadLine();

            while (Request != "0")
            {
                switch (Request)
                {
                    case "1":
                        Console.Clear();
                        await CreateBookWriter();

                        break;
                    case "2":
                        Console.Clear();
                        await ShowBookWriterById();

                        break;

                    case "3":
                        Console.Clear();

                        await ShowBookWriterBooks();
                        break;

                    case "4":
                        Console.Clear();
                        await ShowBookWriterBooks();
                        break;

                    case "5":
                        Console.Clear();

                        await ShowAllBooks();
                        break;

                    default:
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Select valid option");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine("0.Close App");
                Console.WriteLine("1.Create BookWrite");
                Console.WriteLine("2.Show BookWrite");
                Console.WriteLine("3.Show BookWrite by id");
                Console.WriteLine("4.Show BookWrite's Book");
                Console.WriteLine("5.Update BookWrite");
                Console.WriteLine("6.Remove BookWrite");
                Console.WriteLine("7.Create Book");
                Console.WriteLine("8.Update Book");
                Console.WriteLine("9.Get Book by BookWrite");
                Console.WriteLine("10.Remove Book");
                Console.WriteLine("11.Show All Books");
                Console.WriteLine("12.Buy Book");


                Request = Console.ReadLine();
            }
        }
        private async Task CreateBookWriter()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add name");
            string name = Console.ReadLine();
            Console.WriteLine("add surname");
            string surname = Console.ReadLine();
            Console.WriteLine("add age");
            byte.TryParse(Console.ReadLine(), out byte age);

            string message = await _bookWriterService.CreateAsync(name, surname, age);

            Console.WriteLine(message);
        }
        private async Task BuyBook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add Bookwriter id");
            int.TryParse(Console.ReadLine(), out int BookId);
            Console.WriteLine("add Book id");
            int.TryParse(Console.ReadLine(), out int WriterId);
            string message = await _bookService.BuyBook(BookId, WriterId);
            Console.WriteLine(message);
        }
        private async Task ShowBookWriters()
        {
            await _bookWriterService.GetAllAsync();
        }

        private async Task ShowBookWriterById()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("add Bookwriter id");
            int.TryParse(Console.ReadLine(), out int id);

            BookWriter bookWriter = await _bookWriterService.GetAsync(id);

            if (bookWriter != null)
            {
                Console.WriteLine(bookWriter);
            }
        }
        private async Task ShowBookWriterBooks()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("add Bookwriter id");
            int.TryParse(Console.ReadLine(), out int id);


            List<Book> products = await _bookWriterService.GetAllBooksAsync(id);

            if (products != null)
            {
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("---------");
                }
            }
        }
        private async Task UpdateBookWriter()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("add Bookwriter id");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("add name");
            string name = Console.ReadLine();
            Console.WriteLine("add surname");
            string surname = Console.ReadLine();
            Console.WriteLine("add age");
            byte.TryParse(Console.ReadLine(), out byte age);
            string message = await _bookWriterService.UpdateAsync(id, name, surname, age);
            Console.WriteLine(message);
        }
        private async Task RemoveBookWriter()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("add Bookwriter id");
            int.TryParse(Console.ReadLine(), out int id);

            string message = await _bookWriterService.DeleteAsync(id);

            Console.WriteLine(message);
        }
        private async Task CreateBook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add Bookwriter id");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("add name");
            string name = Console.ReadLine();

            Console.WriteLine("add price");
            int.TryParse(Console.ReadLine(), out int price);

            Console.WriteLine("add discount price");
            int.TryParse(Console.ReadLine(), out int discountprice);

            Console.WriteLine("add discount description");
            string description = Console.ReadLine();
            Console.WriteLine("Add stock y/n");
            string stockstring = Console.ReadLine();
            bool InStock = false;
            if (stockstring.ToLower() == "y")
                InStock = true;
            else if (stockstring.ToLower() == "x")
                InStock = false;


            BookCategory category;
            Console.WriteLine("choose category");
            foreach (var item in Enum.GetValues(typeof(BookCategory)))
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int categoryindex);

            var result = Enum.GetName(typeof(BookCategory), categoryindex);

            while (result == null)
            {
                Console.WriteLine("choose valid category");
                int.TryParse(Console.ReadLine(), out categoryindex);
                result = Enum.GetName(typeof(BookCategory), categoryindex);
            }
            category = (BookCategory)categoryindex;

            string message = await _bookService.CreateAsync(id, name, price, InStock, discountprice, category);

            Console.WriteLine(message);
        }
        private async Task UpdateBook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add Bookwriter id");
            int.TryParse(Console.ReadLine(), out int BookId);
            Console.WriteLine("add Book id");
            int.TryParse(Console.ReadLine(), out int WriterId);
            Console.WriteLine("add name");
            string name = Console.ReadLine();
            Console.WriteLine("add price");
            double.TryParse(Console.ReadLine(), out double price);
            Console.WriteLine("add discount price");
            double.TryParse(Console.ReadLine(), out double discountprice);
            Console.WriteLine("Add stock y/n");
            string stockstring = Console.ReadLine();
            bool InStock = false;
            if (stockstring.ToLower() == "y")
                InStock = true;
            else if (stockstring.ToLower() == "x")
                InStock = false;
            string message = await _bookService.UpdateAsync(BookId, WriterId, name, price, InStock, discountprice);
            Console.WriteLine(message);
        }
        private async Task GetBookByWriter()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add BookWriter id");
            int.TryParse(Console.ReadLine(), out int resid);
            Console.WriteLine("add Book id");
            int.TryParse(Console.ReadLine(), out int prodid);
            Book book = await _bookService.GetAsync(resid, prodid);
            if (book != null)
            {
                Console.WriteLine(book);
            }
        }
        private async Task RemoveBook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add BookWriter id");
            int.TryParse(Console.ReadLine(), out int resid);
            Console.WriteLine("add Book id");
            int.TryParse(Console.ReadLine(), out int prodid);

            string message = await _bookService.DeleteAsync(resid, prodid);

            Console.WriteLine(message);
        }

        private async Task ShowAllBooks()
        {
            await _bookService.GetAllAsync();
        }
    }
}
