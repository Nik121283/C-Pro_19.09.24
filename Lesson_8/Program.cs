//using System.Text;

namespace Lesson8
{
    //// через делегаты
    //public delegate void AccountHandler(string message);

    //public class Account
    //{
    //        int sum;

    //        AccountHandler? taken;

    //        public Account(int sum) => this.sum = sum;

    //        // Реєструємо делегат
    //        public void RegisterHandler(AccountHandler del)
    //        {
    //            taken += del;
    //        }
    //        // Скасування реєстрації делегата
    //        public void UnregisterHandler(AccountHandler del)
    //        {
    //            taken -= del; // видаляємо делегат
    //        }

    //        public void Add(int sum) => this.sum += sum;
    //        public void Take(int sum)
    //        {
    //            if (this.sum >= sum)
    //            {
    //                this.sum -= sum;
    //                taken?.Invoke($"З рахунку списано {sum} у.о.");
    //            }
    //            else
    //                taken?.Invoke($"Недостатньо коштів. Баланс: {this.sum} у.о.");
    //        }
    //    }
    //}

    // через события
    class AccountEventArgs
    {
        // Сообщение
        public string Message { get; }

        // Сумма, на которую изменился счет
        public int Sum { get; }

        public AccountEventArgs(string message, int sum)
        {
            Message = message;
            Sum = sum;
        }
    }

    class Account
        {
            public delegate void AccountHandler(Account sender, AccountEventArgs e);
            public event AccountHandler? Notify;

            public int Sum { get; private set; }

            public Account(int sum) => Sum = sum;

            public void Put(int sum)
            {
                Sum += sum;
                Notify?.Invoke(this, new AccountEventArgs($"На счет поступило {sum}", sum));
            }
            public void Take(int sum)
            {
                if (Sum >= sum)
                {
                    Sum -= sum;
                    Notify?.Invoke(this, new AccountEventArgs($"Сумма {sum} снята со счета", sum));
                }
                else
                {
                    Notify?.Invoke(this, new AccountEventArgs("Недостаточно денег на счете", sum));
                }
            }
        }
    }

//    public static class Program
//    {
//        static void PrintSimpleMessage(string message) => Console.WriteLine(message);
//        static void PrintColorMessage(string message)
//        {
//            // Встановлюємо червоний колір символів
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine(message);
//            // Скидаємо налаштування кольору
//            Console.ResetColor();
//        }
//        //
//        static void DisplayMessage(Account sender, AccountEventArgs e)
//        {
//            Console.WriteLine($"Сумма транзакции: {e.Sum}");
//            Console.WriteLine(e.Message);
//            Console.WriteLine($"Текущая сумма на счете: {sender.Sum}");
//        }

//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            //// через делегаты
//            //Account account = new Account(200);
//            //// Додаємо в делегат посилання на методи
//            //account.RegisterHandler(PrintSimpleMessage);
//            //account.RegisterHandler(PrintColorMessage);
//            //// Двічі поспіль намагаємось зняти гроші
//            //account.Take(100);
//            //account.Take(150);

//            //// Видаляємо делегат
//            //account.UnregisterHandler(PrintColorMessage);
//            //// знову намагаємось зняти гроші
//            //account.Take(50);

//            // через события
//            Account acc = new Account(100);
//            acc.Notify += DisplayMessage;
//            acc.Put(20);
//            acc.Take(70);
//            acc.Take(150);
//        }
//    }
//}

// Делегати репрезентують такі об'єкти, які вказують на методи.
// Тобто делегати – це покажчики на методи і за допомогою делегатів ми можемо викликати ці методи.

// Для оголошення делегата використовується ключове слово delegate, після якого йде тип, назва і параметри, що повертається.
// delegate void Message();

// Делегат Message як тип, що повертається, має тип void (тобто нічого не повертає) і не приймає жодних параметрів.
// Це означає, що цей делегат може вказувати на будь-який метод, який не набуває жодних параметрів і нічого не повертає.

//Message mes; // 2. Створюємо змінну делегата
//mes = Hello; // 3. Привласнюємо цю змінну адресу методу
//mes(); // 4. Викликаємо метод

//void Hello() => Console.WriteLine("Hello world");

//delegate void Message(); // 1. Оголошуємо делегат

// При цьому делегати необов'язково можуть вказувати лише на методи, які визначені в тому класі,
// де визначена змінна делегата. Це можуть бути також методи інших класів і структур.

//Message message1 = Welcome.Print;
//Message message2 = new Hello().Display;

//message1(); // Welcome
//message2(); // Hello

//delegate void Message();

//class Welcome
//{
//    public static void Print() => Console.WriteLine("Welcome");
//}
//class Hello
//{
//    public void Display() => Console.WriteLine("Hello");
//}

// Місце визначення делегата
// v1
//class Program
//{
//    delegate void Message(); // 1. Оголошуємо делегат
//    static void Main()
//    {
//        Message mes; // 2. Створюємо змінну делегата
//        mes = Hello; // 3. Привласнюємо цю змінну адресу методу
//        mes(); // 4. Викликаємо метод

//        void Hello() => Console.WriteLine("Hello");
//    }
//}

// v2
//delegate void Message(); // 1. Оголошуємо делегат
//class Program
//{
//    static void Main()
//    {
//        Message mes; // 2. Створюємо змінну делегата
//        mes = Hello; // 3. Привласнюємо цю змінну адресу методу
//        mes(); // 4. Викликаємо метод

//        void Hello() => Console.WriteLine("Hello");
//    }
//}

//
// Параметри та результат делегата

//Operation operation = Add; // делегат свідчить про метод Add
//int result = operation(4, 5); // Власне Add(4, 5)
//Console.WriteLine(result); // 9

//operation = Multiply; // Тепер делегат вказує на метод Multiply
//result = operation(4, 5); // Власне Multiply(4, 5)
//Console.WriteLine(result); // 20

//int Add(int x, int y) => x + y;

//int Multiply(int x, int y) => x * y;

//delegate int Operation(int x, int y);

//
// Присвоєння посилання метод
// створення об'єкта делегата за допомогою конструктора, який передається необхідний метод

//Operation operation1 = Add;
//Operation operation2 = new Operation(Add);

//int Add(int x, int y) => x + y;

//delegate int Operation(int x, int y);

//
// Відповідність методів делегату

// Як було написано вище, методи відповідають делегату, якщо вони мають один і той же тип, що повертається,
// і той самий набір параметрів. Але треба враховувати, що до уваги також беруться модифікатори ref, in та out.


//delegate void SomeDel(int a, double b);

////Цьому делегату відповідає, наприклад, наступний метод:

//void SomeMethod1(int g, double n) { }

////А такі методи не відповідають:

//double SomeMethod2(int g, double n) { return g + n; }
//void SomeMethod3(double n, int g) { }
//void SomeMethod4(ref int g, double n) { }
//void SomeMethod5(out int g, double n) { g = 6; }

// Додавання методів у делегат

// У прикладах вище змінна делегата вказувала на один метод.
// Насправді делегат може вказувати на безліч методів, які мають ту ж сигнатуру і повертаються тип.
// Усі методи у делегаті потрапляють у спеціальний список - список виклику чи invocation list.
// І при виклику делегата всі методи цього списку послідовно викликаються.
// І ми можемо додавати до цього списку не один, а кілька методів.
// Для додавання методів делегат застосовується операція +=

//Message message = Hello;
//message += HowAreYou; // Тепер message вказує на два методи
//message(); // викликаються обидва методи - Hello і HowAreYou

//void Hello() => Console.WriteLine("Hello");
//void HowAreYou() => Console.WriteLine("How are you?");

//delegate void Message();

// У цьому випадку до списку виклику делегата message додаються два методи - Hello і HowAreYou.
// І при виклику message викликаються відразу обидва ці методи.

// Однак варто відзначити, що в реальності відбуватиметься створення нового об'єкта делегата,
// який отримає методи старої копії делегата і новий метод, і новий об'єкт делегата буде присвоєний змінній message.

// При додаванні делегатів слід враховувати, що ми можемо додати посилання на той самий метод кілька разів,
// і в списку виклику делегата тоді буде кілька посилань на той самий метод.
// Відповідно при виклику делегата доданий метод буде викликатися стільки разів, скільки він був доданий:

//Message message = Hello;
//message += HowAreYou;
//message += Hello;
//message += Hello;

//message();

// Подібним чином ми можемо видаляти методи із делегата за допомогою операцій -=:

//Message? message = Hello;
//message += HowAreYou;
//message();  // вызываются все методы из message
//message -= HowAreYou;   // удаляем метод HowAreYou
//message -= Hello;
//if (message != null) message(); // вызывается метод Hello

//void Hello() => Console.WriteLine("Hello");
//void HowAreYou() => Console.WriteLine("How are you?");

//delegate void Message();

// При видаленні методів із делегата фактично буде створюватись новий делегат,
// який у списку виклику методів міститиме на один метод менше.

// Варто відзначити, що при видаленні методу може скластися ситуація,
// що в делегаті не буде методів, і тоді змінна матиме значення null.
// Тому в даному випадку змінна не просто визначена як змінна типу Message, а саме Message?,
// тобто типу, який може представляти як делегат Message, так і значення null.

// Крім того, перед другим викликом ми перевіряємо змінну значення null.

// При видаленні слід враховувати, що й делегат містить кілька посилань однією і той самий метод,
// то операція -= починає пошук із кінця списку виклику делегата і видаляє лише перше знайдене входження.
// Якщо такого методу у списку виклику делегата немає, то операція -= не має жодного ефекту.

// Об'єднання делегатів

//Message mes1 = Hello;
//Message mes2 = HowAreYou;
//Message mes3 = mes1 + mes2; // об'єднуємо делегати
//mes3(); // Викликаються всі методи з mes1 і mes2

//void Hello() => Console.WriteLine("Hello");
//void HowAreYou() => Console.WriteLine("How are you?");

//delegate void Message();

// У разі об'єкт mes3 представляє об'єднання делегатів mes1 і mes2.
// Об'єднання делегатів означає, що до списку виклику делегата mes3 потраплять усі методи із делегатів mes1 та mes2.
// І за виклику делегата mes3 всі ці методи одночасно будуть викликані.

// Виклик делегата

// У прикладах вище делегат викликався як стандартний спосіб.
// Якщо делегат приймав параметри, то його виклику для параметрів передавалися необхідні значення:

//Message mes = Hello;
//mes();
//Operation op = Add;
//int n = op(3, 4);
//Console.WriteLine(n);

//void Hello() => Console.WriteLine("Hello");
//int Add(int x, int y) => x + y;

//delegate int Operation(int x, int y);
//delegate void Message();

// Інший спосіб виклику делегата представляє метод Invoke():

//Message mes = Hello;
//mes.Invoke(); // Hello
//Operation op = Add;
//int n = op.Invoke(3, 4);
//Console.WriteLine(n);   // 7

//void Hello() => Console.WriteLine("Hello");
//int Add(int x, int y) => x + y;

//delegate int Operation(int x, int y);
//delegate void Message();

// Якщо делегат приймає параметри, то метод Invoke передаються значення цих параметрів.

// Слід враховувати, що й делегат порожній, тобто у його списку виклику немає посилань на жодну з методів
// (тобто делегат дорівнює Null), то за виклику такого делегата ми отримаємо виняток, як, наприклад, у наступному случае:

//Message? mes;
////mes(); //! Помилка: делегат дорівнює null

//Operation? op = Add;
//op -= Add; // делегат op порожній
//int n = op(3, 4); // !Помилка: делегат дорівнює null

// Тому при виклику делегата завжди краще перевіряти, чи він не дорівнює null.
// Або можна використовувати метод Invoke та оператор умовного null:

//Message? mes = null;
//mes?.Invoke(); // помилки немає, делегат просто не викликається

//Operation? op = Add;
//op -= Add; // делегат op порожній
//int? n = op?.Invoke(3, 4); // Помилки немає, делегат просто не викликається, а n = null

// Якщо делегат повертає деяке значення, то повертається значення останнього методу зі списку викликiв
// (якщо у списку викликiв кілька методів). Наприклад:

//Operation op = Subtract;
//op += Multiply;
//op += Add;
//Console.WriteLine(op(7, 2)); // Add(7,2) = 9

//int Add(int x, int y) => x + y;
//int Subtract(int x, int y) => x - y;
//int Multiply(int x, int y) => x * y;

//delegate int Operation(int x, int y);

// Узагальнені делегати

//Operation<decimal, int> squareOperation = Square;
//decimal result1 = squareOperation(5);
//Console.WriteLine(result1);  // 25

//Operation<int, int> doubleOperation = Double;
//int result2 = doubleOperation(5);
//Console.WriteLine(result2);  // 10

//decimal Square(int n) => n * n;
//int Double(int n) => n + n;

//delegate T Operation<T, K>(K val);

// Делегати як параметри методів

//DoOperation(5, 4, Add);         // 9
//DoOperation(5, 4, Subtract);    // 1
//DoOperation(5, 4, Multiply);    // 20

//void DoOperation(int a, int b, Operation op)
//{
//    Console.WriteLine(op(a, b));
//}
//int Add(int x, int y) => x + y;
//int Subtract(int x, int y) => x - y;
//int Multiply(int x, int y) => x * y;

//delegate int Operation(int x, int y);

// Тут метод DoOperation як параметри приймає два числа і деяку дію у вигляді делегата Operation.
// Всередині методу викликаємо делегат Operation, передаючи йому числа з перших двох параметрів.

// При виклику методу DoOperation ми можемо передати до нього як третій параметр метод, який відповідає делегату Operation.

// Повернення делегатів із методу

//Operation operation = SelectOperation(OperationType.Add);
//Console.WriteLine(operation(10, 4));    // 14

//operation = SelectOperation(OperationType.Subtract);
//Console.WriteLine(operation(10, 4));    // 6

//operation = SelectOperation(OperationType.Multiply);
//Console.WriteLine(operation(10, 4));    // 40

//Operation SelectOperation(OperationType opType)
//{
//    switch (opType)
//    {
//        case OperationType.Add: return Add;
//        case OperationType.Subtract: return Subtract;
//        default: return Multiply;
//    }
//}

//int Add(int x, int y) => x + y;
//int Subtract(int x, int y) => x - y;
//int Multiply(int x, int y) => x * y;

//enum OperationType
//{
//    Add,

//    Subtract,

//    Multiply
//}
//delegate int Operation(int x, int y);

////////////////////////////////

// Із делегатами тісно пов'язані анонімні методи. Анонімні методи використовують для створення екземплярів делегатів.

// Визначення анонімних методів починається з ключового слова delegate,
// після якого йде у дужках список параметрів та тіло методу у фігурних дужках:

//delegate (параметры)
//{
//    // інструкції
//}

// Наприклад

//MessageHandler handler = delegate (string mes)
//{
//    Console.WriteLine(mes);
//};
//handler("hello world!");

//delegate void MessageHandler(string message);

//Анонімний метод не може існувати сам по собі, він використовується для ініціалізації екземпляра делегата,
//як у даному випадку змінна handler є анонімним методом. І через цю змінну делегата можна викликати цей анонімний метод.

//Інший приклад анонімних методів - передача як аргумент для параметра, який представляє делегат:

//ShowMessage("hello!", delegate (string mes)
//{
//    Console.WriteLine(mes);
//});

//static void ShowMessage(string message, MessageHandler handler)
//{
//    handler(message);
//}

//delegate void MessageHandler(string message);

//
// Якщо анонімний метод використовує параметри, вони повинні відповідати параметрам делегата.
// Якщо для анонімного методу не потрібні параметри, то дужки з параметрами опускаються.
// При цьому навіть якщо делегат приймає кілька параметрів, то в анонімному методі можна опустити параметри:

//MessageHandler handler = delegate
//{
//    Console.WriteLine("анонімний метод");
//};
//handler("hello world!"); // анонімний метод

//delegate void MessageHandler(string message);

//Тобто, якщо анонімний метод містить параметри, вони обов'язково повинні відповідати параметрам делегата.
//Або анонімний метод взагалі може не містити жодних параметрів, тоді він відповідає будь-якому делегату,
//який має той же тип значення, що повертається.

//При цьому параметри анонімного методу не можуть бути опущені, якщо один або кілька параметрів визначено модифікатором out.

//Так само, як і звичайні методи, анонімні можуть повертати результат:

//Operation operation = delegate (int x, int y)
//{
//    return x + y;
//};
//int result = operation(4, 5);
//Console.WriteLine(result);       // 9

//delegate int Operation(int x, int y);

// При цьому анонімний метод має доступ до всіх змінних, визначених у зовнішньому коді:

//int a = 8;
//Operation operation = delegate (int x, int y)
//{
//    return x + y + a;
//};
//int result = operation(4, 5);
//Console.WriteLine(result);       // 17

//delegate int Operation(int x, int y);

// У яких ситуаціях використовують анонімні методи? Коли нам треба визначити одноразову дію,
// яка не має багато інструкцій та ніде більше не використовується.
// Зокрема, їх можна використовувати для обробки подій

//
// Лямбда-вираження представляють спрощений запис анонімних методів.
// Лямбда-вираження дозволяють створити ємні лаконічні методи,
// які можуть повертати деяке значення і які можна передати як параметри в інші методи.
// Ламбда - вирази мають наступний синтаксис: ліворуч від лямбда-оператора => визначається список параметрів,
// а праворуч блок виразів, який використовує ці параметри:

// (список_параметров) => выражение

// З погляду типу даних лямбда-вираз представляє делегат. Наприклад, визначимо найпростіше лямбда-вираз:

//Message hello = () => Console.WriteLine("Hello");
//hello();       // Hello
//hello();       // Hello
//hello();       // Hello

//delegate void Message();

// В даному випадку змінна hello представляє делегат Message -
// тобто деяка дія, яка нічого не повертає і не приймає жодних параметрів.
// Як значення цієї змінної надається лямбда-вираз.
// Цей лямбда-вираз має відповідати делегату Message – воно теж не приймає жодних параметрів,
// тому ліворуч від лямбда-оператора йдуть порожні дужки.
// А праворуч від лямбда-оператора йде вираз, що виконується - Console.WriteLine("Hello")

// Потім у програмі можна викликати цю змінну як метод.
// Якщо лямбда-вираз містить кілька дій, то вони поміщаються у фігурні дужки:

//Message hello = () =>
//{
//    Console.Write("Hello ");
//    Console.WriteLine("World");
//};
//hello();       // Hello World

//delegate void Message();

// Вище ми визначили змінну hello, яка представляє делегат Message.
// Але починаючи з версії C# 10 ми можемо застосовувати неявну типізацію
// (визначення змінної за допомогою оператора var) щодо лямбда-выражения:

//var hello = () => Console.WriteLine("Hello");
//hello();       // Hello
//hello();       // Hello
//hello();       // Hello

//
// Але який тип у разі представляє змінна hello?
// При неявної типізації компілятор сам намагається зіставити лямбда-вираз з урахуванням
// його випередження з яким-небудь делегатом.
// Наприклад, вище певний лямбда-вираз hello за замовчуванням компілятор буде розглядати як
// змінну вбудованого делегата Action, який не приймає жодних параметрів і нічого не повертає.

// Параметри лямбди

//Operation sum = (x, y) => Console.WriteLine($"{x} + {y} = {x + y}");
//sum(1, 2);       // 1 + 2 = 3
//sum(22, 14);    // 22 + 14 = 36

//delegate void Operation(int x, int y);

//У даному випадку компілятор бачить, що лямбда-вираз sum є типом Operation,
//а значить обидва параметри лямбди представляють тип int. Тому жодних проблем не виникне.

//Однак якщо ми застосовуємо неявну типізацію, то компілятор може мати труднощі,
//щоб вивести тип делегата для лямбда-вираження, наприклад, у наступному випадку


// var sum = (x, y) => Console.WriteLine($"{x} + {y} = {x + y}");   // ! Ошибка

// У цьому випадку можна вказати тип параметрів

//var sum = (int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
//sum(1, 2);       // 1 + 2 = 3
//sum(22, 14);    // 22 + 14 = 36

// Якщо лямбда має один параметр, для якого не потрібно вказувати тип даних, дужки можна опустити:

//PrintHandler print = message => Console.WriteLine(message);
//print("Hello");         // Hello
//print("Welcome");       // Welcome

//delegate void PrintHandler(string message);

// Повернення результату

//var sum = (int x, int y) => x + y;
//int sumResult = sum(4, 5);                  // 9
//Console.WriteLine(sumResult);               // 9

//Operation multiply = (x, y) => x * y;
//int multiplyResult = multiply(4, 5);        // 20
//Console.WriteLine(multiplyResult);          // 20

//delegate int Operation(int x, int y);

// или

//var subtract = (int x, int y) =>
//{
//    if (x > y) return x - y;
//    else return y - x;
//};
//int result1 = subtract(10, 6);  // 4 
//Console.WriteLine(result1);     // 4

//int result2 = subtract(-10, 6);  // 16
//Console.WriteLine(result2);      // 16

//
// Додавання та видалення дій у лямбда-вираженні

//var hello = () => Console.WriteLine("Hello");

//var message = () => Console.Write("Hello");
//message += () => Console.WriteLine("World"); // Додаємо анонімне лямбда-вираз
//message += hello; // додаємо лямбда-вираз зі змінної hello
//message += Print; // додаємо метод

//message();
//Console.WriteLine("--------------"); // для поділу висновку

//message -= Print; // видаляємо метод
//message -= hello; // видаляємо лямбда-вираз із змінної hello

//message?.Invoke(); // на випадок, якщо у message більше немає дій

//void Print() => Console.WriteLine("Welcome to C#");

// Лямбда-вираз як аргумент методу

//int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

//// знайдемо суму чисел більше 5
//int result1 = Sum(integers, x => x > 5);
//Console.WriteLine(result1); // 30

//// Знайдемо суму парних чисел
//int result2 = Sum(integers, x => x % 2 == 0);
//Console.WriteLine(result2); //20

//int Sum(int[] numbers, IsEqual func)
//{
//    int result = 0;
//    foreach (int i in numbers)
//    {
//        if (func(i))
//            result += i;
//    }
//    return result;
//}

//delegate bool IsEqual(int x);

//
// Лямбда-вираз як результат методу

//Operation operation = SelectOperation(OperationType.Add);
//Console.WriteLine(operation(10, 4));    // 14

//operation = SelectOperation(OperationType.Subtract);
//Console.WriteLine(operation(10, 4));    // 6

//operation = SelectOperation(OperationType.Multiply);
//Console.WriteLine(operation(10, 4));    // 40

//Operation SelectOperation(OperationType opType)
//{
//    switch (opType)
//    {
//        case OperationType.Add: return (x, y) => x + y;
//        case OperationType.Subtract: return (x, y) => x - y;
//        default: return (x, y) => x * y;
//    }
//}
//enum OperationType
//{
//    Add, Subtract, Multiply
//}
//delegate int Operation(int x, int y);

//
// Події
// Події сигналізують системі про те, що сталася певна дія.
// І якщо нам треба відстежити ці дії, то ми можемо застосовувати події.

// У .NET є кілька вбудованих делегатів, які використовуються у різних ситуаціях.
// І найбільш використовуваними, з якими часто доводиться стикатися, є Action, Predicate та Func.

// Делегат Action представляє деяку дію, яка нічого не повертає, тобто як тип, що повертається, має тип void
//public delegate void Action()
//public delegate void Action<in T>(T obj)

//Цей делегат має ряд перевантажених версій. Кожна версія приймає різну кількість параметрів:
//від Action<in T1> до Action<in T1, in T2,....in T16>. Таким чином можна передати до 16 значень метод.

//Як правило, цей делегат передається як параметр методу і передбачає виклик певних дій у відповідь на дії, що відбулися.
//Наприклад:

//DoOperation(10, 6, Add);        // 10 + 6 = 16
//DoOperation(10, 6, Multiply);   // 10 * 6 = 60

//void DoOperation(int a, int b, Action<int, int> op) => op(a, b);

//void Add(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
//void Multiply(int x, int y) => Console.WriteLine($"{x} * {y} = {x * y}");

// Делегат Predicate приймає один параметр і повертає значення типу bool
// delegate bool Predicate<in T>(T obj);

//Predicate<int> isPositive = (int x) => x > 0;

//Console.WriteLine(isPositive(20));
//Console.WriteLine(isPositive(-20));

// Ще одним поширеним делегатом є Func. Він повертає результат дії та може приймати параметри.
// Він також має різні форми: від Func<out T>(), де T - тип значення, що повертається,
// до Func<in T1, in T2,...in T16, out TResult>(), тобто може приймати до 16 параметрів .

//TResult Func<out TResult>()
//TResult Func<in T, out TResult>(T arg)
//TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2)
//TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3)
//TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
//...........................................

//int result1 = DoOperation(6, DoubleNumber); // 12
//Console.WriteLine(result1);

//int result2 = DoOperation(6, SquareNumber); // 36
//Console.WriteLine(result2);

//int DoOperation(int n, Func<int, int> operation) => operation(n);
//int DoubleNumber(int n) => 2 * n;
//int SquareNumber(int n) => n * n;

//

//Func<int, int, string> createString = (a, b) => $"{a}{b}";
//Console.WriteLine(createString(1, 5));  // 15
//Console.WriteLine(createString(3, 5));  // 35

//
//Замикання(closure) представляє об'єкт функції, який запам'ятовує своє лексичне
//оточення навіть у тому випадку, коли вона виконується поза своєю областю видимості.

//Технічно замикання включає три компоненти:

//зовнішня функція, яка визначає деяку область видимості та в якій визначені деякі змінні та параметри - лексичне оточення

//змінні та параметри (лексичне оточення), які визначені у зовнішній функції

//вкладена функція, яка використовує змінні та параметри зовнішньої функції


//У мові C# реалізувати замикання можна у різний спосіб - з допомогою локальних функцій і лямбда-выражений.

//Розглянемо створення замикань через локальні функції:

//var fn = Outer(); // fn = Inner, оскільки метод Outer повертає функцію Inner
//// Викликаємо внутрішню функцію Inner
//fn(); // 6
//fn(); // 7
//fn(); // 8

//Action Outer() // метод чи зовнішня функція
//{
//    int x = 5; // лексичне оточення – локальна змінна
//    void Inner() // локальна функція
//    {
//        // x++; // Операції з лексичним оточенням
//        Console.WriteLine(x);
//    }
//    return Inner; // Повертаємо локальну функцію
//}

// Реалізація за допомогою лямбда-виразів

//var outerFn = () =>
//{
//    int x = 10;
//    var innerFn = () => Console.WriteLine(++x);
//    return innerFn;
//};

//var fn = outerFn();   // fn = innerFn, так как outerFn возвращает innerFn
//// вызываем innerFn
//fn();   // 11
//fn();   // 12
//fn();   // 13

// Застосування параметрів

//var fn = Multiply(5);

//Console.WriteLine(fn(5));   // 25
//Console.WriteLine(fn(6));   // 30
//Console.WriteLine(fn(7));   // 35

//Operation Multiply(int n)
//{
//    int Inner(int m)
//    {
//        return n * m;
//    }
//    return Inner;
//}
//delegate int Operation(int n);

//

//var multiply = (int n) => (int m) => n * m;

//var fn = multiply(5);

//Console.WriteLine(fn(5));   // 25
//Console.WriteLine(fn(6));   // 30
//Console.WriteLine(fn(7));   // 35

// https://ru.stackoverflow.com/questions/516687/%D0%92-%D1%87%D0%B5%D0%BC-%D1%81%D1%83%D1%82%D1%8C-%D0%BA%D0%BE%D0%B2%D0%B0%D1%80%D0%B8%D0%B0%D0%BD%D1%82%D0%BD%D0%BE%D1%81%D1%82%D0%B8-%D0%B8-%D0%BA%D0%BE%D0%BD%D1%82%D1%80%D0%B0%D0%B2%D0%B0%D1%80%D0%B8%D0%B0%D0%BD%D1%82%D0%BD%D0%BE%D1%81%D1%82%D0%B8-%D0%B4%D0%B5%D0%BB%D0%B5%D0%B3%D0%B0%D1%82%D0%BE%D0%B2
// https://learn.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/covariance-contravariance/using-variance-in-delegates
// https://ru.wikipedia.org/wiki/%D0%9A%D0%BE%D0%B2%D0%B0%D1%80%D0%B8%D0%B0%D0%BD%D1%82%D0%BD%D0%BE%D1%81%D1%82%D1%8C_%D0%B8_%D0%BA%D0%BE%D0%BD%D1%82%D1%80%D0%B0%D0%B2%D0%B0%D1%80%D0%B8%D0%B0%D0%BD%D1%82%D0%BD%D0%BE%D1%81%D1%82%D1%8C_(%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5)
