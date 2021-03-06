using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Models
{
    public class DressVM
    {
        public int DressId { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }
        public string[] Size = new[] { "S", "M", "L" };
        [Display(Name = "Size")]
        public string SelectedSize { get; set; }
        [DataType(dataType: DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public float Price { get; set; }
        public TopComponentVM Top { get; set; }
        public SkirtComponentVM Skirt { get; set; }
        public SleeveComponentVM Sleeve { get; set; }
    }

    public class DressCreateVM
    {

        [Required]
        public IFormFile Photo { get; set; }
        public float Price { get; set; }

        [Required]
        [Display(Name = "Top")]
        public int TopId { get; set; }

        [Required]
        [Display(Name = "Skirt")]
        public int SkirtId { get; set; }

        [Required]
        [Display(Name = "Sleeve")]
        public int SleeveId { get; set; }
    }

    public class DressEditVM
    {
        public int DressId { get; set; }
        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }
        public float Price { get; set; }
        public IFormFile Photo { get; set; }
        public TopComponentVM Top { get; set; }
        public SkirtComponentVM Skirt { get; set; }
        public SleeveComponentVM Sleeve { get; set; }
    }
}
