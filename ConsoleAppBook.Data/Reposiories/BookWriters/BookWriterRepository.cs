using ConsoleAppBook.Core.Models;
using ConsoleAppBook.Core.Repositories.BookWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBook.Data.Reposiories.BookWriters
{
    public class BookWriterRepository : Repository<BookWriter>, IBookWriterRepository
    {
    }
}
