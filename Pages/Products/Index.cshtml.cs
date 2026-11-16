using wt_lab5_5razor_ostashevskaya.Data;
using wt_lab5_5razor_ostashevskaya.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab5_5razor_ostashevskaya.Pages.Products;

public class IndexModel : PageModel
{
    public List<Product> Products { get; private set; } = new();

    public decimal TotalValue { get; private set; }

    public void OnGet()
    {
        Products = ProductStore.Products.OrderBy(product => product.Id).ToList();
        TotalValue = Products.Sum(product => product.TotalValue);
    }
}
