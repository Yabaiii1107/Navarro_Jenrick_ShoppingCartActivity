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

            CartItem[] cart = new CartItem[15];
            int cartCount = 0;
            int menu;

            do
            {
                Console.WriteLine("\nID  | Name                      | Category           |   Price | Stock");
                Console.WriteLine("--------------------------------------------------------------------------");
                for (int i = 0; i < products.Length; i++)
                {
                    products[i].DisplayProduct();
                }

                Console.WriteLine("\n=== MAIN MENU ===");
                Console.WriteLine("1. Add a Product");
                Console.WriteLine("2. Cart");
                Console.WriteLine("3. Search Product Name");
                Console.WriteLine("4. Search Product Category");
                Console.WriteLine("5. Checkout");
                Console.WriteLine("6. Exit");

                Console.Write("Enter Choice (1-6): ");
                if (!int.TryParse(Console.ReadLine(), out menu))
                {
                    Console.WriteLine("Invalid Input. Input must be a number ranging from 1-6 only.\n");
                    continue;
                }

                switch (menu)
                {
                    case 1:
                        int id;
                        int index;
                        string addMore;
                        Console.WriteLine("\n=== ADD A PRODUCT ===");
                        do
                        {
                            while (true)
                            {
                                Console.Write("Enter Product ID: ");
                                if (!int.TryParse(Console.ReadLine(), out id))
                                {
                                    Console.WriteLine("Invalid Input. Please Enter a Valid ID Number.\n");
                                    continue;
                                }

                                index = -1;

                                for (int i = 0; i < products.Length; i++)
                                {
                                    if (products[i].id == id)
                                    {
                                        index = i;
                                        break;
                                    }
                                }

                                if (index == -1)
                                {
                                    Console.WriteLine("Product Not Found.\n");
                                    continue;
                                }

                                break;
                            }

                            int qty;

                            while (true)
                            {
                                Console.Write("Enter Quantity: ");
                                if (!int.TryParse(Console.ReadLine(), out qty) || qty == 0)
                                {
                                    Console.WriteLine("Invalid Quantity. Please Enter a Valid Quantity.");
                                    continue;
                                }

                                if (!products[index].HasEnoughStock(qty))
                                {
                                    Console.WriteLine("Not Enough Stock.");
                                    continue;
                                }

                                break;
                            }

                            products[index].DeductStock(qty);

                            cart[cartCount++] = new CartItem
                            {
                                product = products[index],
                                quantity = qty,
                                subTotal = qty * products[index].price
                            };

                            Console.WriteLine("\nItem Succesfully Added To Cart.");
                            while (true)
                            {
                                Console.Write("\nDo You Want To Add More Items?(Y/N): ");
                                addMore = Console.ReadLine().ToUpper().Trim();
                                if (addMore == "Y" || addMore == "N")
                                    break;

                                Console.WriteLine("Invalid Input. Please Enter Y or N only.\n");
                            }

                        } while (addMore == "Y");
                        break;
                }

            } while (menu != 6);
        }
     class Product
        {
            public int id;
            public string name;
            public string category;
            public double price;
            public int remainingStock;

            public void DisplayProduct()
            {
                Console.WriteLine(
                    $"{id,-3} | {name,-25} | {category,-18} | ₱{price,8:F2} | {remainingStock,5}"
                );
            }

            public bool HasEnoughStock(int qty)
            {
                return remainingStock >= qty;
            }

            public void DeductStock(int qty)
            {
                remainingStock -= qty;
            }

        }
     class CartItem
     {
       public Product product;
       public int quantity;
       public double subTotal;

       public void DisplayCartItem(int index)
       {
         Console.WriteLine(
              $"{index + 1,-3} | {product.name,-25} | {quantity,3} | ₱{product.price,8:F2} | ₱{subTotal,8:F2}"
         );
       }
     }
    }
    }
