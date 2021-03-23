using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Models
{
    public class TopComponentVM
    {
        public int TopId { get; set; }
        public string Name { get; set; }
        
        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }
    }

    public class TopComponentCreateVM
    {
        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class TopComponentEditVM
    {
        public int TopId { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
