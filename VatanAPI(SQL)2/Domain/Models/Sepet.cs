using System.Collections.Generic;
using VatanAPI.Core.Models;

namespace VatanAPI.Domain.Models
{
    public class Sepet
    {
        public int SepetId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IList<Product> Product { get; set; }
    }
}
