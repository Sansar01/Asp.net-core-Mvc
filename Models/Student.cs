using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.net_core_Mvc.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("StudentName",TypeName ="Varchar(100)")]
        public string Name { get; set; }

        [Column("StudentGender", TypeName = "Varchar(20)")]
        public string Gender { get;set; }

        public int Age { get; set; }

        public string Branch { get; set; }
    }
}
