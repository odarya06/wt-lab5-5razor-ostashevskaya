using wt_lab5_5razor_ostashevskaya.Models;

namespace wt_lab5_5razor_ostashevskaya.Helpers;

/// <summary>Помощники оформления: валюта, статусы, иконки категорий.</summary>
public static class DisplayHelper
{
    /// <summary>Цена в белорусских рублях: без копеек для целых сумм, с копейками — для дробных.</summary>
    public static string ToByn(this decimal value) => value == decimal.Truncate(value)
        ? $"{value:N0} BYN"
        : $"{value:N2} BYN";

    public static string CategoryIcon(string category) => category switch
    {
        "Компьютеры" => "💻",
        "Аксессуары" => "🖱️",
        "Мебель" => "🪑",
        "Расходники" => "📄",
        _ => "📦"
    };

    public static string StatusText(Product product) => product.Quantity == 0
        ? "Нет в наличии"
        : !product.IsAvailable
            ? "Снят с продажи"
            : product.Quantity <= 10
                ? "Мало на складе"
                : "В наличии";

    public static string StatusBadgeClass(Product product) => product.Quantity == 0
        ? "bg-danger"
        : !product.IsAvailable
            ? "bg-secondary"
            : product.Quantity <= 10
                ? "bg-warning text-dark"
                : "bg-success";
}
