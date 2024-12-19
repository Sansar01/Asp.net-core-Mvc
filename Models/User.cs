using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.net_core_Mvc.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserName { get;set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get;set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get;set; }
    }
}
