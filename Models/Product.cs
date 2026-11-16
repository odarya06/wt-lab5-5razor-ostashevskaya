using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_ostashevskaya.Models;

/// <summary>
/// Товар на складе — основная сущность предметной области «Складской учёт».
/// Модель перенесена из лабораторной работы WT-4 (ASP.NET Core MVC).
/// </summary>
public class Product
{
    [Display(Name = "ID")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Укажите наименование товара")]
    [StringLength(100, ErrorMessage = "Наименование — не более 100 символов")]
    [Display(Name = "Наименование")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите артикул")]
    [StringLength(20, ErrorMessage = "Артикул — не более 20 символов")]
    [Display(Name = "Артикул")]
    public string Sku { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите категорию")]
    [StringLength(50, ErrorMessage = "Категория — не более 50 символов")]
    [Display(Name = "Категория")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите поставщика")]
    [StringLength(100, ErrorMessage = "Поставщик — не более 100 символов")]
    [Display(Name = "Поставщик")]
    public string Supplier { get; set; } = string.Empty;

    [Range(0, 100_000, ErrorMessage = "Количество должно быть от 0 до 100 000")]
    [Display(Name = "Количество, шт.")]
    public int Quantity { get; set; }

    [Range(0.01, 1_000_000, ErrorMessage = "Цена должна быть от 0,01 до 1 000 000 BYN")]
    [Display(Name = "Цена, BYN")]
    public decimal Price { get; set; }

    [StringLength(300, ErrorMessage = "Описание — не более 300 символов")]
    [Display(Name = "Описание")]
    public string? Description { get; set; }

    [Display(Name = "Доступен к продаже")]
    public bool IsAvailable { get; set; } = true;

    [DataType(DataType.Date)]
    [Display(Name = "Дата поступления")]
    public DateTime ReceivedAt { get; set; } = DateTime.Today;

    /// <summary>Стоимость товара на складе (цена × количество).</summary>
    [Display(Name = "Стоимость партии")]
    public decimal TotalValue => Price * Quantity;
}
