﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindManagementApp.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Stock { get; set; }
    }
}
