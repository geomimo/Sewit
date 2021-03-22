using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Data
{
    public class Dress
    {
        [Key]
        public int DressId { get; set; }
        public string PhotoPath { get; set; }

        [ForeignKey("TopId")]
        public int TopId { get; set; }
        public TopComponent Top { get; set; }

        [ForeignKey("SkirtId")]
        public int SkirtId { get; set; }
        public SkirtComponent Skirt { get; set; }

        [ForeignKey("SleeveId")]
        public int SleeveId { get; set; }
        public SleeveComponent Sleeve { get; set; }
    }
}
