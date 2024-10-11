﻿// See https://aka.ms/new-console-template for more information


using HW_4_Operators_reload;

Console.WriteLine("Создаем сотрудника");
Employee emp1 = new Employee("Ivan", "Ivanov", 18000);
emp1.Show();

Console.WriteLine("\nДобавляем 2000 к зарплате");
emp1 = emp1 + 2000;
emp1.Show();

Console.WriteLine("\nОтнимаем 500 от зарплаты");
emp1 = emp1 - 500;
emp1.Show();

Console.WriteLine("Создаем сотрудника2");
Employee emp2 = new Employee("Sergey", "Sergeyev", 16000);
emp2.Show();

Console.WriteLine("\nСравниваем сотрудника1 с сотрудника2 emp1.Equals(emp2)");
Console.WriteLine(emp1.Equals(emp2));

Console.WriteLine("\nСравниваем сотрудника1 с сотрудника2 emp1==emp2");
Console.WriteLine(emp1==emp2);


Console.WriteLine("\nСравниваем сотрудника1 с сотрудника2 emp1 > emp2");
Console.WriteLine(emp1 > emp2);

Console.WriteLine("\nСравниваем сотрудника1 с сотрудника2 emp1 < emp2");
Console.WriteLine(emp1 < emp2);

Console.WriteLine("\n Перемножаем матрицы");

Matrix matrix1 = new Matrix(2,4);
matrix1.matrix[0, 0] = 1;
matrix1.matrix[0, 1] = 2;
matrix1.matrix[0, 2] = 3;
matrix1.matrix[0, 3] = 4;
matrix1.matrix[1, 0] = 5;
matrix1.matrix[1, 1] = 6;
matrix1.matrix[1, 2] = 7;
matrix1.matrix[1, 3] = 8;


Matrix matrix2 = new Matrix(4, 2);
matrix2.matrix[0, 0] = 1;
matrix2.matrix[0, 1] = 2;
matrix2.matrix[1, 0] = 3;
matrix2.matrix[1, 1] = 4;
matrix2.matrix[2, 0] = 5;
matrix2.matrix[2, 1] = 6;
matrix2.matrix[3, 0] = 7;
matrix2.matrix[3, 1] = 8;


Matrix matrix3 = matrix1 * matrix2;

Console.ReadLine();