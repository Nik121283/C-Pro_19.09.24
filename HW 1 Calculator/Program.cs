// See https://aka.ms/new-console-template for more information
using HW_1_Calculator;

Console.WriteLine("Тестим калькулятор");

Console.WriteLine($"\nСкладываем 1 + 2 = {Calculator<int>.Add(1, 2)}");

Console.WriteLine($"\nВычитаем из 5,7 - 2,1 = {Calculator<Double>.Subtract(5.7, 2.1)}");

Console.WriteLine($"\nУмножаем  5,5 Х 10 = {Calculator<Double>.Multiply(5.5, 10)}");

Console.WriteLine($"\nДелим  5,5 / 2 = {Calculator<Double>.Divide(5.5,2)}");