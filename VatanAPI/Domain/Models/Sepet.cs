using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace VatanAPI.Domain.Models
{
    public class Sepet
    {
        public int Id { get; set; }
        public string SepetKullanicisi { get; set; }


        public int ProductId { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
    }
}
