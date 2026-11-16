# WT-5 Razor Pages

Веб-приложение «Складской учёт» на ASP.NET Core 8 с использованием **Razor Pages**.
Предметная область — склад, основная сущность — `Product` (товар).
Данные хранятся в памяти приложения (`Data/ProductStore.cs`), база данных не используется.
Все суммы отображаются в белорусских рублях (BYN).

## Возможности

- главная страница со сводной статистикой по складу;
- каталог товаров в виде Bootstrap-карточек и таблицы;
- добавление товара (GET + POST, валидация, `[BindProperty]`);
- страница деталей товара;
- редактирование товара (GET + POST);
- удаление товара с подтверждением (POST);
- единая навигация и адаптивное оформление (Bootstrap 5);
- цена принимается и с точкой, и с запятой (`123.45` / `123,45`).

## Структура проекта

```
Models/Product.cs                 модель предметной области
Data/ProductStore.cs              общее хранилище товаров в памяти
Pages/Index.cshtml(.cs)           главная страница
Pages/Products/Index.cshtml(.cs)  каталог товаров
Pages/Products/Create.cshtml(.cs) добавление товара
Pages/Products/Details.cshtml(.cs) детали товара
Pages/Products/Edit.cshtml(.cs)   редактирование
Pages/Products/Delete.cshtml(.cs) удаление
Pages/Shared/_Layout.cshtml       общий layout и навигация
Dockerfile                        сборка и запуск в контейнере
```

## Запуск локально

Требуется .NET SDK 8.0.

```bash
dotnet restore
dotnet run
```

Приложение слушает порт из переменной окружения `PORT` (по умолчанию `10000`):

- http://localhost:10000/
- http://localhost:10000/Products/Index
- http://localhost:10000/Products/Create
- http://localhost:10000/Products/Details?id=1

## Docker

```bash
docker build -t wt-lab5-5razor-ostashevskaya .
docker run --rm -p 10000:10000 wt-lab5-5razor-ostashevskaya
```

## Репозиторий

https://github.com/odarya06/wt-lab5-5razor-ostashevskaya

## Опубликованное приложение

Render: https://wt-lab5-5razor-ostashevskaya.onrender.com
