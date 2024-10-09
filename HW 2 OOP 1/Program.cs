// See https://aka.ms/new-console-template for more information


using HW_2_OOP;

Money money1 = new Money(12.54f);

Console.WriteLine("\nShow money1");

money1.ShowAccountStatement();


Console.WriteLine("\n\nCreate Product");
Product product1 = new Product("Milk", "Молоко Злагода жирность 3,2%", 46.50f);

Console.WriteLine("\nShow Product");
product1.ShowProductInfo();

Console.WriteLine("\n\nMake higher Product price. Must Be 56.70");
product1.MakeHigherPrice(10.20f);

Console.WriteLine("\nShow Product");
product1.ShowProductInfo();


Console.WriteLine("\n\nMake lower Product price. Must Be 48.60");
product1.MakeLowerPrice(8.10f);

Console.WriteLine("\nShow Product");
product1.ShowProductInfo();

Console.WriteLine("\n\nCreate Product2");
Product product2 = new Product("Pepsi", "напиток безалкогольный", 32.75f);
product2.ShowProductInfo();