using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Abstract_classes_and_interfaces
{
    public interface ISort
    {
        public void SortAsc();

        public void SortDesc();

        public void SortByParam(bool if_true_asc);
    }
}
