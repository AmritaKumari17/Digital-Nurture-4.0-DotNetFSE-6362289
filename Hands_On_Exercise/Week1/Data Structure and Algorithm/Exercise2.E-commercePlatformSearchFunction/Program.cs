using System;
using System.Linq;

class Product
{
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}

class Program
{
    // Linear Search by Product ID
    static Product LinearSearch(Product[] products, int id)
    {
        foreach (var product in products)
        {
            if (product.ProductId == id)
                return product;
        }
        return null;
    }

    // Binary Search by Product ID
    static Product BinarySearch(Product[] products, int id)
    {
        int left = 0, right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (products[mid].ProductId == id)
                return products[mid];
            else if (products[mid].ProductId < id)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    static void Main(string[] args)
    {
        Product[] products = {
            new Product(1, "Laptop", "Electronics"),
            new Product(4, "Phone", "Electronics"),
            new Product(2, "Shoes", "Fashion"),
            new Product(5, "Book", "Education"),
            new Product(3, "Tablet", "Electronics")
        };

        Console.Write("Enter Product ID to search: ");
        int idToFind = int.Parse(Console.ReadLine());

        Console.WriteLine("\n Linear Search:");
        var result1 = LinearSearch(products, idToFind);
        Console.WriteLine(result1 != null ? result1.ToString() : "Product not found");

        // For Binary Search, sort by ProductId
        var sortedProducts = products.OrderBy(p => p.ProductId).ToArray();
        Console.WriteLine("\n Binary Search:");
        var result2 = BinarySearch(sortedProducts, idToFind);
        Console.WriteLine(result2 != null ? result2.ToString() : "Product not found");
    }
}
