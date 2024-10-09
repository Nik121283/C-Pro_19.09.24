using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_OOP_3
{
    public struct MyStructure
    {
        public int desytichnoe;

        public MyStructure(int desytichnoe)
        {
            this.desytichnoe = desytichnoe;
        }

        public void convertTo2()
        {
            string result = Convert.ToString(desytichnoe, 2);
            Console.WriteLine(result);
        }

        public void convertTo8()
        {
            string result = Convert.ToString(desytichnoe, 8);
            Console.WriteLine(result);
        }

        public void convertTo16()
        {
            string result = Convert.ToString(desytichnoe, 16);
            Console.WriteLine(result);
        }
    }
}
