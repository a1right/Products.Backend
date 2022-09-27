﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain
{
    public partial class Product
    {
        public Product()
        {
            ProductVersions = new HashSet<ProductVersion>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<ProductVersion> ProductVersions { get; set; }
    }
}
