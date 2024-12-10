using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarberShop
{
    public class WaitingRoom
    {
        private  SemaphoreSlim _semaphore; // Семафор для ограничений на количество клиентов в комнате ожидания
        public  Queue<Customer> _waitingInside;
        private  Queue<Customer> _waitingOutside;

        public WaitingRoom(int maxCustomers, List<Customer> customersOutside)
        {
            _semaphore = new SemaphoreSlim(maxCustomers, maxCustomers); // Ограничиваем количеством 3 (слотов в комнате ожидания)
            _waitingInside = new Queue<Customer>(maxCustomers);

            _waitingOutside = new Queue<Customer>(customersOutside);
        }

        public void Startworking()
        {
            while (_waitingOutside != null)
            {
                CustomerTryEnterFromOutside();
                Thread.Sleep(1200);
            }
        }

        // Метод для добавления клиента в комнату ожидания
        public void CustomerTryEnterFromOutside()
        {
            if (_semaphore.Wait(0)) // Проверка, есть ли свободное место в комнате ожидания
            {
                if (_waitingOutside.Count > 0)
                {
                    _waitingInside.Enqueue(_waitingOutside.Dequeue());

                    Console.WriteLine($"Customer {_waitingInside.Last<Customer>().CustomersName} entered the waiting room.");

                }
                    
            }
            else
            {
                if(_waitingOutside.Count > 0 )
                Console.WriteLine($"Waiting room is full. Customer {_waitingOutside.First<Customer>().CustomersName} cannot enter.");
            }
        }


        public Customer CustomerTryEnterToBarberFromWaitingRoom()
        {
            if (_waitingInside.Count>0) // Проверка, есть ли свободное место в комнате ожидания
            {
                //уходит из комнаты ожидания освобождая место в комнате ожидания
                Console.WriteLine($"Customer {_waitingInside.Last<Customer>().CustomersName} entered the waiting room.");
                 var customerWentToTheBarber = _waitingInside.Dequeue();
                _semaphore.Release();

                return customerWentToTheBarber;
            }
            else
            {
                Console.WriteLine("Закончились желающие подстричься");
                return null;
            }
        }

    }
}
