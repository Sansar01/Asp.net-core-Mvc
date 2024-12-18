using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.net_core_Mvc.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }

        public List<SelectListItem> StudentList { get; set; }

    }
}
