using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_1_Calculator
{
    public static class Calculator<T> where T : struct, IComparable<T>
    {
        public static T Add(T t1, T t2)
        {
            return (dynamic)t1 + (dynamic)t2;
        }

        public static T Subtract(T t1, T t2)
        {
            return (dynamic)t1 - (dynamic)t2;
        }

        public static T Multiply(T t1, T t2)
        {
            return (dynamic)t1 * (dynamic)t2;
        }

        public static T Divide(T t1, T t2)
        {
            if ((dynamic)t1 == null || (dynamic)t2 == null)
            {
                throw new ArgumentNullException();
            }

            return (dynamic)t1 / (dynamic)t2;
        }
    }
}
