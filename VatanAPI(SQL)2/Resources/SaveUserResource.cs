using System.ComponentModel.DataAnnotations;

namespace VatanAPI.Resources
{
    public class SaveUserResource
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

    }
}
