using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Models
{
    public class SleeveComponentVM
    {
        public int SleeveId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }
    }

    public class SleeveComponentCreateVM
    {
        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class SleeveComponentEditVM
    {
        public int SleeveId { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
