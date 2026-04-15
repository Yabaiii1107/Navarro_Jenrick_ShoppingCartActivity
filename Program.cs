using System;

class Product
{
  public int Id;
  public string Name;
  public double Price;
  public int RemainingStock;
  
  public void DisplayStock()
  {
    Console.WriteLine($"{Id}. {Name} - \n(Stock Left: {RemainingStock})");
  }

  public void DisplayProduct()
  {
    Console.WriteLine($"{Id}. {Name} - \nPrice: ₱{Price} \nStock: {RemainingStock}");
  }

  public double GetItemTotal(int quantity)
  {
    return Price * quantity;
  }

  public bool HasEnoughStock(int quantity)
  {
    return quantity <= RemainingStock;
  }

  public void DeductStock(int quantity)
  {
     RemainingStock -= quantity;  
  }
                      
class CartItem
{
    public Product product;
    public int quantity;
    public double subtotal;
}

class Program
{
    static void Main()
    {
        Product[] store = new Product[]
        {
            new Product{ Id=1, Name="ASUS ProArt X870E-CREATOR WIFI ATX Motherboard", Price=31100, RemainingStock=5 },
            new Product{ Id=2, Name="AMD Ryzen™ 3 3200G Processor with Radeon™ Vega 8 Graphics", Price=3800, RemainingStock=10 },
            new Product{ Id=3, Name="ASUS Dual GeForce RTX™ 5050 OC Edition 8GB GDDR6 128-bit Graphics Card", Price=22400, RemainingStock=8 },
            new Product{ Id=4, Name="KINGSTON 16GB DDR4 3200MHZ FURY BEAST RAM", Price=9800, RemainingStock=6 },
            new Product{ Id=5, Name="ANTEC ATOM B650 650W 80+ BRONZE Non-Modular True Rated Power Supply", Price=3087, RemainingStock=2 },
            new Product{ Id=6, Name="ADATA 1TB LEGEND 710 M.2 PCIe NVMe (ALEG-710-1TCS) Solid State Drive", Price=9500, RemainingStock=4 },
        };
        CartItem[] cart = new CartItem[5];
        int cartCount = 0;

        string choice = "Y";

        do
        {
            Console.WriteLine("\n=== STORE MENU ===");
            for (int i = 0; i < store.Length; i++)
            {
                store[i].DisplayProduct();
            }

            Console.Write("Enter product number: ");
            if (!int.TryParse(Console.ReadLine(), out int productNum) || productNum < 1 || productNum > store.Length)
            {
                Console.WriteLine("Invalid product number.");
                continue;
            }

            Product selected = store[productNum - 1];

            if (selected.RemainingStock == 0)
            {
                Console.WriteLine("Product is out of stock.");
                continue;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                continue;
            }

            if (!selected.HasEnoughStock(qty))
            {
                Console.WriteLine("Not enough stock available.");
                continue;
            }

            bool found = false;
            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i].product.Id == selected.Id)
                {
                    cart[i].quantity += qty;
                    cart[i].subtotal += selected.GetItemTotal(qty);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                if (cartCount >= cart.Length)
                {
                    Console.WriteLine("Cart is full.");
                    continue;
                }

                cart[cartCount] = new CartItem
                {
                    product = selected,
                    quantity = qty,
                    subtotal = selected.GetItemTotal(qty)
                };
                cartCount++;
            }

            selected.DeductStock(qty);
            Console.WriteLine("Item added to cart!");

            Console.Write("Add another item? (Y/N): ");
            choice = Console.ReadLine();

            if (choice.ToUpper()== "N")
            {
                double grandTotal = 0;
                Console.WriteLine("\n=== RECEIPT ===");

                for (int i = 0; i < cartCount; i++)
                {
                    Console.WriteLine($"x{cart[i].quantity} {cart[i].product.Name} = ₱{cart[i].subtotal}");
                    grandTotal += cart[i].subtotal;
                }

                Console.WriteLine($"Grand Total: ₱{grandTotal}");
              
                double finalTotal = grandTotal - discount;
                Console.WriteLine($"Final Total: ₱{finalTotal}");

                Console.WriteLine("\n=== UPDATED STOCK ===");
                for (int i = 0; i < store.Length; i++)
                {
                    store[i].DisplayStock();
                }

                Console.WriteLine("\nProgram End.");
            }
        
        } while (choice.ToUpper() == "Y");
    }
}
                          
