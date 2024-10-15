// See https://aka.ms/new-console-template for more information

using HW5_Garbage_collector;

Console.WriteLine("Тестируем класс Play");

Play play1 = new Play("Евгений Онегин", "А.С. Пушкин", "Роман", 1831);

play1.Show();

Play play2 = new Play("Евгений Онегин2", "А.С. Пушкин2", "Роман2", 1832);

play1 = play2;

GC.Collect ();
GC.WaitForPendingFinalizers();


Console.WriteLine("\nТестируем класс Shop");

Shop shop1 = new Shop("Хозяюшка", "Ленина 1в", "хоз товары");
shop1.Show();
shop1.Dispose ();

using(Shop shop2 = new Shop("Продмаркет", "Корнела 2", "продукты"))
{
    shop2.Show ();
}


Console.ReadLine ();
