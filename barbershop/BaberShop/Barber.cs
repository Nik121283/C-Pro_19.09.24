using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarberShop
{
    public class Barber
    {
        private readonly SemaphoreSlim _barberSemaphore; // Семафор для управления количеством клиентов у парикмахера
        private readonly WaitingRoom _waitingRoom;
        private string Name {  get; set; }

        public Barber(string name, WaitingRoom waitingRoom)
        {
            _barberSemaphore = new SemaphoreSlim(1, 1); // Один слот для парикмахера
            Name = name;
            _waitingRoom = waitingRoom;
        }

        public void CutHair()
        {
            while (_waitingRoom._waitingInside != null)
            {
                // Проверка, есть ли свободное место у барбера
                if (_barberSemaphore.Wait(0))
                {
                    var customer = _waitingRoom.CustomerTryEnterToBarberFromWaitingRoom();

                    if (customer != null)
                    {
                        Console.WriteLine($"{customer.CustomersName} сел в кресло к Барберу");
                        Thread.Sleep(1500);
                        Console.WriteLine($"{customer.CustomersName} стрежется у Барбера");
                        Thread.Sleep(1500);
                        Console.WriteLine($"{customer.CustomersName} подстригся у Барбера");
                        _barberSemaphore.Release();
                    }

                }

            }

        }
    }
}
