using wt_lab5_5razor_ostashevskaya.Data;
using wt_lab5_5razor_ostashevskaya.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab5_5razor_ostashevskaya.Pages.Products;

public class CreateModel : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = new()
    {
        ReceivedAt = DateTime.Today,
        IsAvailable = true
    };

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        ProductStore.Add(Product);
        TempData["Success"] = $"Товар «{Product.Name}» добавлен в каталог.";
        return RedirectToPage("./Index");
    }
}
