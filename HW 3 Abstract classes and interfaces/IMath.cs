using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Abstract_classes_and_interfaces
{
    public interface IMath
    {
        public int Max();

        public int Min();

        public float Avg();

        public bool Search(int valueToSearch);
    }
}
