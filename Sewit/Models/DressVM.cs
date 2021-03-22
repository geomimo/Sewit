﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Models
{
    public class DressVM
    {
        public int ClothId { get; set; }
        public string PhotoPath { get; set; }
        public TopComponentVM Top { get; set; }
        public SkirtComponentVM Skirt { get; set; }
        public SleeveComponentVM Sleeve { get; set; }
    }

    public class DressCreateVM
    {

        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        public int TopId { get; set; }

        [Required]
        public int SkirtId { get; set; }

        [Required]
        public int SleeveId { get; set; }
    }

    public class DressEditVM
    {
        public int ClothId { get; set; }
        public string PhotoPath { get; set; }
        public IFormFile Photo { get; set; }
        public TopComponentVM Top { get; set; }
        public SkirtComponentVM Skirt { get; set; }
        public SleeveComponentVM Sleeve { get; set; }
    }
}
