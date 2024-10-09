// See https://aka.ms/new-console-template for more information


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