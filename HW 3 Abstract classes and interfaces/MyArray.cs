using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Abstract_classes_and_interfaces
{
    public class MyArray : IOutput
    {

        private int[] array;
        private int current_size;
        private int current_index;

        public MyArray( int array_size)
        {
            array = new int[array_size];
            current_size = array_size;
            current_index = 0;
        }

        public  void AddItem(int item)
        {
            this.ResizeArray(this.current_size + 1);

            this.array[current_size-1] = item;

        }

        public void ResizeArray(int newsize)
        {
            int[] newarray = new int[newsize];

            for (int i = 0; i < this.current_size; i++)
            {
                newarray[i] = array[i];
            }

            this.current_size = newsize;

            this.array = newarray;
        }



        public void Show()
        {
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }

        public void Show(string info)
        {
            foreach (int i in array)
            {
                Console.WriteLine($"{info}: {i}");
            }
        }
    }
}
