using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VatanAPI.Domain.Models;

namespace VatanAPI.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public int SepetID { get; set; }
        public Sepet Sepet { get; set; }
        public int SiparisID { get; set; }
        public IList<Siparis> Siparis { get; set; }

        //public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();
    }
}