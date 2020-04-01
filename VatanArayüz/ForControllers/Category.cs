using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForControllers.VatanArayüz
{
    public class Category
    {
        public string Name { get; set; }
        public string Url  { get; set; }
        public string Info { get; set; }
        public List<Product> Products;
        
        public Category(string name, string url, string info, List<Product> products)
        {
            Name = name;
            Url  = url;
            Info = info;
            Products = products;
        }

    }
}
