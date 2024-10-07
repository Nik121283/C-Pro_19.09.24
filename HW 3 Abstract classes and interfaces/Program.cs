// See https://aka.ms/new-console-template for more information

using HW_3_Abstract_classes_and_interfaces;

MyArray array1 = new MyArray(5);

array1.array[0] = 0;
array1.array[1] = 5;
array1.array[2] = 4;
array1.array[3] = 2;
array1.array[4] = 6;

Console.WriteLine("");
array1.Show();

array1.DeleteItem(1);

Console.WriteLine("");
array1.Show();

array1.AddItem(3);

array1.AddItem(7);

Console.WriteLine("");
array1.Show();

Console.WriteLine("\nMax");
Console.WriteLine(array1.Max());

Console.WriteLine("\nMin");
Console.WriteLine(array1.Min());

Console.WriteLine("\nAVG");
Console.WriteLine(array1.Avg());

Console.WriteLine("\nSearch 7 - must be true");
Console.WriteLine(array1.Search(7));

Console.WriteLine("\nSearch 9 - must be false");
Console.WriteLine(array1.Search(9));

Console.WriteLine("\nSort ASC");
array1.SortAsc();
array1.Show();

Console.WriteLine("\nSort DESC");
array1.SortDesc();
array1.Show();

Console.ReadLine();