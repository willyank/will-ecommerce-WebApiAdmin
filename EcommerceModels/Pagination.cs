using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceModels
{
    public class Pagination<T>
    {
        public int Total { get; set; }
        public List<T> Items { get; set; }
    }
}
