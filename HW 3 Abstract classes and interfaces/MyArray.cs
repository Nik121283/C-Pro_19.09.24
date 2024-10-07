using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Abstract_classes_and_interfaces
{
    public class MyArray : IOutput, IMath, ISort
    {

        public int[] array;
        private int current_size;

        public MyArray( int array_size)
        {
            array = new int[array_size];
            current_size = array_size;
        }

        public  void AddItem(int item)
        {
            this.ResizeArray(this.current_size + 1);

            this.array[current_size-1] = item;

        }

        public float Avg()
        {
            float result = 0;

            foreach(int i in this.array)
            {
                result += i;
            }

            return result / this.current_size;
        }

        public void DeleteItem(int deletingIndex)
        {
            if (deletingIndex < 0 || deletingIndex>=current_size)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] newarray = new int[current_size-1];

            int j = 0;

            for (int i = 0; i < this.current_size; i++)
            {
                
                if(i == deletingIndex)
                {
                    i++;
                }

                    newarray[j] = array[i];

                j++;
            }

            this.current_size = current_size - 1;

            this.array = newarray;
        }

        public int Max()
        {
            int result = -2147483648;

            for(int i=0; i < this.current_size; i++)
            {
                if (this.array[i] > result)
                {
                    result = this.array[i];
                }
            }
            return result;
        }

        public int Min()
        {
            int result = 2147483647;

            for (int i = 0; i < this.current_size; i++)
            {
                if (this.array[i] < result)
                {
                    result = this.array[i];
                }
            }
            return result;
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

        public bool Search(int valueToSearch)
        {
            bool result = false;
            
            for(int i = 0; i < this.current_size; i++)
            {
                if (this.array[i] == valueToSearch)
                {
                    result= true;
                }
            }

            return result;
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

        public void SortAsc()
        {
            int n = 1;

            for(int j=0; j< this.current_size-1; j++)
            {
                for (int i = 0; i < this.current_size-n; i++)
                {
                    if (this.array[i] > this.array[i + 1])
                    {
                        int temp = this.array[i + 1];

                        this.array[i + 1] = this.array[i];

                        this.array[i] = temp;
                    }
                }
                n++;
            }

        }

        public void SortByParam(bool if_true_asc)
        {
            if(if_true_asc == true)
            {
                this.SortAsc();
            }
            else { this.SortDesc(); }
        }

        public void SortDesc()
        {
            int n = 1;

            for (int j = 0; j < this.current_size - 1; j++)
            {
                for (int i = 0; i < this.current_size-n; i++)
                {
                    if (this.array[i] < this.array[i + 1])
                    {
                        int temp = this.array[i + 1];

                        this.array[i + 1] = this.array[i];

                        this.array[i] = temp;
                    }
                }
                n++;
            }
        }
    }
}
