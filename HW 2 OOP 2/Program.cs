// See https://aka.ms/new-console-template for more information

using OOP_2;

Musical_instrument scripka1 = new Scripka("скрипка", "струнный инструмент", "созданн в 17 веке");

Musical_instrument trombon1 = new Trombon("тромбон", "духовой инструмент", "созданн в 19 веке");

Musical_instrument ukulele1 = new Ukulele("укулеле", "неизвестный инструмент", "созданн в 14 веке");

Musical_instrument violence1 = new Violence("виолончель", "струнный инструмент", "созданн в 19 веке");


Console.WriteLine("\nПроверка звука каждого инструмента");

Console.WriteLine("\nСкрипка");
scripka1.ShowName();
scripka1.ShowDescription();
scripka1.ShowHistory();
scripka1.MakeSound();

Console.WriteLine("\nТромбон");
trombon1.ShowName();
trombon1.ShowDescription();
trombon1.ShowHistory();
trombon1.MakeSound();

Console.WriteLine("\nУкулеле");
ukulele1.ShowName();
ukulele1.ShowDescription();
ukulele1.ShowHistory();
ukulele1.MakeSound();

Console.WriteLine("\nВиолончель");
violence1.ShowName();
violence1.ShowDescription();
violence1.ShowHistory();
violence1.MakeSound();