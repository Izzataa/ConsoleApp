using ConsoleAppBook.Core.Enums;
using ConsoleAppBook.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppBook.Core.Models
{
    public class Book : BaseModel
    {
        private static int _id;
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public BookWriter BookWriter { get; set; }
        public bool InStock { get; set; }

        public BookCategory BookCategory { get; set; }



        public Book(string name, double price, double discountPrice, bool inStock, BookCategory BookCategoryEnum)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            DiscountPrice = discountPrice;
            CreatedDate = DateTime.UtcNow.AddHours(4);
            InStock = inStock;
            BookCategory = BookCategoryEnum;
        }
        public override string ToString()
        {
            if (DiscountPrice < Price)
            {
                return $"there is  {Price - DiscountPrice} discount   Name: {Name}, Price: {DiscountPrice}, Category: {BookCategory} stock: {InStock},CreateDate: {CreatedDate}, UpdateDate: {UpdatedDate}";
            }


            return $"Name: {Name}, Price: {Price}, Category: {BookCategory} stock: {InStock},CreateDate: {CreatedDate}, UpdateDate: {UpdatedDate}";
        }

    }
}
