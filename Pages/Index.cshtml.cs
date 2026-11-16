using wt_lab5_5razor_ostashevskaya.Data;
using wt_lab5_5razor_ostashevskaya.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab5_5razor_ostashevskaya.Pages;

public class IndexModel : PageModel
{
    public IReadOnlyList<Product> LatestProducts { get; private set; } = Array.Empty<Product>();

    public int ProductCount { get; private set; }

    public int TotalQuantity { get; private set; }

    public decimal TotalValue { get; private set; }

    public int CategoryCount { get; private set; }

    public void OnGet()
    {
        var products = ProductStore.Products;

        ProductCount = products.Count;
        TotalQuantity = products.Sum(product => product.Quantity);
        TotalValue = products.Sum(product => product.TotalValue);
        CategoryCount = products.Select(product => product.Category).Distinct().Count();
        LatestProducts = products
            .OrderByDescending(product => product.ReceivedAt)
            .Take(3)
            .ToList();
    }
}
