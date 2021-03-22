using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Data
{
    public class TopComponent
    {
        [Key]
        public int TopId { get; set; }
        public string PhotoPath { get; set; }
        public string Name { get; set; }
    }
}
