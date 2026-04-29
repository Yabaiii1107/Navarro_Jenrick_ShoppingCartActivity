using System;

namespace ConsoleApp5
{
    class Program
    {
      static void Main(string[] args)
        { 
            Product[] products = new Product[]
            {
                new Product { id=101, name="Instant Noodles Pack", category="Food", price=120, remainingStock=20 },
                new Product { id=102, name="Chocolate Bar", category="Food", price=50, remainingStock=25 },
                new Product { id=103, name="Bottled Water 1L", category="Food", price=30, remainingStock=30 },
                new Product { id=201, name="Plain T-Shirt", category="Clothing", price=300, remainingStock=15 },
                new Product { id=202, name="Jeans Pants", category="Clothing", price=900, remainingStock=8 },
                new Product { id=203, name="Hoodie Jacket", category="Clothing", price=1200, remainingStock=6 },
                new Product { id=301, name="Notebook", category="School Supplies", price=60, remainingStock=18 },
                new Product { id=302, name="Ballpen (Blue)", category="School Supplies", price=15, remainingStock=50 },
                new Product { id=303, name="Backpack", category="School Supplies", price=850, remainingStock=9 }
            };
      }
    }
}
