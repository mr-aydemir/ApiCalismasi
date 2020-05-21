using System;

namespace VatanBilgisayarMobil.Models
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public int UserId { get; set; }
        public int ProductID { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}