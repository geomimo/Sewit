using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Data
{
    public class Order
    {
        public List<Dress> Dresses { get; set; }
        public float TotalPrice { get; set; }
    }
}
