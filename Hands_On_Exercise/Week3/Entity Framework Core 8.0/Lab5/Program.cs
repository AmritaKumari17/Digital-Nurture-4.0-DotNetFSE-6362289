using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();
        // 1️. Retrieve all products
        Console.WriteLine("📦 All Products:");
        var products = await context.Products.Include(p => p.Category).ToListAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price} ({p.Category?.Name})");
        }
        Console.WriteLine();

        // 2️. Find by ID
        Console.WriteLine("🔍 Find Product by ID = 1:");
        var product = await context.Products.FindAsync(1);
        Console.WriteLine($"Found: {product?.Name}");
        Console.WriteLine();

        // 3️. FirstOrDefault with condition
        Console.WriteLine("💰 First Expensive Product (Price > 50,000):");
        var expensive = await context.Products
                                     .Include(p => p.Category)
                                     .FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive: {expensive?.Name} - ₹{expensive?.Price} ({expensive?.Category?.Name})");
        Console.WriteLine("\n✅ Data retrieval complete.");
    }
}
