using wt_lab5_5razor_ostashevskaya.Data;
using wt_lab5_5razor_ostashevskaya.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab5_5razor_ostashevskaya.Pages.Products;

public class DeleteModel : PageModel
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

    public IActionResult OnPost(int id)
    {
        var product = ProductStore.Find(id);
        if (product is null)
        {
            return NotFound();
        }

        ProductStore.Remove(id);
        TempData["Success"] = $"Товар «{product.Name}» удалён из каталога.";
        return RedirectToPage("./Index");
    }
}
