using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Data
{
    public class Cloth
    {
        [Key]
        public int ClothId { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public TopComponent Top { get; set; }
        public SkirtComponent Skirt { get; set; }
        public SleeveComponent Sleeve { get; set; }
    }
}
