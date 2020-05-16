using System;
using System.Collections.Generic;
using VatanAPI.Core.Models;

namespace VatanAPI.Domain.Models
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IList<Product> Products { get; set; }

    }
}
