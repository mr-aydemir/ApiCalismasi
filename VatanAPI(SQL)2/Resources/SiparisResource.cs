using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanAPI.Controllers.Resources;

namespace VatanAPI.Resources
{
    public class SiparisResource
    {
        public int SiparisId { get; set; }
        public decimal UrunFiyati { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public int UserId { get; set; }
    }
}
