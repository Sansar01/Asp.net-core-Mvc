using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.net_core_Mvc.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("StudentName",TypeName ="Varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Column("StudentGender", TypeName = "Varchar(20)")]
        public string Gender { get;set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        public string? Branch { get; set; }
    }
}
