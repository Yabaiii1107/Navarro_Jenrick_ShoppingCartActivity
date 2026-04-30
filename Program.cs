using System;

namespace ConsoleApp5
{
    class Program
    {
        static void DisplayCartHeader()
        {
            Console.WriteLine("\nNo  | Name                      | Qty |   Price | Subtotal");
            Console.WriteLine("--------------------------------------------------------------------------");
        }

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
            bool showProducts = true;

            do
            {
                 if (showProducts)
                {
                    Console.WriteLine("\nID  | Name                      | Category           |   Price | Stock");
                    Console.WriteLine("--------------------------------------------------------------------------");

                    for (int i = 0; i < products.Length; i++)
                    {
                        products[i].DisplayProduct();
                    }

                    showProducts = false; 
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
                    Console.WriteLine("Invalid Input. Input must be a number ranging from 1-6 only.");
                    continue;
                }

                if (menu > 6)
                {
                    Console.WriteLine("Invalid Input. Input must be a number ranging from 1-6 only.");
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
                                Console.Write("\nEnter Quantity: ");
                                if (!int.TryParse(Console.ReadLine(), out qty) || qty == 0)
                                {
                                    Console.WriteLine("Invalid Quantity. Please Enter a Valid Quantity.");
                                    continue;
                                }

                                if (!products[index].HasEnoughStock(qty))
                                {
                                    Console.WriteLine("Not Enough Stock.\n");
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
                                addMore = Console.ReadLine();

                                addMore = addMore.ToUpper().Trim();

                                if (addMore == "Y" || addMore == "N")
                                {
                                    break;
                                }

                                Console.WriteLine("Invalid Input. Please Enter Y or N.");
                            }
                        } while (addMore == "Y");
                        break;

                     case 2:
                        int cartMenu;
                        do
                        {
                            Console.WriteLine("\n=== CART MENU ===");
                            Console.WriteLine("1. View Cart");
                            Console.WriteLine("2. Remove Cart Item");
                            Console.WriteLine("3. Update Quantity");
                            Console.WriteLine("4. Clear Cart");
                            Console.WriteLine("5. Back");

                            Console.Write("Enter Choice(1-5): ");
                            if (!int.TryParse(Console.ReadLine(), out cartMenu))
                            {
                                Console.WriteLine("Invalid Input. Input must be a number ranging from 1-5 only.");
                                continue;
                            }

                            if (cartMenu > 5)
                            {
                                Console.WriteLine("Invalid Input. Input must be a number ranging from 1-5 only.");
                            }

                            switch (cartMenu)
                            {
                                case 1:
                                    Console.WriteLine("\n=== VIEW CART ===");

                                    if (cartCount == 0)
                                    {
                                        Console.WriteLine("Your Cart is Empty.");
                                        break;
                                    }

                                    DisplayCartHeader();
                                    for (int i = 0; i < cartCount; i++)
                                    {
                                        cart[i].DisplayCartItem(i);
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("\n=== REMOVE CART ITEM ===");
                                    if (cartCount == 0)
                                    {
                                      Console.WriteLine("Your Cart is Empty.");
                                      break;
                                    }

                                    DisplayCartHeader();
                                    for (int i = 0; i < cartCount; i++)
                                    {
                                        cart[i].DisplayCartItem(i);
                                    }

                                    int removeIndex;

                                    while (true)
                                    {
                                        Console.Write("\nEnter Item Number to Remove: ");
                                        if (!int.TryParse(Console.ReadLine(), out removeIndex))
                                        {
                                            Console.WriteLine("Invalid Input. Please Enter a Number.");
                                            continue;
                                        }

                                        removeIndex--;

                                        if (removeIndex < 0 || removeIndex >= cartCount)
                                        {
                                            Console.WriteLine("Invalid Item Number. Please Try Again.");
                                            continue;
                                        }

                                        break;
                                    }
                                    cart[removeIndex].product.remainingStock += cart[removeIndex].quantity;

                                    for (int i = removeIndex; i < cartCount; i++)
                                    {
                                        cart[i] = cart[i + 1];
                                    }

                                    cartCount--;
                                    Console.WriteLine("\nItem is Removed Successfully.");
                                    break;

                                case 3:
                                    int updateIndex;
                                    int newQuantity;

                                    Console.WriteLine("\n=== UPDATE QUANTITY ===");

                                    if (cartCount == 0)
                                    {
                                        Console.WriteLine("Cart is Empty.");
                                        break;
                                    }

                                    DisplayCartHeader();
                                    for (int i = 0; i < cartCount; i++)
                                    {
                                        cart[i].DisplayCartItem(i);
                                    }

                                    while (true)
                                    {
                                        Console.Write("\nEnter Item Number To Update: ");

                                        if (!int.TryParse(Console.ReadLine(), out updateIndex))
                                        {
                                            Console.WriteLine("Invalid Input. Please Enter a Number.");
                                            continue;
                                        }

                                        updateIndex--;

                                        if (updateIndex < 0 || updateIndex >= cartCount)
                                        {
                                            Console.WriteLine("Invalid Item Number. Please Try Again.");
                                            continue;
                                        }

                                        break;
                                    }

                                    Product product = cart[updateIndex].product;

                                    product.remainingStock += cart[updateIndex].quantity;

                                    while (true)
                                    {
                                        Console.Write("Enter New Quantity: ");

                                        if (!int.TryParse(Console.ReadLine(), out newQuantity))
                                        {
                                            Console.WriteLine("Invalid Input. Please Enter a Number.");
                                            continue;
                                        }

                                        if (newQuantity <= 0)
                                        {
                                            Console.WriteLine("Quantity Must be Greater Than 0.");
                                            continue;
                                        }

                                        if (!product.HasEnoughStock(newQuantity))
                                        {
                                            Console.WriteLine("Not enough stock.");

                                            product.remainingStock -= cart[updateIndex].quantity;
                                            continue;
                                        }

                                        break;
                                    }

                                    product.DeductStock(newQuantity);

                                    cart[updateIndex].quantity = newQuantity;
                                    cart[updateIndex].subTotal = newQuantity * product.price;

                                    Console.WriteLine("Quantity Updated.");
                                    break;

                                case 4:
                                    string sureChoice;
                                    Console.WriteLine("\n=== CLEAR CART ===");
                                    if (cartCount == 0)
                                    {
                                        Console.WriteLine("Cart is empty.");
                                        break;
                                    }

                                    while (true)
                                    {
                                        Console.Write("Are you sure you want to remove all items in your cart?(Y/N): ");
                                        sureChoice = Console.ReadLine().ToUpper().Trim();

                                        if (sureChoice == "Y")
                                        {
                                            for (int i = 0; i < cartCount; i++)
                                            {
                                                cart[i].product.remainingStock += cart[i].quantity;
                                            }

                                            cartCount = 0;
                                            Console.WriteLine("Cart cleared successfully.");
                                            break;
                                        }
                                        else if (sureChoice == "N")
                                            break;
                                        else
                                        {
                                            Console.WriteLine("\nInvalid Input. Please Enter Y or N.\n");
                                            continue;
                                        }
                                  
                                    }
                                    break;

                                case 5:
                                    Console.WriteLine("Returning to Main Menu...");
                                    break;
                            }
                        } while (cartMenu != 5);
                        break;
                }
            }while (menu != 6);
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

            public bool HasEnoughStock (int qty)
            {
                return remainingStock >= qty;
            }

            public void DeductStock (int qty)
            {
                remainingStock -= qty;
            }
        }

        class CartItem
        {
            public Product product;
            public int quantity;
            public double subTotal;

            public void DisplayCartItem (int index)
            {
                Console.WriteLine(
                    $"{index + 1,-3} | {product.name,-25} | {quantity,3} | ₱{product.price,8:F2} | ₱{subTotal,8:F2}"
                );
            }
        }
    }
}
        

    
