using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Models
{
    public class OrderVM
    {
        public List<DressVM> Dresses { get; set; }
        [Display(Name = "Total Price")]
        public float TotalPrice { get; set; }
    }
}
