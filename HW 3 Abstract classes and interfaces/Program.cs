// See https://aka.ms/new-console-template for more information

using HW_3_Abstract_classes_and_interfaces;

MyArray array1 = new MyArray(3);

array1.array[0] = 0;
array1.array[1] = 1;
array1.array[2] = 2;

Console.WriteLine("");
array1.Show();

array1.DeleteItem(1);

Console.WriteLine("");
array1.Show();

array1.AddItem(3);

Console.WriteLine("");
array1.Show();

Console.WriteLine("Max");
Console.WriteLine(array1.Max());

Console.WriteLine("Min");
Console.WriteLine(array1.Min());

Console.WriteLine("AVG");
Console.WriteLine(array1.Avg());