using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace VatanAPI.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Marka { get; set; }
        public string Url { get; set; }
        public double Cost { get; set; }
        public CategoryResource Category { get; set; }
    }
}
