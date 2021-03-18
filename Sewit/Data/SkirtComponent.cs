﻿using Sewit.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Data
{
    public class SkirtComponent
    {
        [Key]
        public int SkirtId { get; set; }
        public string PhotoPath { get; set; }
        public SkirtType Type { get; set; }
    }
}
