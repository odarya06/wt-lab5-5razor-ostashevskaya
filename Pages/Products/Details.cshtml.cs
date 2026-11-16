using wt_lab5_5razor_ostashevskaya.Data;
using wt_lab5_5razor_ostashevskaya.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab5_5razor_ostashevskaya.Pages.Products;

public class DetailsModel : PageModel
{
    public Product? Product { get; private set; }

    public IActionResult OnGet(int id)
    {
        Product = ProductStore.Find(id);
        if (Product is null)
        {
            return NotFound();
        }

        return Page();
    }
}
