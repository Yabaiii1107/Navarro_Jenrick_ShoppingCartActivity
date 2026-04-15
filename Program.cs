using System;

class Product
{
  public int Id;
  public string Name;
  public double Price;
  public int RemainingStock;

  public void DisplayProduct()
  {
    Console.WriteLine(($"{Id}. {Name} - ₱{Price} (Stock: {RemainingStock})");
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
                          
