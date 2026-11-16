using wt_lab5_5razor_ostashevskaya.Data;
using wt_lab5_5razor_ostashevskaya.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab5_5razor_ostashevskaya.Pages.Products;

public class EditModel : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var existing = ProductStore.Find(id);
        if (existing is null)
        {
            return NotFound();
        }

        Product = existing;
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Product.Id = id;
        if (!ProductStore.Update(Product))
        {
            return NotFound();
        }

        TempData["Success"] = $"Изменения товара «{Product.Name}» сохранены.";
        return RedirectToPage("./Details", new { id });
    }
}
