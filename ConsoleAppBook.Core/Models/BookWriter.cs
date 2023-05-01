using ConsoleAppBook.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppBook.Core.Models
{
    public class BookWriter : BaseModel
    {
        private static int _id;
        public string Surname { get; set; }
        public byte Age { get; set; }
        public List<Book> Books { get; set; }
        public BookWriter(string name, string surname, byte age)
        {
            _id++;
            Id = _id;
            Name = name;
            Surname = surname;
            Age = age;
            Books = new List<Book>();
            CreatedDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Age: {Age},CreateDate: {CreatedDate}, UpdateDate: {UpdatedDate}";
        }
    }
}
