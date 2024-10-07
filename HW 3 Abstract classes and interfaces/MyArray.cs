﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Abstract_classes_and_interfaces
{
    public class MyArray : IOutput
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