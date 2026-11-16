using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace wt_lab5_5razor_ostashevskaya.Infrastructure;

/// <summary>
/// Принимает десятичные числа и с точкой, и с запятой.
/// Пользователь может ввести цену в любом привычном формате, а браузер и текущая
/// культура могут использовать разные разделители, поэтому стандартного
/// связывания с одной культурой недостаточно.
/// </summary>
public sealed class InvariantDecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (valueResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueResult);
        var rawValue = valueResult.FirstValue;

        if (string.IsNullOrWhiteSpace(rawValue))
        {
            return Task.CompletedTask;
        }

        if (TryParsePrice(rawValue, out var value))
        {
            bindingContext.Result = ModelBindingResult.Success(value);
        }
        else
        {
            bindingContext.ModelState.TryAddModelError(
                bindingContext.ModelName,
                "Введите корректную цену, например 2490 или 2490,50");
        }

        return Task.CompletedTask;
    }

    // Разделитель тысяч не разрешаем на первом шаге, иначе «123,45» разберётся
    // как 12 345: в инвариантной культуре запятая — это разделитель тысяч.
    private static bool TryParsePrice(string rawValue, out decimal value)
    {
        const NumberStyles decimalOnly =
            NumberStyles.AllowLeadingWhite |
            NumberStyles.AllowTrailingWhite |
            NumberStyles.AllowLeadingSign |
            NumberStyles.AllowDecimalPoint;

        return decimal.TryParse(rawValue, decimalOnly, CultureInfo.CurrentCulture, out value)
            || decimal.TryParse(rawValue, decimalOnly, CultureInfo.InvariantCulture, out value)
            || decimal.TryParse(rawValue, NumberStyles.Number, CultureInfo.CurrentCulture, out value)
            || decimal.TryParse(rawValue, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
    }
}

public sealed class InvariantDecimalModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
        {
            return new InvariantDecimalModelBinder();
        }

        return null;
    }
}
