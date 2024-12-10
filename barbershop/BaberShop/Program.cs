// See https://aka.ms/new-console-template for more information

using BarberShop;




// Создаём 10 клиентов
List<Customer> customers = new List<Customer>(10);
for (int i = 0; i < customers.Capacity; i++)
{
    customers.Add(new Customer($"Customer#{i}"));
}

//Создаем комнату ожидания передавая список Customer ов желающих зайти в комнату
WaitingRoom waitingRoom = new WaitingRoom(3, customers);

//Создаем 1го барбера передавая в конструктор из какой комнаты Барбер берет своих клиентов
Barber barber = new Barber("Peter", waitingRoom);


//создаем два потока, один для комнаты ожидания, второй для барбера
Thread waitingRoomThread = new Thread(waitingRoom.Startworking);
Thread barbersThread = new Thread(barber.CutHair);

//стартуем оба потока
waitingRoomThread.Start();
barbersThread.Start();  

